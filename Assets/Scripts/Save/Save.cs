using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName="Save",menuName ="gameData/Save")]
public class Save : ScriptableObject
{
    //public Text number;//�浵���
    //public Text time;//�ϴ�����ʱ��
    public int jumpSkill;//��Ծ����
    public int cherryNumber, gemNumber;//�ѻ�õ�ӣ�ұ�ʯ
    public bool glide = false;//�Ƿ��û���
    public bool dash = false;//�Ƿ�ϰ�ó��
    //public Text CherryNum;//�ѻ�õ�ӣ��
    //public Text GemNum;//�ѻ�õı�ʯ
    public double MainWorldX, MainWorldY, MainWorldZ, Scene;//�������position
    public double PresentX, PresentY, PresentZ, PresentScene;//��ǰ�����position

}
