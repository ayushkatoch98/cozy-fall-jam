using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] float shakeSpeed = 1f;
    [SerializeField] float shakeAmt = 1f;

    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {

        Vector3 temp = originalPosition;
        temp.y += Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;
    
        transform.position = temp;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score.increaseScore();
            Destroy(gameObject);
        }
    }
}
