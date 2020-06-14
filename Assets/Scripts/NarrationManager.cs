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
	public AudioClip NarrationKeuken; //trigger zones need implementation

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
    }

	private void Update()
	{
		if (Input.GetButtonDown("Repeat"))
		{
			Narration.Stop();
			Narration.Play();
		}
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
				{
					Narration.clip = NarrationStart;
				}
				break;
			case ("Kussen"):
				{ Narration.clip = NarrationKussen; }
				pm.PlayPrompt("static");
				break;
			case ("Huistelefoon"):
				{ Narration.clip = NarrationHuistelefoon; }
				break;
			case ("MobieltjeVoorInteractie"):
				{
					Narration.clip = NarrationMobieltjeVoorInteractie;
					pm.PlayPrompt("mobiel");
				}
				break;
			case ("Mobieltje"):
				{ Narration.clip = NarrationMobieltje; }
				break;
			case ("Boekenkast"):
				{ Narration.clip = NarrationStudeerkamer; }
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
					Narration.clip = CorrectKey;
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
