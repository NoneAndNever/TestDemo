using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerController player;
    public Collider2D Vcol, Hcol;
    public LayerMask Ground,Enemies;
    public Text CherryNum, GemNum;
    public Transform CellingCheck,FeetCheck;

    //public AudioSource jumpAudio,cherryAudio,gemAudio;
    [Header("Dash����")]
    private float dashTime=0.2f;//���ʱ��
    private float dashTimeLeft;//ʣ����ʱ��
    private float lastDash=-10f;//�ϴγ��ʱ��
    private float dashCoolDown=3f;//���CD
    private float dashSpeed=30;//����ٶ�

    

    private Rigidbody2D rb;
    private Animator anim;
    private float speed = 320, jumpForce = 640;
    private int cherries = 0, gems = 0;
    private bool isHurting,isCrouching,isGround,isDashing;
    private int jumpTimes = 2,jumpSkill=2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        player = this;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        if (!isCrouching && !isHurting)
            Jump();
        Crouch();
        SwitchAnim();
        isGround = Physics2D.OverlapCircle(FeetCheck.position, 0.2f, Ground);

        ReadyToDash();

        glide();

    }


    void glide()
    {
        if (Input.GetButton("Glide") && rb.velocity.y < 0)
        {
            rb.gravityScale = 0.2f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void ReadyToDash()
    {
        if (Input.GetKeyDown(KeyCode.C) && Time.time > lastDash + dashCoolDown)
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            lastDash = Time.time;
        }
    }

    void Dash()
    {
        if (isDashing )
        {
            if (dashTimeLeft > 0)
            {
                if (!isHurting)
                {
                    rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);
                }
                dashTimeLeft -= Time.deltaTime;
                ShadowPool.instance.GetFromPool();
            }
            else
            {
                isDashing=false;
            }
        }
    }

    //��Ծ
    //��Jumping��Ϊtrue
    //��Falling��Ϊfalse
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpTimes > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            SoundManager.Sound.JumpAudio();
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
            jumpTimes--;
        }
        if (isGround && (!anim.GetBool("Jumping")) && (!anim.GetBool("Falling")))
        {
            jumpTimes = jumpSkill;
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
        else if (!Physics2D.OverlapBox(CellingCheck.position, new Vector2(0.2f, 0.4f), 90f, Ground))
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
        if (isDashing)
            return;
        if (!isHurting)
        {
            GroundMovement();
        }
        else
        {
            Invoke("StopHurting", 0.2f);
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
    //��ȡ������
    //��ȡ�����л�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cherry")
        {
            Destroy(collision.gameObject);
            SoundManager.Sound.CherryAudio();
            cherries++;
            CherryNum.text = cherries.ToString();
        }

        if (collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
            SoundManager.Sound.GemAudio();
            gems++;
            GemNum.text = gems.ToString();
        }

        if (collision.tag == "Deadline")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("ReStart", 1.0f);
        }

    }

    //�������or�ܵ��˺�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enermies")
        {
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            if (Physics2D.OverlapBox(FeetCheck.position, new Vector2(0.4f, 0.6f), 90f, Enemies))
            {
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
                jumpTimes=jumpSkill-1;
            }
            else
            {
                anim.SetBool("Hurting", true);
                isHurting = true;
                if (rb.position.x < collision.transform.position.x)
                {
                    rb.velocity = new Vector2(-5.0f, jumpForce * Time.fixedDeltaTime);
                }
                else
                {
                    rb.velocity = new Vector2(5.0f, jumpForce * Time.fixedDeltaTime);
                }
            }
        }
    }


    //�����Ϳ�
    void StopHurting()
    {
        if (Vcol.IsTouchingLayers(Ground))
        {
            anim.SetBool("Hurting", false);
            isHurting = false;
        }
    }


    //����
    void ReStart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
