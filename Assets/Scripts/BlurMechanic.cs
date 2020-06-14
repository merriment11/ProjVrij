﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurMechanic : MonoBehaviour
{
	AudioSource ac;
	Transform playerTransform;

	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	[Tooltip ("400 works okay as a baseline for the tv and radio")]
	public float amountOfBlur = 400f;

	void Start()
    {
		ac = GetComponent<AudioSource>();
		playerTransform = GameManager.instance.playerObject.transform;
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
	}

	void Update()
	{
		if (PostProcessVolume.profile.TryGetSettings(out depthOfField) && ac != null && GameManager.instance.puzzle == 3)
		{
			depthOfField.active = true;
			depthOfField.focalLength.value = Vector3.Distance(playerTransform.position, transform.position);
		}
		else if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
		{
			depthOfField.active = false;
		}
	}
}