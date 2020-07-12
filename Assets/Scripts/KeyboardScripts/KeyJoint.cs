using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace KeyboardScripts
{
    public class KeyJoint : MonoBehaviour
    {
        [SerializeField] private KeyboardKey _defaultKeyboardKey;
        private KeyCode _assignedKey = KeyCode.None;

        private void Start()
        {
            if (_defaultKeyboardKey != null)
            {
                _defaultKeyboardKey.DisableKey();
                _assignedKey = _defaultKeyboardKey.Key;
            }
        }

        public void NewKeyAssigned(KeyCode newKey)
        {
            _assignedKey = newKey;
            
            LetterPool.Instance.NewKeyJoined();
        }

        public void KeyPressed(InputAction.CallbackContext context)
        {
            if (_assignedKey == KeyCode.LeftShift)
            {
                if (context.started)
                {
                    TypingListener.Instance.ShiftPressed();
                }
                else if(context.performed)
                {
                    TypingListener.Instance.ShiftLifted();
                }
                
                return;
            }
            
            if (context.performed)
            {  
                Debug.Log("KEY PRESSED " + context.action.controls[0].name);
                if (_assignedKey != KeyCode.None)
                {
                    Debug.Log("KEY SENDED " + _assignedKey);
                    TypingListener.Instance.NewLetterTyped(_assignedKey);
                }
            }
        }
    }
}