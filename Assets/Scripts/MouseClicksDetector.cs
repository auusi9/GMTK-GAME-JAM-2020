using UnityEngine;
using UnityEngine.Events;

public class MouseClicksDetector : MonoBehaviour
{
        public UnityEvent MouseDown;
        public UnityEvent MouseUp;
        public UnityEvent MouseDrag;

        private bool _enabled = true;

        public void OnMouseUp()
        {
            if (!_enabled)
            {
                return;
            }
            MouseUp?.Invoke();
        }
        
        public void OnMouseDown()
        {
            if (!_enabled)
            {
                return;
            }
            MouseDown?.Invoke();
        }
        
        public void OnMouseDrag()
        {
            if (!_enabled)
            {
                return;
            }
            MouseDrag?.Invoke();
        }

        public void Disable()
        {
            _enabled = false;
        }
}