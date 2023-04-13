using Assets.Scripts.FSMs.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Cambio de escenas y conservar datos entre ellas
public class SceneControll : MonoBehaviour
{
    private const string SinglePlayer = "SinglePlayer";
    private const string MultiPlayer = "Multiplayer";
    private const string Gameplay = "Gameplay";

    [SerializeField]
    private LevelManager levelManager = null;
    [SerializeField]
    private FSMMenu fSMMenu = null;

    private void Awake()
    {
        fSMMenu.OnEnterOnePlayer += OnEnterOnePlayer;
        fSMMenu.OnEnterTwoPlayers += OnEnterTwoPlayers;
        fSMMenu.OnEnterExit += OnEnterExit;
    }

    public void OnePlayer()
    {
        fSMMenu.ChangeToOnePlayer();
    }

    public void TwoPlayers()
    {
        fSMMenu.ChangeToTwoPlayer();
    }

    public void Exit()
    {
        fSMMenu.ChangeToExit();
    }

    private void OnEnterOnePlayer()
    {
        levelManager.gamemodeSelected = SinglePlayer;
        SceneManager.LoadScene(Gameplay);
    }

    private void OnEnterTwoPlayers()
    {
        levelManager.gamemodeSelected = MultiPlayer;
        SceneManager.LoadScene(Gameplay);
    }

    private void OnEnterExit()
    {
        Application.Quit();
    }
}
