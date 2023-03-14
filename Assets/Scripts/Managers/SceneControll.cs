using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    public bool singleplayer, multiplayer;
    private void Start()
    {
       DontDestroyOnLoad(gameObject);
    }
    public void OnePlayerMode()
    {
        multiplayer = false;
        singleplayer = true;
        SceneManager.LoadScene("Gameplay");
    }
    public void twoPlayerMode()
    {
        singleplayer = false;
        multiplayer = true;
        SceneManager.LoadScene("Gameplay");   
    }
    public void ExitGame()
    {
        
    }
}
