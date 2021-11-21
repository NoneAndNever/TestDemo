using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SaveList", menuName = "gameData/SaveList")]
public class SaveList : ScriptableObject
{
    
    public List<Save> savelist = new List<Save>();

}
