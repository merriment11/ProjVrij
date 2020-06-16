using System.Collections.Generic;
using UnityEngine;

public class NarrationManager : MonoBehaviour
{
	public AudioSource Narration;
	public AudioSource NarrationRight;
	public AudioSource NarrationFrontDoor;
	public AudioClip NarrationStart;
	public AudioClip NarrationHuiskamer; //trigger zones need implementation
	public AudioClip NarrationKussen;
	public AudioClip NarrationHuistelefoon;
	public AudioClip NarrationMobieltjeVoorInteractie;
	public AudioClip NarrationMobieltje;
	public AudioClip NarrationMobieltjeRight;
	public AudioClip NarrationStudeerkamer; //trigger zones need implementation
	public AudioClip DoorLocked;
	public AudioClip WrongKey;
	public AudioClip CorrectKey;
	public AudioClip CorrectKeyPolice;
	public AudioClip NarrationHuiskamer2; //trigger zones need implementation 
	public AudioClip NarrationKeuken; //trigger zones need implementation

	public Dictionary <int,AudioClip> Voicelines;
	int ImportantNarration = 0;

	[SerializeField]
	GameObject triggerzone1;
	[SerializeField]
	GameObject triggerzone2;

	[HideInInspector]
	public PromptManager pm;

	void Start()
    {
		pm = GetComponent<PromptManager>();
		Narration = GetComponent<AudioSource>();
		PlayNarration("Start");

		Voicelines[0] = null;
		Voicelines[1] = NarrationKussen;
		Voicelines[2] = NarrationMobieltjeVoorInteractie;
		Voicelines[3] = null;
		Voicelines[4] = NarrationStudeerkamer;
	}

	private void Update()
	{
		if (Input.GetButtonDown("Repeat"))
		{
			Narration.Stop();
			Narration.clip = (Voicelines[ImportantNarration]);
			Narration.Play();
		}
	}

	public void PlayNarration(string name)
	{
		if (Narration.isPlaying)
		{
			Narration.Stop();
		}

		Debug.Log(name);

		switch (name)
		{
			case ("Start"):
				{ Narration.clip = NarrationStart; }
				break;
			case ("Kussen"):
				{
					Narration.clip = NarrationKussen;
					pm.PlayPrompt("static");
					ImportantNarration = 1;
				}
				break;
			case ("Huistelefoon"):
				{ Narration.clip = NarrationHuistelefoon; }
				break;
			case ("MobieltjeVoorInteractie"):
				{
					Narration.clip = NarrationMobieltjeVoorInteractie;
					pm.PlayPrompt("mobiel");
					ImportantNarration = 2;
				}
				break;
			case ("Mobieltje"):
<<<<<<< HEAD
				{
					Narration.clip = NarrationMobieltje;
					ImportantNarration = 3;
=======
				{ 
					Narration.clip = NarrationMobieltje;
					NarrationRight.clip = NarrationMobieltjeRight;
					NarrationRight.Play();
>>>>>>> 5da8c0bfb38038e8570d2783b8c525fdf57b83a2
				}
				break;
			case ("Boekenkast"):
				{
					Narration.clip = NarrationStudeerkamer;
					ImportantNarration = 4;
				}
				break;
			case ("BathroomDoor"):
				if (GameManager.instance.clickedBathroomKey)
				{ Narration.clip = null; } //deze hebben we niet
				else
				{ Narration.clip = DoorLocked; }
				break;
			case ("MainDoor"):
				if (GameManager.instance.clickedMainKey)
				{
					NarrationFrontDoor.clip = CorrectKeyPolice;
					Narration.clip = CorrectKey;
					NarrationFrontDoor.Play();

					triggerzone1.SetActive(true);
					triggerzone2.SetActive(true);
				}
				else if (GameManager.instance.clickedBathroomKey)
				{ Narration.clip = WrongKey; }
				else
				{ Narration.clip = DoorLocked; }
				break;

			case ("TriggerHuiskamer"): //triggerzone 1
				if (GameManager.instance.puzzle == 1)
				{ Narration.clip = NarrationHuiskamer; }
				if (GameManager.instance.puzzle == 5)
				{ Narration.clip = NarrationHuiskamer2; }
				break;
			case ("TriggerKeuken"): //triggerzone 2
				if (GameManager.instance.puzzle == 5)
				{ Narration.clip = NarrationKeuken; }
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
