using UnityEngine;

namespace Objects
{
    public class DraggableObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LayerMask _collideLayerMask;
        [SerializeField] private float _defaultY;
        
        private Vector3 _mouseOffset;
        private float _mouseZCoord;

        private Camera _camera;

        private void Start()
        {
            Vector3 vec = transform.position;
            vec.y = _defaultY;
            _camera = Camera.main;
            _mouseZCoord = _camera.WorldToScreenPoint(vec).z;

        }

        void OnMouseDown()
        {
            _rigidbody.useGravity = false;
            _mouseOffset = transform.position - GetMouseContactPointWithObjects();
        }

        private Vector3 GetMouseContactPointWithObjects()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _mouseZCoord;
            
            Vector3 origin = _camera.transform.position;
            Vector3 direction = _camera.ScreenToWorldPoint(mousePoint) - origin;

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, 100, _collideLayerMask))
            {
                return hit.point;
            }
            
            return direction + origin;
        }

        void OnMouseDrag()
        {                
            transform.position = AddYOffset(GetMouseContactPointWithObjects()) + _mouseOffset;
        }

        private Vector3 AddYOffset(Vector3 vec)
        {
            Vector3 returnVec = vec;
            returnVec.y = _defaultY;
            return returnVec;
        }

        private void OnMouseUp()
        {
            _rigidbody.useGravity = true;
        }
    }
}