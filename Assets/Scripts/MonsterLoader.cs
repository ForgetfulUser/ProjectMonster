using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MonsterLoader : MonoBehaviour
{
    public void LoadData()
    {
        if (File.Exists(Application.dataPath + "Data/data.jsn"))
        {
            Debug.Log("Foudn");
        }
    }
}
