﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class TableMouse : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    private void Update()
    {
        Vector2 posRelative = Mouse.current.position.ReadValue();
        posRelative.x /= Screen.width;
        posRelative.y /= Screen.height;

        Bounds bounds = _boxCollider.bounds;
        Vector3 vec = bounds.center;
        vec.x += bounds.extents.x;
        vec.z += bounds.extents.z;
        vec.y = transform.position.y;

        vec.x -= bounds.size.x * posRelative.x;
        vec.z -= bounds.size.z * posRelative.y;
        
        transform.position = vec;
    }
}
