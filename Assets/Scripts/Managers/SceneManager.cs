using UnityEngine;

public class SceneManager : MonoBehaviour
{
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
