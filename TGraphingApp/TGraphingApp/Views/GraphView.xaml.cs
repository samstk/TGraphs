using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TGraphingApp.Models;
using static System.Formats.Asn1.AsnWriter;

namespace TGraphingApp.Views
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        public Scene ReferenceScene = new Scene();

        #region Display Properties
        /// <summary>
        /// The render width in pixels
        /// </summary>
        public double RenderWidth
        {
            get
            {
                if (ReferenceScene == null) return 0;

                double renderWidth = ActualWidth;

                if (double.IsNaN(renderWidth))
                    renderWidth = 300;

                if (renderWidth < 20)
                    renderWidth = 20;

                return renderWidth;
            }
        }

        /// <summary>
        /// The render height in pixels
        /// </summary>
        public double RenderHeight
        {
            get
            {
                if (ReferenceScene == null) return 0;

                double renderHeight = ActualHeight;

                if (double.IsNaN(renderHeight))
                    renderHeight = 300;

                if (renderHeight < 20)
                    renderHeight = 20;

                return renderHeight;
            }
        }

        /// <summary>
        /// Number of X positions per pixel
        /// </summary>
        public double XPerPixel =>
            ReferenceScene == null ? 1 :
            (ReferenceScene.DesignViewMaxX - ReferenceScene.DesignViewMinX) / RenderWidth;

        /// <summary>
        /// Number of Y positions per pixel
        /// </summary>
        public double YPerPixel =>
            ReferenceScene == null ? 1 :
            (ReferenceScene.DesignViewMaxY - ReferenceScene.DesignViewMinY) / RenderHeight;

        /// <summary>
        /// IF either null if no origin line exists on the y position, or the proportional position (%)
        /// of the origin line
        /// </summary>
        public double OriginYPosition =>
            ReferenceScene == null ? -1 :
            TGraphMath.CalculatePositionBetweenPoints(0, ReferenceScene.DesignViewMinY, ReferenceScene.DesignViewMaxY);

        /// <summary>
        /// IF either null if no origin line exists on the x position, or the proportional position (%)
        /// of the origin line
        /// </summary>
        public double OriginXPosition =>
            ReferenceScene == null ? -1 :
            TGraphMath.CalculatePositionBetweenPoints(0, ReferenceScene.DesignViewMinX, ReferenceScene.DesignViewMaxX);


        #endregion

        public GraphView()
        {
            InitializeComponent();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (ReferenceScene != null)
                Refresh(ReferenceScene);

            base.OnRenderSizeChanged(sizeInfo);
        }

        #region Drawing Operations
        private void DrawErrorMessage(string msg)
        {
            TextBlock block = new TextBlock()
            {
                Text = msg,
                Background = Brushes.WhiteSmoke,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            GraphCanvas.Children.Add(block);
        }

        private void DrawInstances()
        {
            foreach(Instance instance in ReferenceScene.Instances)
            {
                (double[] tValues, object[] points) = instance.CalculateRenderingPoints();
                
                if (instance.CompiledMessage != null)
                {
                    DrawErrorMessage("Error on Instance -- " + instance.Name + "\r\n" + instance.CompiledMessage);
                    break;
                } 

                if (points.Length > 0)
                {
                    try
                    {
                        Path drawingPath = new Path()
                        {
                            Stroke = instance.DesignFill,
                            StrokeThickness = instance.DesignPlotSize,
                        };

                        Point startingPosition = new Point();

                        PathSegment[] segments = new PathSegment[points.Length - 1];

                        if (points[0] is double)
                        {
                            double p1 = (double)points[0];
                            startingPosition = TGraphMath.CalculateActualPositionOfValuesBetweenPoints(
                                        tValues[0], p1,
                                        ReferenceScene.DesignViewMinX, ReferenceScene.DesignViewMaxX,
                                        ReferenceScene.DesignViewMinY, ReferenceScene.DesignViewMaxY,
                                        RenderWidth, RenderHeight
                                    );
                            for (int i = 1; i < points.Length; i++)
                            {
                                double nextPointX = tValues[i];
                                double nextPointY = (double)points[i];

                                segments[i - 1] = new LineSegment(
                                    TGraphMath.CalculateActualPositionOfValuesBetweenPoints(
                                        nextPointX, nextPointY,
                                        ReferenceScene.DesignViewMinX, ReferenceScene.DesignViewMaxX,
                                        ReferenceScene.DesignViewMinY, ReferenceScene.DesignViewMaxY,
                                        RenderWidth, RenderHeight
                                    ), true
                                    );
                            }
                        }
                        else if (points[0] is (double, double))
                        {
                            (double, double) p1 = ((double, double)) points[0];
                            startingPosition = TGraphMath.CalculateActualPositionOfValuesBetweenPoints(
                                        p1.Item1, p1.Item2,
                                        ReferenceScene.DesignViewMinX, ReferenceScene.DesignViewMaxX,
                                        ReferenceScene.DesignViewMinY, ReferenceScene.DesignViewMaxY,
                                        RenderWidth, RenderHeight
                                    );

                            for (int i = 1; i < points.Length; i++)
                            {
                                (double, double) point = ((double, double)) points[i];
                                double nextPointX = point.Item1;
                                double nextPointY = point.Item2;

                                segments[i - 1] = new LineSegment(
                                    TGraphMath.CalculateActualPositionOfValuesBetweenPoints(
                                        nextPointX, nextPointY,
                                        ReferenceScene.DesignViewMinX, ReferenceScene.DesignViewMaxX,
                                        ReferenceScene.DesignViewMinY, ReferenceScene.DesignViewMaxY,
                                        RenderWidth, RenderHeight
                                    ), true
                                    );
                            }
                        }

                        drawingPath.Data = new PathGeometry(
                            new PathFigure[] {
                                new PathFigure(startingPosition, segments, false)
                                }
                            );

                        GraphCanvas.Children.Add(drawingPath);
                    }
                    catch
                    {
                        DrawErrorMessage("Error on Instance -- " + instance.Name + "\r\nUnable to draw path. Check to make sure function does not mix types.");
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Draws both origin lines at x=0, y=0 if they exist on screen.
        /// </summary>
        private void DrawOriginLines()
        {
            double yOrigin = OriginYPosition * RenderHeight;
            double xOrigin = OriginXPosition * RenderWidth;
            if (OriginYPosition >= 0 && OriginYPosition <= 1)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = 0,
                    Y1 = yOrigin,
                    X2 = RenderWidth,
                    Y2 = yOrigin,
                    Stroke = ReferenceScene.DesignOriginLineFill,
                    StrokeThickness = 2
                });
            }
            if (OriginXPosition >= 0 && OriginXPosition <= 1)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = xOrigin,
                    Y1 = 0,
                    X2 = xOrigin,
                    Y2 = RenderHeight,
                    Stroke = ReferenceScene.DesignOriginLineFill,
                    StrokeThickness = 2
                });
            }
        }

        private void DrawGrid()
        {
            double yOrigin = OriginYPosition % 1.0;
            double xOrigin = OriginXPosition % 1.0;
            if (xOrigin < 0)
                xOrigin += 1;
            if (yOrigin < 0)
                yOrigin += 1;

            double spacePerXPoint = RenderWidth / ReferenceScene.DesignGridPointsX;
            double spacePerYPoint = RenderHeight / ReferenceScene.DesignGridPointsY;

            double startX = xOrigin * RenderWidth;
            double startY = yOrigin * RenderHeight;

            for (double x = startX; x >= 0; x -= spacePerXPoint)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = x,
                    Y1 = 0,
                    X2 = x,
                    Y2 = RenderHeight,
                    Stroke = ReferenceScene.DesignGridLineFill,
                    StrokeThickness = 1
                });
            }
            for (double x = startX + spacePerXPoint; x < RenderWidth; x += spacePerXPoint)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = x,
                    Y1 = 0,
                    X2 = x,
                    Y2 = RenderHeight,
                    Stroke = ReferenceScene.DesignGridLineFill,
                    StrokeThickness = 1
                });
            }

            for (double y = startY; y >= 0; y -= spacePerYPoint)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = 0,
                    Y1 = y,
                    X2 = RenderWidth,
                    Y2 = y,
                    Stroke = ReferenceScene.DesignGridLineFill,
                    StrokeThickness = 1
                });
            }
            for (double y = startY + spacePerYPoint; y < RenderHeight; y += spacePerYPoint)
            {
                GraphCanvas.Children.Add(new Line()
                {
                    X1 = 0,
                    Y1 = y,
                    X2 = RenderWidth,
                    Y2 = y,
                    Stroke = ReferenceScene.DesignGridLineFill,
                    StrokeThickness = 1
                });
            }
        }

        private static Typeface ErrorTypeface = new Typeface("Segoe UI");
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
        #endregion


        /// <summary>
        /// Refreshes the graphics for the given scene
        /// </summary>
        /// <param name="scene">The scene to draw based on.</param>
        public void Refresh(Scene scene)
        {
            // Update reference scene.
            ReferenceScene = scene;

            // Recompile all instance expressions.
            scene.Instances.ForEach(instance => instance.CompileExpression(true));

            // Update the canvas.
            GraphCanvas.Children.Clear();

            GraphCanvas.Width = RenderWidth;
            GraphCanvas.Height = RenderHeight;

            DrawGrid();
            DrawOriginLines();
            DrawInstances();

            GraphCanvas.Background = scene.DesignBackgroundFill;
        }
    }
}
