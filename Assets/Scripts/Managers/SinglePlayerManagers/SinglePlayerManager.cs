using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManager : MonoBehaviour
{
    public bool playingGame;
    public float currentTime;
    public float xOffset, yOffset;
    public int distroyedCactusNumber,numberCactus;
    public GameObject winPanel;
    public GameObject cactus;
    public Text timeText, cactusNumText;
    private void Awake()
    {
        playingGame = true;
        winPanel.SetActive(false);
    }

    private void Update()
    {
        if (numberCactus < 5) CreateCactus();
        if (playingGame) currentTime += Time.deltaTime; //TimeCount
        if(distroyedCactusNumber >= 20)//EndGame
        {
            playingGame = false;
            winPanel.SetActive(true);
        }
        UiManager();
    }
    private void CreateCactus()
    {
        xOffset = Random.Range(100, -100);
        yOffset = Random.Range(100, -100);
        Instantiate(cactus,transform);
        numberCactus++;
    }
    private void UiManager()
    {
        cactusNumText.text = distroyedCactusNumber.ToString();
        timeText.text = currentTime.ToString();
    }
}
