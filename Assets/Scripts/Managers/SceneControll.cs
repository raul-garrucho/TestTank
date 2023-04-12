using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Cambio de escenas y conservar datos entre ellas
public class SceneControll : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    public void ChangeScene(string gamemode)
    {
        switch (gamemode)
        {
            case "SinglePlayer":
                LoadGame(gamemode);
                break;
            case "MultiPlayer":
                LoadGame(gamemode);
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }
    private void LoadGame(string data)
    {
        levelManager.gamemodeSelected = data;
        SceneManager.LoadScene("Gameplay");
    }

}
