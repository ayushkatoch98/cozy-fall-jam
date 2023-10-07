using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{


    [SerializeField] int score;


    public void increaseScore()
    {
        score++;
    }


    public int getScore()
    {
        return score;
    }


}
