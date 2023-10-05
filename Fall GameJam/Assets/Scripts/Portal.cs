using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour

{

    [SerializeField] GameObject to;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            collision.transform.SetPositionAndRotation(to.gameObject.transform.position, Quaternion.identity);

        }

    }
}
