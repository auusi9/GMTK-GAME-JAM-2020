using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectMouseClicks : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;
    private List<MouseClicksDetector> _mouseClicks = new List<MouseClicksDetector>();
    
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnMouseDown();
        }
            
        if (Mouse.current.leftButton.isPressed)
        {
            OnMouseDrag();
        }
            
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            OnMouseUp();
        }
    }

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out hit, 100, _layerMask))
        {
            MouseClicksDetector detector = hit.collider.GetComponent<MouseClicksDetector>();
            if (detector != null)
            {
                detector.OnMouseDown();
                _mouseClicks.Add(detector);
            }
        }
    }

    private void OnMouseDrag()
    {
        foreach (var mouseClick in _mouseClicks)
        {
            mouseClick.OnMouseDrag();
        }
    }

    private void OnMouseUp()
    {
        foreach (var mouseClick in _mouseClicks)
        {
            mouseClick.OnMouseUp();
        }
        
        _mouseClicks.Clear();
    }
}