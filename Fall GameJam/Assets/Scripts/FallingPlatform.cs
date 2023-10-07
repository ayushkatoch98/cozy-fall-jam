using System;
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
    [SerializeField] float respawnAfter = 2f;
    public bool startShaking = false;


    float timer = 0f;
    float respawnTimer = 0f;


    Vector3 originalPosition;


    void Start()
    {

        originalPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (!startShaking) return;


        timer += Time.deltaTime;

        if (timer > fallAfter)
        {
            
            respawnTimer += Time.deltaTime;

            if (respawnTimer > respawnAfter)
            {
                // respawn
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, Time.deltaTime * speed);
                
                if (Vector3.Distance(transform.position, originalPosition) <= 0.05f)
                {
                    startShaking = false;
                    respawnTimer = 0f;
                    timer = 0f;
                } 
            }

            else
            {   
                // fall
                transform.position = transform.position - (transform.up) * Time.deltaTime * speed;
            }
        }
        else
        {
            // shaking 

            Vector3 temp = originalPosition;
            temp.y += Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;
            transform.position = temp;

            //transform.position = temp;


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