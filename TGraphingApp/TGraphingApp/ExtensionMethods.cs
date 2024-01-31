using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TGraphingApp
{
    /// <summary>
    /// Extension methods for the app.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Gets the nearest data context of given return type from the ancestors of this control.
        /// </summary>
        /// <typeparam name="SearchType">The type to search for</typeparam>
        /// <param name="control">The element to start searching the parents from</param>
        /// <returns>If any exists, the data context with the given type, else the default value of the type</returns>
        public static SearchType? GetDataContextFromAncestors<SearchType>(this DependencyObject control)
        {
            DependencyObject? parent = VisualTreeHelper.GetParent(control);

            while (parent != null)
            {
                object context = parent.GetValue(Control.DataContextProperty);
                if (context is SearchType)
                {
                    return (SearchType)context;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return default(SearchType);
        }

        /// <summary>
        /// Gets the nearest ancestor of given type from the ancestors of this control.
        /// </summary>
        /// <typeparam name="SearchType">The type to search for</typeparam>
        /// <param name="control">The element to start searching the parents from</param>
        /// <returns>If any exists, the object with the given type, else null</returns>
        public static SearchType? GetNearestAncestor<SearchType>(this DependencyObject control)
            where SearchType : DependencyObject
        {
            DependencyObject? parent = VisualTreeHelper.GetParent(control);

            while (parent != null)
            {
                if (parent is SearchType)
                {
                    return (SearchType)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}
