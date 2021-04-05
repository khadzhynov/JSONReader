using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace JSONReader
{
    /// <summary>
    /// Its just a test task, in real life I would not spend any time, but use existing tool:
    /// https://assetstore.unity.com/packages/tools/visual-scripting/json-editor-83688
    /// </summary>
    public class JsonReader : EditorWindow
    {
        private JsonReaderCore _jsonReaderCore;
        private JsonReaderFileUI _fileUI;
        private JsonStructureUI _jsonStructureUI;
        private TextRawView _textRawView;

        private Queue<IJSONNodeOperation> _pendingOperations = new Queue<IJSONNodeOperation>();

        private bool _isVisualView = true;

        private void OnEnable()
        {
            _jsonReaderCore = new JsonReaderCore();
            _fileUI = new JsonReaderFileUI(_jsonReaderCore);
            _jsonStructureUI = new JsonStructureUI(position.width * GuiConstants.KEYS_WIDTH_TO_SCREEN, _pendingOperations);
            _textRawView = new TextRawView();

            _jsonReaderCore.OnParsingError += ParsingErrorHandler;
        }

        private void OnDisable()
        {
            _jsonReaderCore.OnParsingError -= ParsingErrorHandler;
        }

        private void ParsingErrorHandler()
        {
            EditorUtility.DisplayDialog(GuiConstants.ERROR_HEADER, GuiConstants.ERROR_MESSAGE, GuiConstants.BUTTON_OK);
        }

        [MenuItem("Tools/JSON Reader")]
        public static void ShowWindow()
        {
            JsonReader window = (JsonReader)EditorWindow.GetWindow(typeof(JsonReader), true, GuiConstants.HEADER_WINDOW);
            window.Show();
        }

        private void OnSelectionChange()
        {
            Repaint();
        }

        private void OnGUI()
        {
            _fileUI.DrawCurrentLoaded();

            _fileUI.DrawLoadFromProject();

            _fileUI.DrawImportToProject();

            _fileUI.DrawBrowseButton();

            _fileUI.DrawSaveButton();

            _fileUI.DrawSaveAsButton();

            GUILayout.Space(20);

            if (_jsonReaderCore.RootNode != null)
            {
                if (DrawVisualRawSwitch())
                {
                    DrawVisualView();
                }
                else
                {
                    _textRawView.DrawTextRawView();
                }
            }
        }

        private void DrawVisualView()
        {
            _jsonStructureUI.DrawJSONStructure(_jsonReaderCore.RootNode);

            while (_pendingOperations.Count > 0)
            {
                _pendingOperations.Dequeue().Execute();
            }
        }

        private bool DrawVisualRawSwitch()
        {
            if (_isVisualView)
            {
                if (GUILayout.Button(GuiConstants.BUTTON_RAW_VIEW))
                {
                    _isVisualView = false;
                    _textRawView.Text = _jsonReaderCore.RootNode.ToString(GuiConstants.INDENTATION_SIZE);
                }
            }
            else
            {
                if (GUILayout.Button(GuiConstants.BUTTON_VISUAL_VIEW))
                {
                    _isVisualView = true;
                    _jsonReaderCore.ParseString(_textRawView.Text);
                }
            }
            return _isVisualView;
        }
    }

    public class TextRawView
    {
        private string _text;
        private Vector2 _scrollPos;

        public string Text { get => _text; set => _text = value; }

        public void DrawTextRawView()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            _text = GUILayout.TextArea(_text, GUILayout.ExpandHeight(true));

            EditorGUILayout.EndScrollView();
        }
    }
}