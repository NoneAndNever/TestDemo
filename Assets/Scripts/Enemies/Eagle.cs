using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemies
{
    public Transform Toppoint, Botpoint;


    private bool ReachTop;
    private float Topy, Boty;
    private float speed = 5.0f;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Topy = Toppoint.position.y;
        Boty = Botpoint.position.y;
        Destroy(Toppoint.gameObject);
        Destroy(Botpoint.gameObject);
        ReachTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    //在限定区域内上下移动
    void Movement()
    {
        if (ReachTop)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > Topy)
            {
                ReachTop = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < Boty)
            {
                ReachTop = true;
            }
        }
    }
}
