using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
   public Animator animator;
    private void Awake()
    {
        Debug.Log("Player controller Awake");
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
     //Debug.Log("Collision:" + collision.gameObject.name);
    //}
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(speed > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;


        bool crouch = Input.GetKeyDown(KeyCode.RightControl);
        Vector3 scalee = transform.localScale;
        if (crouch == true)
        {
            animator.SetBool("Crouch", true);
        }
        else if (crouch == false)
        {
            animator.SetBool("Crouch", false);
        }
        transform.localScale = scalee;

    }
}

