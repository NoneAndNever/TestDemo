using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Collider2D Vcol, Hcol;
    public LayerMask Ground,Enemies;
    public Text CherryNum, GemNum;
    public Transform Cellingcheck,Feetcheck;

    private Rigidbody2D rb;
    private Animator anim;
    private float speed = 320, jumpForce = 640;
    private int cherries = 0, gems = 0;
    private bool isHurting,isCrouching,isGround;
    private int jumpTimes = 2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCrouching)
            Jump();
        Crouch();
        SwitchAnim();
    }


    //��Ծ
    //��Jumping��Ϊtrue
    //��Falling��Ϊfalse
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpTimes > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
            jumpTimes--;
        }
        if (Vcol.IsTouchingLayers(Ground)&& (!anim.GetBool("Jumping")) && (!anim.GetBool("Falling")))
        {
            jumpTimes = 2;
        }
    }


    //����
    //��ס�����ɿ�ս��
    //��ͷ��������ɿ��������ֶ��£�ֱ��ͷ�����ϰ�
    void Crouch()
    {

        if (Input.GetButton("Crouch"))
        {
            anim.SetBool("Crouching", true);
            Vcol.enabled = false;
            Hcol.enabled = true;
            isCrouching = true;
        }
        else if (!Physics2D.OverlapBox(Cellingcheck.position, new Vector2(0.2f, 0.4f), 90f, Ground))
        {

            anim.SetBool("Crouching", false);
            Vcol.enabled = true;
            Hcol.enabled = false;
            isCrouching = false;
        }
    }




    //�л�����
    //����Jumping��Falling��������
    void SwitchAnim()
    {
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }
        else if (Vcol.IsTouchingLayers(Ground))
        {
            anim.SetBool("Falling", false);
            isGround = true;
        }
        if(rb.velocity.y < -2f )
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
    }


    void FixedUpdate()
    {
        if (!isHurting)
        {
            GroundMovement();
        }
    }






    //ˮƽ�ƶ�
    //��ȡhorizontal����
    //����Running���
    //�����˶��������������
    void GroundMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("Running", Mathf.Abs(faceDirection));
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.5f), rb.velocity.y);
        }

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
        }

    }

    //�ռ�ӣ����ʯ
    //��ȡ��ײ��tag��Ϣ�����ռ�Ʒ����
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

    //�������or�ܵ��˺�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enermies")
        {
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            if (Physics2D.OverlapBox(Feetcheck.position, new Vector2(0.4f, 0.6f), 90f, Enemies))
            {
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            }
            else
            {
                anim.SetBool("Hurting", true);
                isHurting = true;
                rb.velocity = new Vector2(-10f * transform.localScale.x , rb.velocity.y);
            }
        }
    }
}
