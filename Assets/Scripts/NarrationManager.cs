using UnityEngine;

public class NarrationManager : MonoBehaviour
{
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
				//Narration.clip = NarrationStart;
				break;
			case ("kussen"):
				//Narration.clip = NarrationKussen;
				break;
			case ("huistelefoon"):
				//Narration.clip = NarrationHuistelefoon;
				//mobieltje moet nu ook af gaan (soundManager maken maybe)
				break;
			case ("mobieltje"):
				//Narration.clip = NarrationMobieltje;
				break;
		}

		Narration.Play();
	}
}
