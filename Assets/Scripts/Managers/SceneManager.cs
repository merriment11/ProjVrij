using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Credits" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MichaelTest");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

	public void EndGame()
	{   
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
		Cursor.lockState = CursorLockMode.None;
	}
}
