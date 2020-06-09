using UnityEngine;

public class PromptManager : MonoBehaviour
{
	public GameObject startPrompt;
	public GameObject interactPrompt;

	public void Start()
	{
		PlayPrompt("start");
	}
	public void PlayPrompt(string name)
	{
		switch (name)
		{
			case ("start"):
				startPrompt.SetActive(true);
				break;
			case ("shoot"):
				interactPrompt.SetActive(true);
				break;
			default:
				break;
		}
	}
}
