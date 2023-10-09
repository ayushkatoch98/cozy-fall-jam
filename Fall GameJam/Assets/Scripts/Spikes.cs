using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float downSpeed = 10f;
    [SerializeField] float upSpeed = 100f;
    [SerializeField] float downInterval = 2f;
    [SerializeField] float upInterval = 7f;
    

    enum Direction // your custom enumeration
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

    [SerializeField] Direction spikeDirection = Direction.UP;


    bool startTimer = false;

    Vector3 closeDirection;
    public Vector3 openPosition;
    public Vector3 closePosition;

    float tempTime = 0f;
    bool isClosing = false;
    Vector3 temp;
    float tempSpeed;

    float interval;

    void Start(){
            
        if (spikeDirection == Direction.UP)
        {
            closeDirection = new Vector3 (0,-1,0);
        }
        else if (spikeDirection == Direction.DOWN)
        {
            closeDirection = new Vector3(0, 1, 0);
        }
        else if (spikeDirection == Direction.LEFT)
        {
            closeDirection = new Vector3(0f, 0f, -1);
        }
        else
        {
            closeDirection = new Vector3(0f, 0f, 1);
        }

        
        openPosition = transform.position;
        closePosition = openPosition + (closeDirection * 2f);
        closePosition.y = -3f;
        interval = downInterval;
    }

    // Update is called once per frame
    void Update()
    {

        if (startTimer)
        {
            tempTime += Time.deltaTime;
            if (tempTime <= interval) return;
            
            startTimer = false;
            tempTime = 0f;
        }
        
        

        if (isClosing)
        {
            temp = closePosition;
            tempSpeed = downSpeed;
        }

        else
        {
            temp = openPosition;
            tempSpeed = upSpeed;
        }


        transform.position = Vector3.MoveTowards(transform.position, temp, tempSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, temp) <= 0.01f)
        {
            isClosing = !isClosing;
            if (isClosing)
            {
                interval = downInterval;
            }
            else
            {
                interval = upInterval;
            }
            startTimer = true;
        }


    }

}



