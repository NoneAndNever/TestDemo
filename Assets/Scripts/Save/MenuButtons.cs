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
            //sw = File.AppendText(file_path + "//" + file_name);//打开现有 UTF-8 编码文本文件以进行读取
        }
        sw = File.CreateText(file_path + "//" + file_name);//创建一个用于写入 UTF-8 编码的文本
        Debug.Log("存档创建成功！");
        sw.WriteLine(str_info);//以行为单位写入字符串
        sw.Close();
        sw.Dispose();//文件流释放
    }

    public void CreatNewGame()
    {
        Create(Application.persistentDataPath, "save.txt", "存档");
    }

    public void Read(string file_path, string file_name, string str_info)
    {
        StreamWriter sw;
        if (!File.Exists(file_path + "//" + file_name))
        {
            sw = File.CreateText(file_path + "//" + file_name);//创建一个用于写入 UTF-8 编码的文本
            Debug.Log("存档创建成功！");
        }
        else
        {
            sw = File.AppendText(file_path + "//" + file_name);//打开现有 UTF-8 编码文本文件以进行读取
        }
        sw.WriteLine(str_info);//以行为单位写入字符串
        sw.Close();
        sw.Dispose();//文件流释放
    }

    public void Continue()
    {
        Read(Application.persistentDataPath, "save.txt", "存档");
    }

}
