using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float speed;

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

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
