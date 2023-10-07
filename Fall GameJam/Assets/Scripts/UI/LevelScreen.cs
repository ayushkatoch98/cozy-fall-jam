using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScreen : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject gridItemPrefab;
    [SerializeField] int totalLevels;
    void Start()
    {
        populate();
    }

    void populate()
    {

        GameObject go;
        for(int i = 0; i < totalLevels; i++)
        {

            go = (GameObject) Instantiate(gridItemPrefab, transform);
            Debug.Log("Total Child " + go.transform.childCount);
            


        }

    }
}
