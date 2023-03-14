using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManager : MonoBehaviour
{
    public bool playingGame,singlePlayerMode,multiplayerMode;
    public float currentTime;
    public float xOffset, zOffset;
    public int distroyedCactusNumber,numberCactus;
    public GameObject winPanel;
    public GameObject cactusPrefab;
    public GameObject singlePlayerUI,multiplayerUi,player2,player2Ui;
    public Text timeText, cactusNumText;
    public Camera player1Camera, player2Camera;
    private void Awake()
    { 
        winPanel.SetActive(false);
        var camera2rect = player2Camera.rect;
        var camera1rect = player1Camera.rect;
        SceneControll sceneControll = FindAnyObjectByType<SceneControll>();
        singlePlayerMode = sceneControll.singleplayer;
        multiplayerMode = sceneControll.multiplayer;
        playingGame = singlePlayerMode;
        singlePlayerUI.SetActive(singlePlayerMode);
        multiplayerUi.SetActive(multiplayerMode);
        player2.SetActive(multiplayerMode);
        player2Ui.SetActive(multiplayerMode);
    }

    private void Update()
    {
        if (singlePlayerMode) SinglePlayerMode();
        
    }
    private void CreateCactus()
    {
        xOffset = Random.Range(100, -100);
        zOffset = Random.Range(100, -100);
        Vector3 ramdonPosition = transform.position+new Vector3(xOffset,0,zOffset);
        GameObject cactus = Instantiate(cactusPrefab, ramdonPosition, Quaternion.identity,transform);
        numberCactus++;
    }
    private void UiManager()
    {
        cactusNumText.text = distroyedCactusNumber.ToString();
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
       
    }
    private void SinglePlayerMode()
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
}
