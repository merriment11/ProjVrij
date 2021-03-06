﻿using System.Collections.Generic;
using UnityEngine;

public class NarrationManager : MonoBehaviour
{
	public AudioSource Narration;
	public AudioSource NarrationRight;
	public AudioSource NarrationFrontDoor;
	public AudioClip NarrationStart;
	public AudioClip NarrationHuiskamer;
	public AudioClip NarrationKussen;
	public AudioClip NarrationHuistelefoon;
	public AudioClip NarrationMobieltjeVoorInteractie;
	public AudioClip NarrationMobieltje;
	public AudioClip NarrationMobieltjeEinde;
	public AudioClip NarrationStudeerkamer;
	public AudioClip NarrationStudeerkamerEinde;
	public AudioClip NarrationKey1;
	public AudioClip NarrationKey2;
	public AudioClip DoorLocked;
	public AudioClip WrongKey;
	public AudioClip CorrectKey1;
	public AudioClip CorrectKey2;
	public AudioClip CorrectKey2Einde;
	public AudioClip NarrationHuiskamer2;
	public AudioClip NarrationKeuken;

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

		Voicelines = new Dictionary<int, AudioClip>
		{
			{0, null},
			{1, NarrationKussen},
			{2, NarrationMobieltjeVoorInteractie},
			{3, NarrationMobieltjeEinde},
			{4, NarrationStudeerkamerEinde},
			{5, CorrectKey2Einde},
		};
	}

	private void Update()
	{
		if (Input.GetButtonDown("Repeat"))
		{
			Narration.Stop();
			NarrationRight.Stop();
			if (Voicelines[ImportantNarration] != null)
			{
				Narration.clip = (Voicelines[ImportantNarration]);
				pm.RemovePrompt("repeat");
			}
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
					Narration.clip = NarrationStart;
					pm.PlayPrompt("start");
				break;
			case ("Kussen"):
					Narration.clip = NarrationKussen;
					
					ImportantNarration = 1;
					pm.PlayPrompt("static");
					pm.PlayPrompt("repeat");
				break;
			case ("Huistelefoon"):
					Narration.clip = NarrationHuistelefoon;

					pm.RemovePrompt("static");
				break;
			case ("MobieltjeVoorInteractie"):
					Narration.clip = NarrationMobieltjeVoorInteractie;

					ImportantNarration = 2;
					pm.PlayPrompt("mobiel");
				break;
			case ("Mobieltje"):
					Narration.clip = NarrationMobieltje;
					NarrationRight.Play();

					ImportantNarration = 3;
					pm.RemovePrompt("mobiel");
					pm.PlayPrompt("repeat");
				break;
			case ("Boekenkast"):
					Narration.clip = NarrationStudeerkamer;
					ImportantNarration = 4;
				break;
			case ("Key1"):
					Narration.clip = NarrationKey1;
				break;
			case ("Key2"):
					Narration.clip = NarrationKey2;
				break;
			case ("BathroomDoor"):
				if (GameManager.instance.clickedBathroomKey)
				{ 
					Narration.clip = CorrectKey1; 
				}
				else
				{ 
					Narration.clip = DoorLocked; 
				}
				break;
			case ("MainDoor"):
				if (GameManager.instance.clickedMainKey)
				{
					Narration.clip = CorrectKey2;
					NarrationFrontDoor.Play();

					triggerzone1.SetActive(true);
					triggerzone2.SetActive(true);
					ImportantNarration = 5;
				}
				else if (GameManager.instance.clickedBathroomKey)
				{ 
					Narration.clip = WrongKey; 
				}
				else
				{ 
					Narration.clip = DoorLocked; 
				}
				break;

			case ("TriggerHuiskamer"): //triggerzone 1
				if (GameManager.instance.puzzle == 1) Narration.clip = NarrationHuiskamer;
				if (GameManager.instance.puzzle == 5) Narration.clip = NarrationHuiskamer2;
				break;
			case ("TriggerKeuken"): //triggerzone 2
				if (GameManager.instance.puzzle == 5) Narration.clip = NarrationKeuken;
				break;

			default:
				if (!Narration.isPlaying) Narration.clip = null;
				break;
		}

		if (!Narration.isPlaying) Narration.Play();
	}
}
