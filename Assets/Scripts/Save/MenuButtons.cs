using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MenuButtons : MonoBehaviour
{

    public void Create(string file_path, string file_name, string str_info)
    {
        StreamWriter sw;
        if (File.Exists(file_path + "//" + file_name))
        {
            File.Delete(file_path + "//" + file_name);
            //sw = File.AppendText(file_path + "//" + file_name);//������ UTF-8 �����ı��ļ��Խ��ж�ȡ
        }
        sw = File.CreateText(file_path + "//" + file_name);//����һ������д�� UTF-8 ������ı�
        Debug.Log("�浵�����ɹ���");
        sw.WriteLine(str_info);//����Ϊ��λд���ַ���
        sw.Close();
        sw.Dispose();//�ļ����ͷ�
    }

    public void CreatNewGame()
    {
        Create(Application.persistentDataPath, "save.txt", "�浵");
    }

    public void Read(string file_path, string file_name, string str_info)
    {
        StreamWriter sw;
        if (!File.Exists(file_path + "//" + file_name))
        {
            sw = File.CreateText(file_path + "//" + file_name);//����һ������д�� UTF-8 ������ı�
            Debug.Log("�浵�����ɹ���");
        }
        else
        {
            sw = File.AppendText(file_path + "//" + file_name);//������ UTF-8 �����ı��ļ��Խ��ж�ȡ
        }
        sw.WriteLine(str_info);//����Ϊ��λд���ַ���
        sw.Close();
        sw.Dispose();//�ļ����ͷ�
    }

    public void Continue()
    {
        Read(Application.persistentDataPath, "save.txt", "�浵");
    }

}
