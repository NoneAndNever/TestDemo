using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D col;
    public LayerMask Ground;
    public float speed, jumpForce;
    public int cherries = 0,gems=0;
    public Text CherryNum, GemNum;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        SwitchAnim();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", false);
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
    void SwitchAnim()
    {
        if (anim.GetBool("Jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        else if (col.IsTouchingLayers(Ground))
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cherry")
        {
            Destroy(collision.gameObject);
            cherries++;
            CherryNum.text = cherries.ToString();
        }

        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            gems++;
            GemNum.text = gems.ToString();
        }
    }

}
