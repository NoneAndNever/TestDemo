using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed, jumpForce;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }




    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce * Time.fixedDeltaTime);
        }
    }



    void FixedUpdate()
    {
        GroundMovement();

    }


    void GroundMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");

        

        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("Running", Mathf.Abs(faceDirection));
        }

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection,1,1);
        }
    }


}
