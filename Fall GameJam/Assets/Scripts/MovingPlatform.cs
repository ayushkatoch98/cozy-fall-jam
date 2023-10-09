using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] float speed;
    int index = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, gameObjects[index].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position , gameObjects[index].transform.position) <= 0.05)
            index++;


        if (index >= gameObjects.Count)
            index = 0;

    }

  
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.SetParent(transform);

        }

    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.SetParent(null);

        }

    }
}
