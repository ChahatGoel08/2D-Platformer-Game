using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player 3"))
        if (collision.gameObject.GetComponent<Playercontroller>() != null)
        {
            Debug.Log("Level is finished by player");
        }
    }

}
