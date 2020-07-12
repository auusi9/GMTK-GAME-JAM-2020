using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyboardScripts;

public class RespawnFallenKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.transform.position = LetterPool.Instance.transform.position;
    }
}
