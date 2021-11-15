using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected Animator anim;
    protected Collider2D col;
    protected Rigidbody2D rb;
    protected AudioSource deathAudio;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void JumpOn()
    {
        deathAudio.Play();
        anim.SetTrigger("Death");
    }
}
