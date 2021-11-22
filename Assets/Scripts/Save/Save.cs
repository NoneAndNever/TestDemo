using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName="Save",menuName ="gameData/Save")]
public class Save : ScriptableObject
{
    public int jumpSkill=2;//跳跃段数
    public int cherryNumber=0, gemNumber=0;//已获得的樱桃宝石
    public bool glide = false;//是否获得滑翔
    public bool dash = false;//是否习得冲刺
    public float MainWorldX=0, MainWorldY=0, MainWorldZ=0, Scene=1;//主世界的position
    public float PresentX, PresentY, PresentZ, PresentScene;//当前世界的position
    //public Text number;//存档编号
    //public Text time;//上次游玩时间
    //public Text CherryNum;//已获得的樱桃
    //public Text GemNum;//已获得的宝石

    

}
