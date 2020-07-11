using UnityEngine;
using UnityEngine.Events;

public class MouseClicksDetector : MonoBehaviour
{
        public UnityEvent MouseDown;
        public UnityEvent MouseUp;
        public UnityEvent MouseDrag;

        public void OnMouseUp()
        {
            MouseUp?.Invoke();
        }
        
        public void OnMouseDown()
        {
            MouseDown?.Invoke();
        }
        
        public void OnMouseDrag()
        {
            MouseDrag?.Invoke();
        }
}