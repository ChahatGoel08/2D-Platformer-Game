using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallCheckCollider : MonoBehaviour
{
    public new GameObject gameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Playercontroller>() != null)
        {
            //Debug.Log("Player has fallen and going to its starting position");
            SceneManager.LoadScene("animation");
        }
    }
}
