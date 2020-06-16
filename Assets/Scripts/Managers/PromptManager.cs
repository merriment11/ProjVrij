using System.Collections;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
	public GameObject startPrompt;
	public GameObject repeatPrompt;
	public GameObject interactPrompt;
	public GameObject staticPrompt;
	public GameObject findMobilePrompt;

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
				StartCoroutine(Activate("repeat", 3f));
				break;
			case ("repeat"):
				repeatPrompt.SetActive(true);
				StartCoroutine(Activate("shoot", 3f));
				break;
			case ("shoot"):
				interactPrompt.SetActive(true);
				break;
			case ("static"):
				staticPrompt.SetActive(true);
				break;
			case ("mobiel"):
				findMobilePrompt.SetActive(true);
				break;
			default:
				break;
		}
	}

	IEnumerator Activate(string input, float timer)
	{
		while (timer > 0)
		{
			yield return new WaitForSeconds(1);
			timer--;
		}

		if (timer <= 0)
		{
			PlayPrompt(input);
		}

		yield return null;
	}
}
