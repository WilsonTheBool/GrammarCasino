using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    GameObject loadingScreen;

    public void StartGame()
    {

        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
