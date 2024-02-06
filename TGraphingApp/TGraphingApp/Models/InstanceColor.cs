using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TGraphingApp.Models
{
    [Serializable]
    /// <summary>
    /// A simple RGB color used in an instance.
    /// </summary>
    public sealed class InstanceColor
    {
        public byte R { get; set; }
        public byte G { get; set; }

        public byte B { get; set; }

        /// <summary>
        /// The common color representation of this color.
        /// </summary>
        [JsonIgnore()]
        public Color CommonColor
        {
            get
            {
                return Color.FromArgb(255, R, G, B);
            }
        }

        public InstanceColor() { }

        public InstanceColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static implicit operator InstanceColor(Color color) => new InstanceColor(
            color.R, color.G, color.B
            );

        public static implicit operator InstanceColor(System.Drawing.Color color) => new InstanceColor(
             color.R, color.G, color.B
            );

        public static implicit operator Color(InstanceColor color) => color.CommonColor;

        public static implicit operator System.Drawing.Color(InstanceColor color) =>
            System.Drawing.Color.FromArgb(color.R, color.G, color.B);
    }
}
