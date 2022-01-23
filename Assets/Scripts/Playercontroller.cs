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
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharacter(horizontal);
        PlayMovementAnimation(horizontal);
    }
    private void MoveCharacter(float horizontal)
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
    private void PlayMovementAnimation(float horizontal)
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
     }

}

