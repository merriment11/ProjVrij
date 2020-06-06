using UnityEngine;

public class NarrationManager : MonoBehaviour
{
	public PromptManager pm;
	AudioSource Narration;
	public AudioClip NarrationStart;
	public AudioClip NarrationKussen;
	public AudioClip NarrationHuistelefoon;
	public AudioClip NarrationMobieltje;

	void Start()
    {
		Narration = GetComponent<AudioSource>();
		PlayNarration("start");
    }

	public void PlayNarration(string name)
	{
		Narration.Stop();

		switch (name)
		{
			case ("start"):
				Narration.clip = NarrationStart;
				break;
			case ("2"):
				pm.PlayPrompt("shoot");
				break;
			case ("kussen"):
				Narration.clip = NarrationKussen;
				break;
			case ("mobieltje"):
				Narration.clip = NarrationMobieltje;
				break;
			default:
				break;
		}

		Narration.Play();
	}
}
