using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Collider2D Vcol, Hcol;
    public LayerMask Ground;
    public Text CherryNum, GemNum;
    public Transform Cellingcheck;

    private Rigidbody2D rb;
    private Animator anim;
    private float speed = 320, jumpForce = 640;
    private int cherries = 0, gems = 0;


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
        Crouch();
        SwitchAnim();
    }


    //��Ծ
    //��Jumping��Ϊtrue
    //��Falling��Idle��Ϊfalse
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
            anim.SetBool("Idle", false);
        }
    }



    void FixedUpdate()
    {
        GroundMovement();

    }



    //ˮƽ�ƶ�
    //��ȡhorizontal����
    //����Running���
    //�����˶��������������
    //����ˮƽ�����������Զ�����
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
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.5f), rb.velocity.y);

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
        }
    }


    //��Ծ����
    //����Jumping��Falling��Idle��������
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
            anim.SetBool("Idle", true);
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



    //
    void Crouch()
    {
        
        if (Input.GetButton("Crouch"))
        {
            anim.SetBool("Crouching", true);
            Vcol.enabled = false;
            Hcol.enabled = true;
        }
        else if (!Physics2D.OverlapBox(Cellingcheck.position, new Vector2(0.2f, 0.4f), 90f, Ground))
        {

            anim.SetBool("Crouching", false);
            Vcol.enabled = true;
            Hcol.enabled = false;
        }
    }
}
