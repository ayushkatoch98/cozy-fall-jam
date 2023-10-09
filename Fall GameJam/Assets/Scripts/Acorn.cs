using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    Score score;
    [SerializeField] float shakeSpeed = 1f;
    [SerializeField] float shakeAmt = 1f;

    [SerializeField] bool allDirections = false;
    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        score = GameObject.FindWithTag("ScoreUI").GetComponent<Score>();    
    }

    private void Update()
    {

        Vector3 temp = originalPosition;
        temp.y += Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;

        if (allDirections)
        {
            temp.x -= Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;
            temp.z += Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;
        }
    
        transform.position = temp;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Running");
            score.increaseScore();
            Destroy(gameObject);
        }
    }
}
