using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public SaveList saveData;
    public void SaveGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/gameData_save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/gameData_save");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/ gameData_save/save.txt");
        BinaryWriter bw = new BinaryWriter(file);

        var json =JsonUtility.ToJson(saveData);

        bf.Serialize(file,json);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/ gameData_save/save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/ gameData_save/save.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file) , saveData);
            file.Close();
        }
    }
}
