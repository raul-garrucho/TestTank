using System.Collections;
using System.Collections.Generic;
using Tankprototipe;
using UnityEngine;

namespace Gameplayy
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField] private FMSGameplay fsmGameplay = null;
        [SerializeField] private LevelManager manager;
        [SerializeField] private LeaderBoardPanel leaderBoard;
        [SerializeField] private TwoPlayerWIn twoPlayerWIn;
        [SerializeField] private GameObject[] multiplayerElementsList;
        [SerializeField] private GameObject[] singlePlayerElementsList;
        [SerializeField] private Camera player1Camera;
        [SerializeField] private Camera player2Camera;
        private bool isCountTimeRunning = false;
        private float currentTime;
        private string winnerId;

        public static Gameplay Instance;
        private void Awake()
        {
            Instance = this;
            fsmGameplay.OnEnterStart += Initialize;
            fsmGameplay.OnEnterOnePlayer += OnePlayerGame;
            fsmGameplay.OnEnterTwoPlayers += TwoPlayerGame;
            fsmGameplay.OnExitOnePlayer += EndOnePlayerGame;
            fsmGameplay.OnExitTwoPlayers += EndTwoPlayers;
            fsmGameplay.OnExitExit += EndGame;
            fsmGameplay.ChangeToStart();
        }
        private void OnDestroy()
        {
            fsmGameplay.OnEnterStart -= Initialize;
            fsmGameplay.OnEnterOnePlayer -= OnePlayerGame;
            fsmGameplay.OnEnterTwoPlayers -= TwoPlayerGame;
            fsmGameplay.OnExitOnePlayer -= EndOnePlayerGame;
            fsmGameplay.OnExitTwoPlayers -= EndTwoPlayers;
            fsmGameplay.OnExitExit -= EndGame;
        }
        public void Initialize()
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
        public void ChangeToExit(string winner)
        {
            winnerId = winner;
            fsmGameplay.ChangeToExit();
        }


        private void OnePlayerGame()
        {
            for (int i = 0; i < singlePlayerElementsList.Length; i++)
            {
                singlePlayerElementsList[i].SetActive(true);
            }
            currentTime = 0;

            StartCoroutine(CountTime());
        }
        private void TwoPlayerGame()
        {
            player1Camera.rect = new Rect(0, 0.5f, 1, 1);
            player2Camera.rect = new Rect(0, -0.5f, 1, 1);
            for (int i = 0; i < multiplayerElementsList.Length; i++)
            {
                multiplayerElementsList[i].SetActive(true);
            }
        }
        private void EndOnePlayerGame()
        {
            leaderBoard.Initialize(currentTime);

            isCountTimeRunning = false;
        }
        private void EndTwoPlayers()
        {
            twoPlayerWIn.Iniatialize(winnerId);
        }
        private void EndGame()
        {
            leaderBoard.transform.gameObject.SetActive(false);
            twoPlayerWIn.transform.gameObject.SetActive(false);
        }

        IEnumerator CountTime()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();

            isCountTimeRunning = true;

            while (isCountTimeRunning)
            {
                currentTime += Time.deltaTime;
                yield return wait;
            }
        }
    }

}