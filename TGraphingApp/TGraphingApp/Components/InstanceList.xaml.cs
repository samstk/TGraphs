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
    /// Interaction logic for InstanceList.xaml
    /// </summary>
    public partial class InstanceList : UserControl
    {
        /// <summary>
        /// The instances referred to in this component.
        /// </summary>
        public List<Instance>? Instances => DataContext as List<Instance>;

        public InstanceList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Refreshes the list with a new list of instances.
        /// </summary>
        public void RefreshDataContext(List<Instance>? instances)
        {
            this.DataContext = null;
            this.DataContext = instances;
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (Instances == null)
                return; // Invalid instance list

            Instances.Add(new Instance());

            RefreshDataContext(Instances);
        }
    }
}
