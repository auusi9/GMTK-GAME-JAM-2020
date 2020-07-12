using UnityEngine;
using UnityEngine.Events;

namespace KeyboardScripts
{
    public class TypingListener : MonoBehaviour
    {
        public UnityAction<string> NewLetter;
        public static TypingListener Instance;
        private bool _shiftPressed;

        private void Awake()
        {
            Instance = this;
        }

        public void NewLetterTyped(KeyCode letter)
        {
            string letterStr = KeyCodeToString(letter);

            if (!string.IsNullOrEmpty(letterStr))
            {
                if (_shiftPressed)
                {
                    letterStr = letterStr.ToUpper();
                }
                else
                {
                    letterStr = letterStr.ToLower();
                }
                NewLetter?.Invoke(letterStr);
            }
        }

        public void ShiftPressed()
        {
            _shiftPressed = true;
        }

        public void ShiftLifted()
        {
            _shiftPressed = false;
        }

        private static string KeyCodeToString(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.Keypad0:
                    return "0";
                case KeyCode.Keypad1:
                    return "1";
                case KeyCode.Keypad2:
                    return "2";
                case KeyCode.Keypad3:
                    return "3";
                case KeyCode.Keypad4:
                    return "4";
                case KeyCode.Keypad5:
                    return "5";
                case KeyCode.Keypad6:
                    return "6";
                case KeyCode.Keypad7:
                    return "7";
                case KeyCode.Keypad8:
                    return "8";
                case KeyCode.Keypad9:
                    return "9";
                case KeyCode.Period:
                    return ".";
                case KeyCode.Comma:
                    return ",";
                case KeyCode.LeftAlt:
                    return "";
                case KeyCode.LeftControl:
                    return "";
                case KeyCode.LeftShift:
                    return "";
                case KeyCode.Backspace:
                    return "";
                case KeyCode.Semicolon:
                    return ";";
                default:
                    return key.ToString();
            }
        }
    }
}