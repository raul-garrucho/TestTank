using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnePlayerMode()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void twoPlayerMode()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void ExitGame()
    {
        
    }
}
