using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5;
    private GameObject player;
    private bool facingRight;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        facingRight = player.GetComponent<PlayerController>().facingRight;

        if (facingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }
}
