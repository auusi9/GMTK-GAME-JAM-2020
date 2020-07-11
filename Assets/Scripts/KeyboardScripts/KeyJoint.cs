using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace KeyboardScripts
{
    public class KeyJoint : MonoBehaviour
    {
        [SerializeField] private KeyboardKey _defaultKeyboardKey;
        private KeyCode _assignedKey;

        private void Start()
        {
            if (_defaultKeyboardKey != null)
            {
                _assignedKey = _defaultKeyboardKey.Key;
            }
        }

        public void NewKeyAssigned(KeyCode newKey)
        {
            _assignedKey = newKey;
        }

        public void KeyPressed()
        {
            
        }
    }
}