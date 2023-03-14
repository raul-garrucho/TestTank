using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Cambio de escenas y conservar datos entre ellas
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
    public void TwoPlayerMode()
    {
        singleplayer = false;
        multiplayer = true;
        SceneManager.LoadScene("Gameplay");   
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
