using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManager : MonoBehaviour
{
    public bool playingGame, singlePlayerMode, multiplayerMode;
    private float xOffset, zOffset,currentTime;
    public int distroyedCactusNumber, numberCactus;
    public GameObject winPanel;
    public GameObject cactusPrefab;
    
    public GameObject[] multiplayerElementsList;
    public GameObject[] singlePlayerElementsList;
    public Text timeText,finalTimeText, cactusNumText;
    public Camera player1Camera, player2Camera;
    private SceneControll sceneControll;
    private void Awake()
    {
        winPanel.SetActive(false);
        sceneControll = FindAnyObjectByType<SceneControll>();
        singlePlayerMode = sceneControll.singleplayer;
        multiplayerMode = sceneControll.multiplayer;

        for (int i = 0; i < multiplayerElementsList.Length; i++)
        {
            multiplayerElementsList[i].SetActive(multiplayerMode);
        }
        for (int i = 0; i < singlePlayerElementsList.Length; i++)
        {
            singlePlayerElementsList[i].SetActive(singlePlayerMode);
        }
        playingGame = singlePlayerMode;
        /*
        singlePlayerUI.SetActive(singlePlayerMode);
        multiplayerUi.SetActive(multiplayerMode);
        player2.SetActive(multiplayerMode);
        player2Ui.SetActive(multiplayerMode);*/
       
        if (multiplayerMode)
        {
            player1Camera.rect = new Rect(0, -0.5f, 1, 1);
            player2Camera.rect = new Rect(0, 0.5f, 1, 1);
        }
    }

    private void Update()
    {
        if (singlePlayerMode) SinglePlayerMode();
    }
    private void CreateCactus()
    {
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
        finalTimeText.text= string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void SinglePlayerMode()
    {
        if (numberCactus < 5) CreateCactus();
        if (playingGame) currentTime += Time.deltaTime; //TimeCount
        if (distroyedCactusNumber >= 20)//EndGame
        {
            playingGame = false;
            winPanel.SetActive(true);
        }
        UiManager();
    }
    public void Menu()
    {
        sceneControll.ReturnToMenu();
    }
}
