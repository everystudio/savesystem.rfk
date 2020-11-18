using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogame;

public class SpawnTest : MonoBehaviour
{
    public SaveablePrefab sp;
    public void Spawn()
    {
        GameObject obj = sp.Retrieve<GameObject>();
    }

    void Update()
    {
        
    }
}
