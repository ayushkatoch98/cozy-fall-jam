using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnHover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text.color = new Color(1, 0.8f, 0.63f, 1);
    }

    public void onHover()
    {
        text.color = new Color(1, 0.6f, 0.23f, 1);
    }

    public void onHoverExit()
    {
        text.color = new Color(1, 0.8f, 0.63f, 1);
    }
}
