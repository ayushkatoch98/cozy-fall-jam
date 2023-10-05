using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed = 10f;
    [SerializeField] float fallAfter = 2f;
    [SerializeField] float shakeAmt = 1f;
    [SerializeField] float shakeSpeed = 1f;
    public bool startShaking = false;


    float timer = 0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!startShaking) return;

        
        timer += Time.deltaTime;

        if (timer > fallAfter)
        {
            transform.position = transform.position - (-1f * transform.up) * Time.deltaTime * speed; 
        }
        else
        {
            Vector3 temp = transform.position;
            temp.y = Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;

            transform.position = temp;


        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            startShaking = true;

        }

    }
}
