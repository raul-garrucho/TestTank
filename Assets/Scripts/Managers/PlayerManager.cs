using UnityEngine;
using UnityEngine.UI;
//Encargado de cambiar entre  modos de juego y controlar los diversos valores
namespace Tankprototipe
{
    public class PlayerManager : MonoBehaviour
    {
        private bool playingGame;
        [SerializeField] private LevelManager levelManager;
        public LeaderBoardPanel leaderBoardPanel;
        private float currentTime;
        public int distroyedCactusNumber, numberCactus;
        public GameObject winPanel;
        public GameObject cactusPrefab,playerPrefab;
        public GameObject[] multiplayerElementsList;
        public GameObject[] singlePlayerElementsList;
        public Text timeText, cactusNumText;
        public Camera player1Camera, player2Camera;

        private void Awake()
        {
            Disableall();
            winPanel.SetActive(false);
            switch (levelManager.gamemodeSelected)
            {
                case "SinglePlayer":
                    OnePlayerInitialize();
                    for (int i = 0; i < singlePlayerElementsList.Length; i++)
                    {
                        singlePlayerElementsList[i].SetActive(true);
                    }
                    break;
                case "MultiPlayer":
                    player1Camera.rect = new Rect(0, -0.5f, 1, 1);
                    player2Camera.rect = new Rect(0, 0.5f, 1, 1);
                    for (int i = 0; i < multiplayerElementsList.Length; i++)
                    {
                        multiplayerElementsList[i].SetActive(true);
                    }
                    break;
            }
        }

        private void Update()
        {
            if (playingGame) SinglePlayerMode();
        }
        private void SinglePlayerMode()
        {
            currentTime += Time.deltaTime; //TimeCount
            if (numberCactus < 5) CreateCactus();
            if (distroyedCactusNumber >= 20)//EndGame
            {
                leaderBoardPanel.Initialize(currentTime);
                playingGame = false;
            }
            UiManager();
        }
        private void CreateCactus()
        {
            float xOffset, zOffset;
            xOffset = Random.Range(75, -75);
            zOffset = Random.Range(75, -75);
            Vector3 ramdonPosition = transform.position + new Vector3(xOffset, 0, zOffset);
            GameObject cactus = Instantiate(cactusPrefab, ramdonPosition, Quaternion.identity, transform);
            numberCactus++;
        }
        private void UiManager()
        {
            cactusNumText.text = distroyedCactusNumber.ToString();
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        public void OnePlayerInitialize()
        {
            playingGame = true;
            currentTime = 0;
            distroyedCactusNumber = 0;
        }
        private void Disableall()
        {
            for (int i = 0; i < singlePlayerElementsList.Length; i++)
            {
                singlePlayerElementsList[i].SetActive(false);
            }
            for (int i = 0; i < multiplayerElementsList.Length; i++)
            {
                multiplayerElementsList[i].SetActive(false);
            }
        }
    }
}