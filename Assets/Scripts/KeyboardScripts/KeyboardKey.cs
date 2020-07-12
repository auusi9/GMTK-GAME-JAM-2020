using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeyboardScripts
{
    public class KeyboardKey : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMeshPro;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MouseClicksDetector _mouseClicksDetector;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Quaternion _finalRotation;
        [SerializeField] private Vector3 _finalOffset;
        [SerializeField] private float _snapSpeed = 1f;
        [SerializeField] private KeyCode _defaultKey = KeyCode.None;
        
        public KeyCode Key
        {
            get { return _defaultKey; } 
        }

        public void SetKey(KeyCode key)
        {
            _defaultKey = key;
            _textMeshPro?.SetText(KeyCodeToString(key));
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
                    return "Alt";
                case KeyCode.LeftControl:
                    return "Ctrl";
                case KeyCode.LeftShift:
                    return "Shift";
                case KeyCode.Backspace:
                    return "<--";
                case KeyCode.Semicolon:
                    return ";";
                default:
                    return key.ToString();

            }
            return key.ToString();         
        }

        public void OnMouseUp()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if(Physics.Raycast(ray, out hit, 100, _layerMask))
            {
                KeyJoint keyJoint = hit.collider.GetComponent<KeyJoint>();
                if (keyJoint != null)
                {
                    keyJoint.NewKeyAssigned(Key);
                    transform.SetParent(keyJoint.transform, true);
                    DeactivateKeyAndGoToPosition(_finalOffset);
                }
            }
        }

        private void DeactivateKeyAndGoToPosition(Vector3 transformPosition)
        {
            DisableKey();
            StartCoroutine(GoToPosition(transformPosition));
        }

        public void DisableKey()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _mouseClicksDetector.Disable();
        }

        private IEnumerator GoToPosition(Vector3 finalPosition)
        {
            while (Vector3.Distance(finalPosition, transform.localPosition) > 0.01)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition, Time.deltaTime * _snapSpeed);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, _finalRotation, Time.deltaTime * _snapSpeed);
                yield return 0;
            }

            transform.localPosition = finalPosition;
            transform.localRotation = _finalRotation;
        }
    }
}