using UnityEngine;

public class NarrationManager : MonoBehaviour
{
	AudioSource Narration;
	public AudioClip NarrationStart;
	public AudioClip NarrationHuiskamer; //trigger zones need implementation
	public AudioClip NarrationKussen;
	public AudioClip NarrationHuistelefoon;
	public AudioClip NarrationMobieltjeVoorInteractie;
	public AudioClip NarrationMobieltje;
	public AudioClip NarrationStudeerkamer; //trigger zones need implementation
	public AudioClip DoorLocked;
	public AudioClip WrongKey;
	public AudioClip CorrectKey;
	public AudioClip NarrationHuiskamer2; //trigger zones need implementation
	public AudioClip Keuken; //trigger zones need implementation

	[HideInInspector]
	public PromptManager pm;

	void Start()
    {
		pm = GetComponent<PromptManager>();
		Narration = GetComponent<AudioSource>();
		PlayNarration("Start");
    }

	public void PlayNarration(string name)
	{
		if (Narration.isPlaying)
		{
			Narration.Stop();
		}

		switch (name)
		{
			case ("Start"):
				Narration.clip = NarrationStart;
				break;
			case ("Kussen"):
				Narration.clip = NarrationKussen;
				pm.PlayPrompt("shoot");
				break;
			case ("Huistelefoon"):
				Narration.clip = NarrationHuistelefoon;
				break;
			case ("MobieltjeVoorInteractie"):
				Narration.clip = NarrationMobieltjeVoorInteractie;
				break;
			case ("Mobieltje"):
				Narration.clip = NarrationMobieltje;
				break;
			default:
				if (!Narration.isPlaying)
				{
					Narration.clip = null;
				}
				break;
		}

		if (!Narration.isPlaying)
		{
			Narration.Play();
		}
	}
}
