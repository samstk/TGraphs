using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TGraphingApp.Models;

namespace TGraphingApp.Services
{
    public static class SceneFileService
    {
        public const string FILE_FILTER = "Scene Files|*.scene";

        public static Scene? AskForSceneToOpen() {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Open Scene";
            opf.Filter = FILE_FILTER;
            opf.ShowDialog();

            return !string.IsNullOrEmpty(opf.FileName) 
                ? LoadScene(opf.FileName) : null;
        }

        /// <summary>
        /// Asks for the user to save the scene at a particular location.
        /// </summary>
        /// <param name="scene"></param>
        /// <returns>True if the file was saved</returns>
        public static bool AskForSceneSave(Scene scene)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Scene";
            sfd.Filter = FILE_FILTER;
            sfd.ShowDialog();

            if (!string.IsNullOrEmpty(sfd.FileName))
            {
                SaveScene(scene, sfd.FileName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads the scene from the given path.
        /// </summary>
        /// <param name="path">The path to load the scene from.</param>
        /// <returns>The scene loaded via the path</returns>
        public static Scene LoadScene(string path) {
            Scene? loadedScene = JsonSerializer.Deserialize<Scene>(
                JsonDocument.Parse(
                    File.ReadAllText(path)
                )
                );

            if (loadedScene == null)
                throw new JsonException($"Unable to read file '{path}'");

            loadedScene.FilePath = path;

            return loadedScene;
        }

        /// <summary>
        /// Saves the scene to the given path
        /// </summary>
        /// <param name="scene">The scene to save</param>
        /// <param name="path">
        /// The path to save the scene. 
        /// If null, then the path will be derived from the scene (or prompted for)
        /// </param>
        /// <returns>True if the file was saved</returns>
        public static bool SaveScene(Scene scene, string? path = null)
        {
            // Derive path from scene
            if (path == null)
                path = scene.FilePath;

            // Ask for the user for a valid path.
            if (path == null)
            {
                return AskForSceneSave(scene);
            }

            File.WriteAllText(
                path,
                JsonSerializer.Serialize<Scene>(scene)
                );

            scene.IsSaved = true;
            scene.FilePath = path;

            return true;
        }
    }
}
