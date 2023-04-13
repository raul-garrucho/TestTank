using System.Collections;
using System.Collections.Generic;
using Tankprototipe;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private FMSGameplay fsmGameplay = null;
    [SerializeField] private LevelManager manager;
    [SerializeField] LeaderBoardPanel leaderBoard;
    private bool oneplayerGame = false;
    public float currentTime;
    public GameObject[] multiplayerElementsList;
    public GameObject[] singlePlayerElementsList;
    
    public Camera player1Camera, player2Camera;

    private void Awake()
    {
        fsmGameplay.OnEnterStart += Initialize;
        fsmGameplay.OnEnterOnePlayer += OnePlayerGame;
        fsmGameplay.OnEnterTwoPlayers += TwoPlayerGame;
        fsmGameplay.OnExitTwoPlayers += EndTwoPlayerGame;
        fsmGameplay.OnExitOnePlayer += EndOnePlayerGame;
        fsmGameplay.OnExitExit += Exit;
        fsmGameplay.ChangeToStar();
    }
    private void Initialize()
    {
        switch (manager.gamemodeSelected)
        {
            case "SinglePlayer":
                fsmGameplay.ChangeToOnePlayer();
                break;
            case "Multiplayer":
                fsmGameplay.ChangeToTwoPlayer();
                break;
        }
    }

    public void OnePlayerGame()
    {
        for (int i = 0; i < singlePlayerElementsList.Length; i++)
        {
            singlePlayerElementsList[i].SetActive(true);
        }
        currentTime = 0;
        oneplayerGame = true;
    }
    private void TwoPlayerGame()
    {
        player1Camera.rect = new Rect(0, -0.5f, 1, 1);
        player2Camera.rect = new Rect(0, 0.5f, 1, 1);
        for (int i = 0; i < multiplayerElementsList.Length; i++)
        {
            multiplayerElementsList[i].SetActive(true);
        }
    }
    public void EndOnePlayerGame()
    {
        oneplayerGame = false;
        leaderBoard.Initialize(currentTime);
        fsmGameplay.ChangeToExit();
    }
    public void EndTwoPlayerGame()
    {
        fsmGameplay.ChangeToExit();
    }
    public void Exit()
    {
        leaderBoard.transform.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (oneplayerGame) currentTime += Time.deltaTime;
    }
}
