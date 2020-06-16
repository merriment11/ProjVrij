using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("woooow");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MichaelTest");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
