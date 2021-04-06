using System.Collections.Generic;

namespace JSONReader
{
    public class GuiConstants
    {
        public const int INDENTATION_SIZE = 10;
        public const float KEYS_WIDTH_TO_SCREEN = 0.2f;
        public const float SMALL_BUTTON_WIDTH = 25;
        public const bool INITIAL_FOLDOUT_STATE = false;
        public const string LOCAL_PATH_START = "Assets";
        public const float GUI_COLOR_GRAY_PERCENTAGE = 0.8f;

        //--------- When changing this, DO NOT FORGET to update NOT_SUPPORTED_EXTENSION message below!
        public static readonly List<string> ALLOWED_TO_LOAD = new List<string> { ".txt", ".metadata", ".json" };

        public const string DEFAULT_FILE_NAME = "New JSON file";
        public const string DEFAULT_EXTENSION = "json";

        public const string BUTTON_LOAD_FROM_PROJECT = "Load from project";
        public const string BUTTON_LOAD_FROM_PROJECT_TOOLTIP = "Load selected file from project";
        public const string BUTTON_BROWSE = "Browse";
        public const string BUTTON_SAVE = "Save";
        public const string BUTTON_SAVE_AS = "Save As...";
        public const string BUTTON_IMPORT_TO_PROJECT = "Import file to project";
        public const string BUTTON_AS_STRING = "As String";
        public const string BUTTON_AS_NUMBER = "As Number";
        public const string BUTTON_AS_BOOL = "As Bool";
        public const string BUTTON_AS_ARRAY = "As Array";
        public const string BUTTON_UP = "▲";
        public const string BUTTON_DOWN = "▼";
        public const string BUTTON_REMOVE = "X";
        public const string BUTTON_ADD = "+";
        public const string BUTTON_OK = "Ok";
        public const string BUTTON_RAW_VIEW = "Switch to Raw view";
        public const string BUTTON_VISUAL_VIEW = "Switch to Visual representation";

        public const string CURRENT_LOADED = "Curent loaded: {0}";
        public const string NOT_SUPPORTED_EXTENSION = "Couldn't load  file {0} - only files with extensions *.TXT, *.JSON or *.METADATA supported";
        public const string ALREADY_IMPORTED = "Already in project!";
        public const string SELECT_FILE = "Select file";
        public const string NULL = "NULL";
        public const string OBJECT = "Object {0}";
        public const string ARRAY = "Array {0} - {1} items";

        public const string HEADER_OPEN_FILE_DIALOG = "Choose JSON file";
        public const string HEADER_SAVE_FILE_DIALOG = "Save As...";
        public const string HEADER_WINDOW = "JSON Reader / Editor";

        public const string ERROR_HEADER = "Invalid JSON data";
        public const string ERROR_MESSAGE = "Error parsing JSON";
    }
}