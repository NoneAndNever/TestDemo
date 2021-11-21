using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("时间控制参数")]
    private float activeTime=0.3f;
    private float startTime;

    [Header("不透明度控制")]
    private float alpha;
    private float alphaSet=0.9f;
    private float alphaMultiplier=0.75f;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        thisSprite.sprite = playerSprite.sprite;

        alpha = alphaSet;

        transform.localScale = playerSprite.transform.localScale;
        transform.position = playerSprite.transform.position;
        transform.rotation = playerSprite.transform.rotation;

        startTime = Time.time;

    }
    void Update()
    {
        alpha*=alphaMultiplier;

        color=new Color(0.75f,0.75f,1,alpha);

        thisSprite.color = color;

        if (Time.time > startTime + activeTime)
        {
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
