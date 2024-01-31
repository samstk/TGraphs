using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TGraphingApp
{
    public static class TGraphMath
    {
        /// <summary>
        /// Calculates the relative position (% of min-max) of a particular value.
        /// </summary>
        /// <param name="value">The value to calculate</param>
        /// <param name="betweenMin">The minimum value (0%)</param>
        /// <param name="betweenMax">The maximum value (100%)</param>
        /// <returns></returns>
        public static double CalculatePositionBetweenPoints(double value, double betweenMin, double betweenMax)
        {
            double adjustedValue = value - betweenMin;
            double adjustedMax = betweenMax - betweenMin;

            if (adjustedMax == 0) return adjustedValue < 0 ? 0 : 1;

            return adjustedValue / adjustedMax;
        }

        /// <summary>
        /// Calculates the actual position of a particular value.
        /// </summary>
        /// <param name="valueX">The value to calculate for the x-axis</param>
        /// <param name="valueY">The value to calculate for the y-axis</param>
        /// <param name="betweenMinX">The minimum value for the x-axis (0%)</param>
        /// <param name="betweenMaxX">The maximum value for the x-axis (100%)</param>
        /// <param name="betweenMinY">The minimum value for the y-axis (0%)</param>
        /// <param name="betweenMaxY">The maximum value for the y-axis (100%)</param>
        /// <param name="width">The width to adjust the value to</param>
        /// <param name="height">The height to adjust the value to</param>
        /// <returns>The actual position on screen for the point</returns>
        public static Point CalculateActualPositionOfValuesBetweenPoints(double valueX, double valueY, 
            double betweenMinX, double betweenMaxX, double betweenMinY, double betweenMaxY, double width, double height)
        {
            return new Point(
                    (int)(CalculatePositionBetweenPoints(valueX, betweenMinX, betweenMaxX) * width),
                    (int)(CalculatePositionBetweenPoints(valueY, betweenMinY, betweenMaxY) * height)
                );
        }
    }
}
