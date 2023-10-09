using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        int totalChildren = transform.childCount;

        for(int i = 0; i < totalChildren; i++)
        {

            Transform child = transform.GetChild(i);

            int rotation = Random.Range(0, 360);
            child.eulerAngles = new Vector3(child.eulerAngles.x, rotation, child.eulerAngles.z);

            

        }

        
    }


}
