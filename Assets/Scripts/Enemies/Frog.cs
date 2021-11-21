using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemies
{
    public Transform Lpoint, Rpoint;
    public LayerMask Ground;
    private float Lx, Rx;
    private float speed = 5.0f, jumpForce = 10.0f;
    private int moveDirection = -1;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Lx = Lpoint.position.x;
        Rx = Rpoint.position.x;
        Destroy(Lpoint.gameObject);
        Destroy(Rpoint.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }

    //在限定区域内移动
    void Movement()
    {
        if (transform.position.x < Lx)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            moveDirection = 1;

        }
        if (transform.position.x > Rx)
        {
            transform.localScale = new Vector3(1, 1, 1);
            moveDirection = -1;
        }
        if (col.IsTouchingLayers(Ground))
        {
            rb.velocity = new Vector2(speed * moveDirection, jumpForce);
            anim.SetBool("Jumping", true);
        }
    }


    //循环切换动画
    void SwitchAnim()
    {
        if (anim.GetBool("Jumping"))
        {
            if(rb.velocity.y < 0.1f)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        if (col.IsTouchingLayers(Ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling",false);
        }
    }
}
