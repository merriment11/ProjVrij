using UnityEngine;

public class PromptManager : MonoBehaviour
{
	public GameObject shootText;

	public void PlayPrompt(string name)
	{
		switch (name)
		{
			case ("shoot"):
				shootText.SetActive(true);
				break;
			default:
				break;
		}
	}
}
