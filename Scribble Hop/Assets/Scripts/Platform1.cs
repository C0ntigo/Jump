using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform1 : MonoBehaviour
{
    public float jumpForce = 10f;
    private Transform Player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
     void Update()
    {
        if (Player != null && transform.position.y < Player.position.y - 10f)
        {
            Destroy(gameObject);
        }     
    }
     void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;    
    }
}
