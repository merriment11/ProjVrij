using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void StartButton()
    {
<<<<<<< HEAD:Assets/Scripts/SceneManager.cs
        Debug.Log("woooow");
=======
>>>>>>> e9efe4541fe5401ac0446535c49c1d97bb4789ae:Assets/Scripts/Managers/SceneManager.cs
        UnityEngine.SceneManagement.SceneManager.LoadScene("MichaelTest");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

	public void EndGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
		Cursor.lockState = CursorLockMode.None;
	}
}
