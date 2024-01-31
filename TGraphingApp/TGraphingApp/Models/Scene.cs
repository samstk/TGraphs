using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TGraphingApp.Models
{
    /// <summary>
    /// A scene which contains one or more instances to be displayed
    /// on a graph.
    /// </summary>
    public class Scene : ICloneable
    {
        /// <summary>
        /// The expression instances of the scene.
        /// </summary>
        public List<Instance> Instances { get; set; } = new List<Instance>()
        {
            new Instance()
            {
                Expression = "t"
            }
        };

        /// <summary>
        /// The name of the scene
        /// </summary>
        public string Name { get; set; } = "Untitled Scene";

        /// <summary>
        /// The file path where this scene was last saved to.
        /// </summary>
        [JsonIgnore()]
        public string? FilePath { get; set; } = null;

        /// <summary>
        /// If true, then the scene is saved
        /// </summary>
        [JsonIgnore()]
        public bool IsSaved { get; set; } = true;

        /// <summary>
        /// True if the graph should render all t-points.
        /// </summary>
        public bool TRenderAll { get; set; } = true;

        /// <summary>
        /// The starting 'x' domain (time) that
        /// is displayed on the graph.
        /// </summary>
        public double DesignViewMinX { get; set; } = -1;

        /// <summary>
        /// The end 'x' (time) that
        /// is displayed on the graph.
        /// </summary>
        public double DesignViewMaxX { get; set; } = 10;

        /// <summary>
        /// The starting 'y' value that
        /// is displayed on the graph.
        /// </summary>
        public double DesignViewMinY { get; set; } = -1;

        /// <summary>
        /// The end 'y' value that
        /// is displayed on the graph.
        /// </summary>
        public double DesignViewMaxY { get; set; } = 10;

        /// <summary>
        /// The number of points on the x-axis (grid)
        /// </summary>
        public int DesignGridPointsX { get; set; } = 5;

        /// <summary>
        /// The number of points on the y-axis (grid)
        /// </summary>
        public int DesignGridPointsY { get; set; } = 5;

        private SolidColorBrush _DesignBackgroundFill = Brushes.Wheat;

        /// <summary>
        /// Gets the brush to be used for drawing the background
        /// </summary>
        [JsonIgnore()]
        public SolidColorBrush DesignBackgroundFill
        {
            get
            {
                if (_DesignBackgroundFill.Color != DesignBackgroundColor)
                {
                    _DesignBackgroundFill = new SolidColorBrush(DesignBackgroundColor);
                }

                return _DesignBackgroundFill;
            }
        }

        public InstanceColor DesignBackgroundColor { get; set; } = Colors.White;

        private SolidColorBrush _DesignOriginLineFill = Brushes.Black;

        /// <summary>
        /// Gets the brush to be used for drawing the origin lines
        /// </summary>
        [JsonIgnore()]
        public SolidColorBrush DesignOriginLineFill
        {
            get
            {
                if (_DesignOriginLineFill.Color != DesignOriginLineColor)
                {
                    _DesignOriginLineFill = new SolidColorBrush(DesignOriginLineColor);
                }

                return _DesignOriginLineFill;
            }
        }

        public InstanceColor DesignOriginLineColor { get; set; } = Colors.Black;

        private SolidColorBrush _DesignGridLineFill = Brushes.Gray;

        /// <summary>
        /// Gets the brush to be used for drawing the grid lines
        /// </summary>
        [JsonIgnore()]
        public SolidColorBrush DesignGridLineFill
        {
            get
            {
                if (_DesignGridLineFill.Color != DesignGridLineColor)
                {
                    _DesignGridLineFill = new SolidColorBrush(DesignGridLineColor);
                }

                return _DesignGridLineFill;
            }
        }

        public InstanceColor DesignGridLineColor { get; set; } = Colors.Gray;

        /// <summary>
        /// Clones an exact copy of this scene.
        /// </summary>
        /// <remarks>
        /// Snapshots are not copied and must be handled seperately if the data
        /// should persist.
        /// </remarks>
        /// <returns>An exact copy of this scene</returns>
        public object Clone()
        {
            Scene scene = new Scene();
            scene.Instances = scene.Instances.Select(instance => (Instance)instance.Clone()).ToList();
            scene.Name = Name;
            scene.FilePath = FilePath;
            scene.IsSaved = IsSaved;
            return scene;
        }  
    }
}
