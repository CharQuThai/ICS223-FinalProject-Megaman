using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    public GameObject startText;
    public Transform spawnPoint; 

    void Start()
    {
        SpawnTextPrefab();
    }

    void SpawnTextPrefab()
    {
        if (startText != null)
        {
            GameObject newText = Instantiate(startText, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("startText is not assigned!");
        }
    }

}
