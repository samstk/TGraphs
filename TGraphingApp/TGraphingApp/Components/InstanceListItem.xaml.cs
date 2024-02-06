using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TGraphingApp.Models;

namespace TGraphingApp.Components
{
    /// <summary>
    /// Interaction logic for InstanceListItem.xaml
    /// </summary>
    public partial class InstanceListItem : UserControl
    {
        /// <summary>
        /// The instance list containing this item.
        /// </summary>
        public InstanceList? InstanceList => this.GetNearestAncestor<InstanceList>();
        
        /// <summary>
        /// The scene which contains the instances being viewed.
        /// </summary>
        public Scene? Scene => this.GetDataContextFromAncestors<Scene>();

        /// <summary>
        /// The instance being viewed.
        /// </summary>
        public Instance? Instance => DataContext as Instance;

        public InstanceListItem()
        {
            InitializeComponent();
            this.DataContextChanged += InstanceListItem_DataContextChanged;
        }

        private void InstanceListItem_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Instance == null) return; // Invalid instance
            PlotColor.Background = Instance.DesignFill;
        }

        private void InstanceName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Instance == null) return; // Invalid instance

            if (Scene == null) return; // Invalid scene

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
        }

        private void InstanceExpression_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Instance == null) return; // Invalid instance

            if (Scene == null) return; // Invalid scene

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
            MainWindow.App.RefreshGraph();
        }

        private void Design_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Instance == null) return; // Invalid instance

            if (Scene == null) return; // Invalid scene

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
            MainWindow.App.RefreshGraph();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Scene == null || Instance == null) return; // Invalid references

            Scene.Instances.Remove(Instance);

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();

            InstanceList?.RefreshDataContext(Scene.Instances);
        }

        private void PlotColor_Click(object sender, RoutedEventArgs e)
        {
            if (Instance == null) return; // Invalid instance.
            if (Scene == null) return; // Invalid scene

           
            System.Windows.Forms.ColorDialog pickColorDialog = new System.Windows.Forms.ColorDialog();
            pickColorDialog.Color = Instance.DesignColor;
            pickColorDialog.SolidColorOnly = true;

            if (pickColorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Instance.DesignColor = pickColorDialog.Color;

            PlotColor.Background = Instance.DesignFill;

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
            MainWindow.App.RefreshGraph();
        }
    }
}
