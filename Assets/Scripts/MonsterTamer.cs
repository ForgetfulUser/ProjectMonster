using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MonsterTamer : MonoBehaviour
{
    public List<Monster> Monsters = new List<Monster>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Application.dataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
