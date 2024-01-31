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
using TGraphingApp.Services;
using TGraphingApp.Views;

namespace TGraphingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow App { get; private set; }

        public Scene CurrentScene { get; set; } = new Scene();

        public string PreferredTitle
        {
            get
            {
                return $"TGraphing Application - '{CurrentScene.Name}' Scene - File '" +
                    (CurrentScene.FilePath != null ? CurrentScene.FilePath : "<unsaved>") +
                    "'" + (CurrentScene.IsSaved ? "" : " *");
            }
        }

        public MainWindow()
        {
            App = this;
            this.DataContext = this;
            InitializeComponent();
            RefreshAll();
        }

        /// <summary>
        /// Refreshes all trivia scene info (such as Window Title)
        /// </summary>
        public void RefreshTrivia()
        {
            GetBindingExpression(Window.TitleProperty).UpdateTarget();
        }

        /// <summary>
        /// Refreshes the data context.
        /// </summary>
        public void RefreshAll()
        {
            RefreshTrivia();
            DataContext = null;
            DataContext = this;
            ViewScene.RefreshDataContext(CurrentScene);
            RefreshGraph();
        }

        public void RefreshGraph()
        {
            ViewGraph.Refresh(CurrentScene);
        }


        #region Commands
        #region Scene (File)
        private void Command_DefaultExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewSceneCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentScene = new Scene();
            RefreshAll();
        }
        private void OpenSceneCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Scene? nextScene = SceneFileService.AskForSceneToOpen();
            if (nextScene != null)
            {
                CurrentScene = nextScene;
                RefreshAll();
            }
        }
        private void SaveSceneCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            if (CurrentScene.FilePath == null)
                SceneFileService.AskForSceneSave(CurrentScene);
            else SceneFileService.SaveScene(CurrentScene, CurrentScene.FilePath);
            RefreshTrivia();
        }
        private void SaveSceneAsCommand_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            SceneFileService.AskForSceneSave(CurrentScene);
        }
        #endregion

        #region View
        private void ScrollOut_Execute(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void ScrollIn_Execute(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion

        #endregion

        private void WindowInstance_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CurrentScene.IsSaved)
            {
                switch (MessageBox.Show(
                    "Do you wish to save the current scene? If not, all unsaved changes will be lost!", 
                    "Save?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning))
                {
                    case MessageBoxResult.Yes:
                        if (!SceneFileService.SaveScene(CurrentScene))
                            e.Cancel = true;
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }

    namespace Commands
    {
        public static class MainWindowCommands
        {
            public static readonly RoutedUICommand NewScene = new RoutedUICommand
                (
                    "NewScene",
                    "NewScene",
                    typeof(MainWindowCommands),
                    new InputGestureCollection()
                    {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                    }
                );

            public static readonly RoutedUICommand OpenScene = new RoutedUICommand
               (
                   "OpenScene",
                   "OpenScene",
                   typeof(MainWindowCommands),
                   new InputGestureCollection()
                   {
                    new KeyGesture(Key.O, ModifierKeys.Control)
                   }
               );

            public static readonly RoutedUICommand SaveScene = new RoutedUICommand
               (
                   "SaveScene",
                   "SaveScene",
                   typeof(MainWindowCommands),
                   new InputGestureCollection()
                   {
                    new KeyGesture(Key.S, ModifierKeys.Control)
                   }
               );

            public static readonly RoutedUICommand SaveSceneAs = new RoutedUICommand
               (
                   "SaveSceneAs",
                   "SaveSceneAs",
                   typeof(MainWindowCommands),
                   new InputGestureCollection()
                   {
                    new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Alt)
                   }
               );

            public static readonly RoutedUICommand ScrollIn = new RoutedUICommand
              (
                  "ScrollIn",
                  "ScrollIn",
                  typeof(MainWindowCommands),
                  new InputGestureCollection()
                  {
                      // Gesture to be handled seperately.
                  }
              );

            public static readonly RoutedUICommand ScrollOut = new RoutedUICommand
               (
                   "ScrollOut",
                   "ScrollOut",
                   typeof(MainWindowCommands),
                   new InputGestureCollection()
                   {
                        // Gesture to be handled seperately
                   }
               );

            public static readonly RoutedUICommand Redo = new RoutedUICommand
              (
                  "Redo",
                  "Redo",
                  typeof(MainWindowCommands),
                  new InputGestureCollection()
                  {
                      new KeyGesture(Key.Y, ModifierKeys.Control)
                  }
              );

            public static readonly RoutedUICommand Undo = new RoutedUICommand
               (
                   "Undo",
                   "Undo",
                   typeof(MainWindowCommands),
                   new InputGestureCollection()
                   {
                       new KeyGesture(Key.Z, ModifierKeys.Control)
                   }
               );
        }
    }
}
