using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnHover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fkingText;

    public void onHover()
    {
        //TextMeshProUGUI buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        fkingText.color = Color.black;


    }


    public void onHoverExit()
    {
        //TextMeshProUGUI buttonText = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        fkingText.color = Color.white;


    }

}
