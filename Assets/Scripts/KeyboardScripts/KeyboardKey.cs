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
        public KeyCode Key
        {
            get; private set;
        }

        private void SetKey(KeyCode key)
        {
            Key = key;
            _textMeshPro?.SetText(key.ToString());
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
                    DeactivateKeyAndGoToPosition(keyJoint.transform.position + _finalOffset);
                }
            }
        }

        private void DeactivateKeyAndGoToPosition(Vector3 transformPosition)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _mouseClicksDetector.Disable();
            StartCoroutine(GoToPosition(transformPosition));
        }

        private IEnumerator GoToPosition(Vector3 finalPosition)
        {
            while (Vector3.Distance(finalPosition, transform.position) > 0.1)
            {
                transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * _snapSpeed);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, _finalRotation, Time.deltaTime * _snapSpeed);
                yield return 0;
            }

            transform.position = finalPosition;
            transform.localRotation = _finalRotation;
        }
    }
}