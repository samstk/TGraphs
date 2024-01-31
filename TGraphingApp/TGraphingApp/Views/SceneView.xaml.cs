using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TGraphingApp.Services;

namespace TGraphingApp.Views
{
    /// <summary>
    /// Interaction logic for ExpressionView.xaml
    /// </summary>
    public partial class SceneView : UserControl
    {
        public Scene? Scene => DataContext as Scene;

        public SceneView()
        {
            InitializeComponent();
        }

        public void RefreshDataContext(Scene scene)
        {
            this.DataContext = null;
            this.DataContext = scene;

            ViewInstances.RefreshDataContext(Scene?.Instances);
        }

        private void DoNoteChange_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Scene == null) return; // Invalid scene

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
            MainWindow.App.RefreshGraph();
        }

        private void AllowNumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TGraphRegexExpressions.DecimalNumberCharacters.IsMatch(e.Text);
        }

        private void AllowNumbersOnly_EnforceLostFocus(object sender, RoutedEventArgs e)
        {
            // Must update binding
            try
            {

            }
            catch
            {
                // Reset to default value.
            }
        }
    }
}
