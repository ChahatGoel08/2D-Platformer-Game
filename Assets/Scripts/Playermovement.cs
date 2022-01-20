using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
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
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime, 0, 0);
        

        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        Debug.Log("Speed=" + speed);
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            Debug.Log("speed is less than zero");
        }
        else if (speed > 0)
        {
             scale.x = Mathf.Abs(scale.x);
            Debug.Log("speed is greater than zero");
        }
        transform.localScale = scale;


        //bool crouch = Input.GetKey(KeyCode.RightControl);
        //Vector3 scale = transform.localScale;
        //if (crouch == true)
        //{
          //  animator.SetBool("crouch", true);
           //scale.x = -1f * Mathf.Abs(scale.x);
        //}
        //else if (crouch == false)
        //{
          //  animator.SetBool("crouch", false);
            //scale.x = Mathf.Abs(scale.x);
        //}
        //transform.localScale = scale;

          float jump = Input.GetAxisRaw("Vertical");
          animator.SetFloat("jump", Mathf.Abs(jump));
          Vector3 scalee = transform.localScale;
          if (jump < 0)
          {
               scalee.x = -1f * Mathf.Abs(scalee.x);
           }
           else if (jump > 0)
           {
             scalee.x = Mathf.Abs(scalee.x);
           }
           transform.localScale = scalee;

        

    }
}

