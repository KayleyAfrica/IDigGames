using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnPause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
