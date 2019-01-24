using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float speed;
    public float jump;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        jump = 10F;


        Move();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
            canJump = false;
        }


    }

    void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = playerRigidBody.velocity;
        playerRigidBody.velocity = new Vector2(movementX * speed, currentVelocity.y);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Vector2 feetVector = new Vector2(this.transform.position.x, 
                this.transform.position.y - this.GetComponent<Collider2D>().bounds.extents.y);
            
            if (collision.GetContact(0).point.y < feetVector.y)
            {
                canJump = true;
            }

            
        }
    }


}


