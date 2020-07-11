using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{


    public void KeyPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {  
            Debug.Log("Y");
        }
    }
}