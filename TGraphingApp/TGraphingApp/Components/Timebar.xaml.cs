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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TGraphingApp.Models;

namespace TGraphingApp.Components
{
    /// <summary>
    /// Interaction logic for Timebar.xaml
    /// </summary>
    public partial class Timebar : UserControl
    {
        public Scene? Scene => DataContext as Scene;

        public bool IsPlaying = false;

        public Timebar()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private DateTime TimeSinceLastStep = DateTime.Now;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (Scene != null)
            {
                // Update graph and step.
                if (IsPlaying)
                {
                    double time = (DateTime.Now - TimeSinceLastStep).TotalSeconds;
                    TimeSinceLastStep = DateTime.Now;
                    double increment = time * (Scene.TStep);
                    if (Scene.TMax < Scene.TMin)
                    {
                        Scene.TCurrentValue -= increment;
                        if (Scene.TCurrentValue < Scene.TMin)
                            Scene.TCurrentValue = Scene.TMax;
                    }
                    else
                    {
                        Scene.TCurrentValue += increment;
                        if (Scene.TCurrentValue > Scene.TMax)
                            Scene.TCurrentValue = Scene.TMin;
                    }
                    
                    MainWindow.App.RefreshGraph();
                }

                // Update progressbar
                double progress = 0.0;

                if (Scene.TMax - Scene.TMin != 0)
                    progress = (Scene.TCurrentValue - Scene.TMin) / (Scene.TMax - Scene.TMin);

                if (progress < 0)
                    progress = 0;
                if (progress > 1)
                    progress = 1;

                PlayProgress.Value = 100.0 * progress;
            }
        }

        public DispatcherTimer Timer { get; set; }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSinceLastStep = DateTime.Now;
            IsPlaying = !IsPlaying;
            if (IsPlaying)
                PlayPauseButton.Content = "Pause";
            else PlayPauseButton.Content = "Play";
        }

        private void DoNoteChange_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Scene == null) return; // Invalid scene

            Scene.IsSaved = false;
            MainWindow.App.RefreshTrivia();
            MainWindow.App.RefreshGraph();
        }

        public void RefreshDataContext(Scene scene)
        {
            this.DataContext = null;
            this.DataContext = scene;
        }
    }
}
