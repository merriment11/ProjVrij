using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;


public class MobileSphere : MonoBehaviour
{
	bool growing = false;
	[SerializeField]
	private GameObject flash;
	private FlashFade flashfade;
	private BlurMechanic bm;
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;
	public float amountOfBlur = 400f;

    private void Start()
    {
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
	}

    void Update()
    {
		if (growing == false)
		{
			StartCoroutine("GrowSphere");
			growing = true;
		}
		if (transform.parent.GetComponentInChildren<AudioSource>().isPlaying)
        {
			if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
			{
				depthOfField.active = true;
				depthOfField.focalLength.value = amountOfBlur;
			}
		}
		else
        {
			depthOfField.focalLength.value = 0;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "PlayerModel")
		{
			flashfade = flash.GetComponent<FlashFade>();
			StartCoroutine(flashfade.FadeToClear(flash.GetComponent<Image>(), 2));
		}
	}

	IEnumerator GrowSphere()
	{
		yield return new WaitForSeconds(2f);

		transform.parent.GetComponentInChildren<AudioSource>().Play();
		yield return new WaitForSeconds(2f);

		growing = false;
		yield return null;
	}
}
