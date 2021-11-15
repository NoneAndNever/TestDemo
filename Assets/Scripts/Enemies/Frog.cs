using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemies
{
    public Transform Lpoint, Rpoint;
    public LayerMask Ground;
    private float Lx, Rx;
    private bool FaceLeft;
    private float speed = 5.0f, jumpForce = 10.0f;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Lx = Lpoint.position.x;
        Rx = Rpoint.position.x;
        Destroy(Lpoint.gameObject);
        Destroy(Rpoint.gameObject);
        FaceLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }

    //���޶��������ƶ�
    void Movement()
    {
        if (FaceLeft)
        {
            if (col.IsTouchingLayers(Ground))
            {
                rb.velocity = new Vector2(-speed, jumpForce);
                anim.SetBool("Jumping", true);
            }
            if(transform.position.x < Lx)
            {
                transform.localScale = new Vector3(-1,1,1);
                FaceLeft = false;
            }
        }
        else
        {
            if (col.IsTouchingLayers(Ground))
            {
                rb.velocity = new Vector2(speed, jumpForce);
                anim.SetBool("Jumping", true);
            }
            if (transform.position.x > Rx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                FaceLeft = true;
            }
        }
    }


    //ѭ���л�����
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
