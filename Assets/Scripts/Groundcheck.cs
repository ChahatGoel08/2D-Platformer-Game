using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
        Debug.Log("On ground");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        Debug.Log("not On ground");
    }
}
