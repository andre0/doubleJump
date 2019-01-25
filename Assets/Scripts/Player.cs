using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject RedGemPrefab;
    public GameObject BlueGemPrefab;
    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;
    private float speed = 6f;
    private float jump = 11f;
    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerRigidBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
            //canJump = false;
            Jump();
        }

    }

    void Jump()
    {
        canJump = false;
        playerRigidBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    void Move()
    {
        float movementX = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = playerRigidBody.velocity;
        playerRigidBody.velocity = new Vector2(movementX * speed, currentVelocity.y);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BlueGem"))
        {
            Destroy(collider.gameObject);
            Vector2 spot = new Vector2(-2, -1.5F);
            Instantiate(RedGemPrefab, spot, Quaternion.identity);
        }

        if (collider.CompareTag("RedGem"))
        {
            Destroy(collider.gameObject);
            Vector2 second_spot = new Vector2(-17.61F, -1.36F);
            Instantiate(BlueGemPrefab, second_spot, Quaternion.identity);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Vector2 feetVector = new Vector2(this.transform.position.x, playerCollider.bounds.min.y);
            RaycastHit2D hit = Physics2D.Raycast(feetVector, Vector2.down, 0.1f);
       
            if (hit && hit.collider.CompareTag("Ground"))
            {
                canJump = true;
            }

            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //canJump = false;
        }
    }

}


