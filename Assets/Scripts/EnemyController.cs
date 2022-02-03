using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private bool facingRight = false;
    public LayerMask layer;
    private float raycastDistance = 1f;
    public Transform enemytransform;
    public Transform endchecktransform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Playercontroller>() != null)
        {
            Playercontroller playercontroller = collision.gameObject.GetComponent<Playercontroller>();
            playercontroller.KillPlayer();
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        CheckTheEnd();
    }
    private void OnDrawGizmos()
    {
        Vector3 raycastend = new Vector3(endchecktransform.position.x, endchecktransform.position.y - raycastDistance, endchecktransform.position.z);
        Gizmos.DrawLine(endchecktransform.position, raycastend);
    }
    private void CheckTheEnd()
    {
        RaycastHit2D raycastHit2 = Physics2D.Raycast(endchecktransform.position, -endchecktransform.up, raycastDistance, layer);
        
        if(raycastHit2.collider == null)
        {
            Debug.Log(raycastHit2.collider);
            if (facingRight == false)
            {
                enemytransform.eulerAngles = new Vector3(0, 180, 0);
                facingRight = true;
            }
            else
            {
                
                enemytransform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = false;
            }
        }
    }
}
