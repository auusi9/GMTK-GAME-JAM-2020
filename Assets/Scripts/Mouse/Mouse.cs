using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    private void Update()
    {
        Vector2 posRelative = Input.mousePosition;
        posRelative.x /= Screen.width;
        posRelative.y /= Screen.height;

        Bounds bounds = _boxCollider.bounds;
        Vector3 vec = bounds.center;
        vec.x += bounds.extents.x;
        vec.z += bounds.extents.z;

        vec.x -= bounds.size.x * posRelative.x;
        vec.z -= bounds.size.z * posRelative.y;

        Debug.Log(posRelative);
        
        transform.position = vec;
    }
}
