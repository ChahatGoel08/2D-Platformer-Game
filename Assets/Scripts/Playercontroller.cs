using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rgbd;
    public Groundcheck groundcheck;

    private void Awake()
    {
        Debug.Log("Player controller Awake");
        rgbd = this.gameObject.GetComponent<Rigidbody2D>();
    }

    internal void KillPlayer()
    {
        Debug.Log("Player is killed by enemy");
        Destroy(gameObject);
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //Debug.Log("Collision:" + collision.gameObject.name);
    //}
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        MoveCharacter(horizontal, jump);
        PlayMovementAnimation(horizontal);
        PlayJumpAnimation(jump);
    }
    private void MoveCharacter(float horizontal, float jump)
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if(jump>0 && groundcheck.isGrounded == true)
        {
            //rgbd.velocity = new Vector2(rgbd.velocity.x, jump);
            
           rgbd.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
     }
    private void PlayJumpAnimation(float jump)
    {
        animator.SetFloat("Jump", Mathf.Abs(jump));
        Vector3 scale = transform.localScale;
        if (jump < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (jump > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
   
}

