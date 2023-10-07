using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Score score;
    [SerializeField] float shakeSpeed = 1f;
    [SerializeField] float shakeAmt = 1f;
    [SerializeField] float spinSpeed = 1f;

    enum AnimationType
    {
        ROTATE,
        TRANSLATE,
        BOTH,
        NOTHING,
    };

    [SerializeField] AnimationType animationType = AnimationType.TRANSLATE;

    Vector3 originalPosition;

    private void Start()
    {

        originalPosition = transform.position;
        
    }

    private void Update()
    {

        if (animationType == AnimationType.TRANSLATE)
        {
            moveObject();
        }
        else if (animationType == AnimationType.ROTATE)
        {

            rotateObject();
        }

        else if (animationType == AnimationType.BOTH)
        {
            moveObject();
            rotateObject();
        }

        


    }


    private void moveObject()
    {
        Vector3 temp = originalPosition;
        temp.y += Mathf.Sin(Time.time * shakeSpeed) * shakeAmt;

        transform.position = temp;

    }

    private void rotateObject()
    {
        transform.Rotate(0, spinSpeed* Time.deltaTime, 0);

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



