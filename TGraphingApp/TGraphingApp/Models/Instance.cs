﻿using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CSharp;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using Microsoft.CodeAnalysis.Emit;
using System.Runtime.Loader;

namespace TGraphingApp.Models
{

    /// <summary>
    /// An instance of a scene represents an object displayed
    /// on the shared graph. The instance contains an expression
    /// which is to be calculated for all visible points on the graph.
    /// </summary>
    public class Instance : ICloneable
    {
        /// <summary>
        /// The name of the instance for reference purposes.
        /// </summary>
        public string Name { get; set; } = "Untitled Instance";

        /// <summary>
        /// The expression which is to be evaluated in this instance.
        /// </summary>
        public string Expression { get; set; } = "";

        [JsonIgnore()]
        public string CompiledMessage = "<not compiled>";

        [JsonIgnore()]
        /// <summary>
        /// The last expression that was compiled.
        /// </summary>
        private string _CompiledExpression { get; set; } = "";

        [JsonIgnore()]
        private MethodInfo? _CompiledExpressionMethod;

        #region Compilation

        #endregion

        #region Display

        private SolidColorBrush _DesignFill = Brushes.SkyBlue;

        /// <summary>
        /// Gets the brush to be used for drawing the instance
        /// </summary>
        [JsonIgnore()]
        public SolidColorBrush DesignFill
        {
            get
            {
                if (_DesignFill.Color != DesignColor)
                {
                    _DesignFill = new SolidColorBrush(DesignColor);
                }

                return _DesignFill;
            }
        }

        /// <summary>
        /// The color that is displayed on the graph for this instance.
        /// </summary>
        public InstanceColor DesignColor { get; set; } = Colors.SkyBlue;



        /// <summary>
        /// The type of cursor displayed at the current parameter
        /// </summary>
        public InstanceCursorType DesignCursorType { get; set; } = InstanceCursorType.Circle;
        
        /// <summary>
        /// The 'diameter' of the cursor displayed at the current parameter. If the cursor type is a box, then this
        /// represents the width of the box.
        /// </summary>
        public int DesignCursorSize = 4;

        /// <summary>
        /// The type of plot line displayed at all visible parameters.
        /// </summary>
        public InstancePlotType DesignPlotType { get; set; } = InstancePlotType.SolidLine;

        /// <summary>
        /// The thickness of the plot line displayed at all visible parameters.
        /// </summary>
        public int DesignPlotSize = 2;

        /// <summary>
        /// The x-values that this instance will cull
        /// </summary>
        public int DesignDomainMin = 0;

        /// <summary>
        /// The x-values that this instance will cull
        /// </summary>
        public int DesignDomainMax = 0;


        /// <summary>
        /// The minimum t-value for this instance.
        /// </summary>
        public double TMin { get; set; } = 0.0;

        /// <summary>
        /// The maximum t-value for this instance.
        /// </summary>
        public double TMax { get; set; } = 10.0;

        /// <summary>
        /// The t-value that is moved up in seconds.
        /// </summary>
        public double TStep { get; set; } = 1.0;

        /// <summary>
        /// The step between min and max for rendering
        /// </summary>
        public double TRenderStep { get; set; } = 0.05;

        [JsonIgnore()]
        public int RenderingPoints
        {
            get
            {
                if (TRenderStep == 0)
                    return 0;

                int amount = (int)(TDistance / TRenderStep) + 1;

                if (amount > TGraphInstanceScripting.MAX_RENDER_POINTS)
                    amount = TGraphInstanceScripting.MAX_RENDER_POINTS;

                return amount;
            }
        }

        /// <summary>
        /// The distance between the min and max t-values.
        /// </summary>
        [JsonIgnore()]
        public double TDistance
        {
            get
            {
                return Math.Abs(TMax - TMin);
            }
        }
        #endregion

        public static readonly AssemblyLoadContext InstanceContext = new AssemblyLoadContext("Expressions", true);
        public static int GeneratedAssemblyCount = 0;
        /// <summary>
        /// Compiles the expression using the Roselyn API
        /// </summary>
        /// <param name="checkCache">
        /// If true, then if the expression was already compiled
        /// it will reuse that instead of recompiling.
        /// </param>
        public void CompileExpression(bool checkCompiledExpression=false)
        {
            try
            {
                if (checkCompiledExpression)
                {
                    if (_CompiledExpression == Expression)
                        return;
                }

                // Compile with Roselyn
                bool generateReturn = !SyntaxFactory.ParseSyntaxTree(
                    "void f(t) { " + Expression + " }"
                    ).GetRoot().DescendantNodes().Any(x => x is ReturnStatementSyntax);

                string sourceCode =
                     TGraphInstanceScripting.SCRIPT_HEADER +
                        (generateReturn ? "return " : "") + Expression + (generateReturn ? ";" : "") +
                        TGraphInstanceScripting.SCRIPT_FOOTER;

                // Create compilation
                CSharpCompilation compilation = CSharpCompilation.Create(
                    "[Gen]"+(GeneratedAssemblyCount++).ToString(),
                    syntaxTrees: new SyntaxTree[] {
                        CSharpSyntaxTree.ParseText(sourceCode)
                    }
                    ).WithReferences(
                    MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location)
                    );

                // Load into Program
                using (var ms = new MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (result.Success)
                    {
                        CompiledMessage = null;
                        ms.Seek(0, SeekOrigin.Begin);

                        Assembly assembly = InstanceContext.LoadFromStream(ms);

                        _CompiledExpressionMethod =
                            assembly.GetType("TExpression")
                            .GetMethod("CalculateForAll");
                    }
                    else
                    {
                        CompiledMessage = result.Diagnostics.Aggregate<string, string, Diagnostic>(
                            "Errors:\r\n", (current, diagnostic) =>
                            {
                                return current + "\r\n" + diagnostic.ToString();
                            }, s => s 
                            );
                    }
                }

                _CompiledExpression = Expression;
            }
            catch
            {
                CompiledMessage = "Unknown error";
                _CompiledExpression = null;
            }
        }

        /// <summary>
        /// Calculate all values for the given set of t values.
        /// </summary>
        public object[] CalculateForAll(double[] tValues)
        {
            try
            {
                if (_CompiledExpressionMethod == null)
                    return new object[0];

                if (_CompiledExpressionMethod != null)
                {
                    object[]? results =
                        _CompiledExpressionMethod.Invoke(null, new object[] { tValues })
                        as Object[];

                    if (results == null)
                        return new object[0];

                    return results;
                }
            }
            catch { }

            return new object[0];
        }

        /// <summary>
        /// Calculates all points to be rendered.
        /// </summary>
        /// <returns>
        /// An array of results from the instance expression block.
        /// </returns>
        public (double[], object[]) CalculateRenderingPoints()
        {
            int renderingPoints = RenderingPoints;

            double[] tValues = new double[renderingPoints];

            for(int i = 0; i < tValues.Length; i++)
            {
                double perc = i / (double)(tValues.Length - 1);

                tValues[i] = TMin + (TMax - TMin) * perc;
            }

            return (tValues, CalculateForAll(tValues));
        }
        
        /// <summary>
        /// Clones an exact copy of the instance.
        /// </summary>
        /// <returns>An exact copy of this instance.</returns>
        public object Clone()
        {
            return new Instance()
            {
                Expression = Expression
            };
        }
    }
}
