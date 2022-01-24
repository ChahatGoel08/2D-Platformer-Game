using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
   public Animator animator;
    public float speed;
    public float jump;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);
        PlayJumpAnimation(vertical);
    }
    private void MoveCharacter(float horizontal)
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
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
    private void PlayJumpAnimation(float vertical)
    {
        animator.SetFloat("Jump", Mathf.Abs(vertical));
        Vector3 scale = transform.localScale;
        if (vertical < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (vertical > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }


}

