using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class MobileSphere : MonoBehaviour
{
	bool playing = false;
	private BlurMechanic bm;
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;
	public float amountOfBlur = 400f;

	AudioSource mobieltjeAudio;

    private void Start()
    {
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
		mobieltjeAudio = transform.parent.GetComponentInChildren<AudioSource>();
	}

    void Update()
    {
		if (mobieltjeAudio != null)
		{
			if (playing == false && mobieltjeAudio.isActiveAndEnabled)
			{
				StartCoroutine("PlayAudio");
				playing = true;
			}

			if (mobieltjeAudio.isPlaying)
			{
				if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
				{
					depthOfField.active = true;
					depthOfField.focalLength.value = amountOfBlur;
				}
			}
			else if (mobieltjeAudio.isActiveAndEnabled)
			{
				depthOfField.focalLength.value = 0;
			}
		}
	}

	IEnumerator PlayAudio()
	{
		yield return new WaitForSeconds(2f);

		mobieltjeAudio.Play();
		yield return new WaitForSeconds(2f);

		playing = false;
		yield return null;
	}
}
