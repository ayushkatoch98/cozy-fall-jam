using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score;

    private void Update()
    {
        scoreText.text = "Score " + getScore().ToString();
    }

    public void increaseScore()
    {
        score++;
    }

    public int getScore()
    {
        return score;
    }
}
