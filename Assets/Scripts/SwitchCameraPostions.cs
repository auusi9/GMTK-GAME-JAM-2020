using UnityEngine;

public class SwitchCameraPostions : MonoBehaviour
{
    [SerializeField] private Transform _keyboardPosition;
    [SerializeField] private Transform _screenPosition;
    [SerializeField] private float _velocity = 2f;

    private Transform _desiredTransform;
    
    private void Start()
    {
        _desiredTransform = _keyboardPosition;
    }

    public void GoToScreenPosition()
    {
        _desiredTransform = _screenPosition;
    }

    public void GoToKeyboardPosition()
    {
        _desiredTransform = _keyboardPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, _desiredTransform.position, Time.deltaTime * _velocity);
        transform.rotation = Quaternion.Slerp(transform.rotation, _desiredTransform.rotation, Time.deltaTime * _velocity);
    }
}