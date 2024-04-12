using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //button play
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    //button quit
    public void QuitGame()
    {
        Application.Quit();
    }

}
