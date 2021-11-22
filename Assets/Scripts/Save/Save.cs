using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName="Save",menuName ="gameData/Save")]
public class Save : ScriptableObject
{
    public int jumpSkill=2;//��Ծ����
    public int cherryNumber=0, gemNumber=0;//�ѻ�õ�ӣ�ұ�ʯ
    public bool glide = false;//�Ƿ��û���
    public bool dash = false;//�Ƿ�ϰ�ó��
    public float MainWorldX=0, MainWorldY=0, MainWorldZ=0, Scene=1;//�������position
    public float PresentX, PresentY, PresentZ, PresentScene;//��ǰ�����position
    //public Text number;//�浵���
    //public Text time;//�ϴ�����ʱ��
    //public Text CherryNum;//�ѻ�õ�ӣ��
    //public Text GemNum;//�ѻ�õı�ʯ

    

}
