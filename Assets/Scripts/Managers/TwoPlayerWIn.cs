using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayerWIn : MonoBehaviour
{
    [SerializeField] private Text winnerText;

    public void Iniatialize(string winnerid)
    {
        winnerText.text = winnerid;
        gameObject.SetActive(true);
    }
}
