using System.Collections;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
	public GameObject startPrompt;
	public GameObject repeatPrompt;
	public GameObject interactPrompt;
	public GameObject staticPrompt;
	public GameObject findMobilePrompt;

	private bool firstTime = true;

	public void PlayPrompt(string name)
	{
		switch (name)
		{
			case ("start"):
				StartCoroutine(ActivateStart("start", 8f));
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

			case ("repeat"):
				repeatPrompt.SetActive(true);
				break;
			default:
				break;
		}
	}

	public void RemovePrompt(string name)
	{
		switch (name)
		{
			case ("start"):
				startPrompt.SetActive(false);
				StopAllCoroutines();
				if (firstTime == true)
				{
					PlayPrompt("shoot");
					firstTime = false;
				}
				break;
			case ("shoot"):
				interactPrompt.SetActive(false);
				break;
			case ("static"):
				staticPrompt.SetActive(false);
				break;
			case ("mobiel"):
				findMobilePrompt.SetActive(false);
				break;

			case ("repeat"):
				repeatPrompt.SetActive(false);
				break;
			default:
				break;
		}
	}

	IEnumerator ActivateStart(string input, float timer)
	{
		while (timer > 0)
		{
			yield return new WaitForSeconds(1);
			timer--;
		}

		if (timer <= 0)
		{
			startPrompt.SetActive(true);
		}

		yield return null;
	}
}
