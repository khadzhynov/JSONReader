using System.IO;
using UnityEditor;
using UnityEngine;

namespace JSONReader
{
    public class JsonReaderFileUI
    {
        private IJsonReaderCore _jsonReaderCore;

        public JsonReaderFileUI(IJsonReaderCore jsonReaderCore)
        {
            _jsonReaderCore = jsonReaderCore;
        }

        public void DrawCurrentLoaded()
        {
            GUILayout.Label(string.Format(GuiConstants.CURRENT_LOADED, _jsonReaderCore.SelectedFilePath));
        }

        public void DrawLoadFromProject()
        {
            if (Selection.activeObject != null)
            {
                string path = AssetDatabase.GetAssetPath(Selection.activeObject);

                if (GuiConstants.ALLOWED_TO_LOAD.Contains(Path.GetExtension(path)))
                {
                    if (GUILayout.Button(
                        new GUIContent(
                            GuiConstants.BUTTON_LOAD_FROM_PROJECT,
                            GuiConstants.BUTTON_LOAD_FROM_PROJECT_TOOLTIP)))
                    {
                        if (Selection.activeObject is TextAsset textAsset)
                        {
                            _jsonReaderCore.ParseTextAsset(textAsset);
                        }
                        else
                        {
                            _jsonReaderCore.ParseTextFile(path);
                        }
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox(string.Format(GuiConstants.NOT_SUPPORTED_EXTENSION, path), MessageType.Warning);
                }
            }
        }

        public void DrawImportToProject()
        {
            if (_jsonReaderCore.SelectedFilePath != null && _jsonReaderCore.SelectedFilePath.Length > 0)
            {
                if (_jsonReaderCore.SelectedFilePath.Contains(Application.dataPath) ||
                    _jsonReaderCore.SelectedFilePath.StartsWith(GuiConstants.LOCAL_PATH_START))
                {
                    GUILayout.Label(GuiConstants.ALREADY_IMPORTED);
                }
                else
                {
                    if (GUILayout.Button(GuiConstants.BUTTON_IMPORT_TO_PROJECT))
                    {
                        _jsonReaderCore.ImportToProject();
                    }
                }
            }
            else
            {
                GUILayout.Label(GuiConstants.SELECT_FILE);
            }
        }

        public void DrawBrowseButton()
        {
            if (GUILayout.Button(GuiConstants.BUTTON_BROWSE))
            {
                string path = EditorUtility.OpenFilePanel(GuiConstants.HEADER_OPEN_FILE_DIALOG, string.Empty, string.Empty);

                if (!string.IsNullOrEmpty(path))
                {
                    _jsonReaderCore.ParseTextFile(path);
                }
            }
        }

        public void DrawSaveButton()
        {
            if (GUILayout.Button(GuiConstants.BUTTON_SAVE))
            {
                _jsonReaderCore.Save();
            }
        }

        public void DrawSaveAsButton()
        {
            if (GUILayout.Button(GuiConstants.BUTTON_SAVE_AS))
            {
                string path;
                if (_jsonReaderCore.SelectedFilePath.Length != 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(_jsonReaderCore.SelectedFilePath);
                    string directory = Path.GetDirectoryName(_jsonReaderCore.SelectedFilePath);
                    path = EditorUtility.SaveFilePanel(
                            GuiConstants.HEADER_SAVE_FILE_DIALOG,
                            directory,
                            fileName,
                            GuiConstants.DEFAULT_EXTENSION);
                }
                else
                {
                    path = EditorUtility.SaveFilePanel(
                            GuiConstants.HEADER_SAVE_FILE_DIALOG,
                            string.Empty,
                            GuiConstants.DEFAULT_FILE_NAME,
                            GuiConstants.DEFAULT_EXTENSION);
                }

                _jsonReaderCore.SaveAs(path);
            }
        }
    }
}