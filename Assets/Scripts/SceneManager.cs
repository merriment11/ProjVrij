using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
    public void StartButton()
    {
        Debug.LogError("woooow");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MichaelTest");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
