using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Eyedrop : MonoBehaviour
{
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	public float blur = 0f;
	public float seconds = 4f;

	void Start()
    {
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
	}

	IEnumerator dampenBlur()
    {
		yield return new WaitForSeconds(3.5f);
		while (blur >= 0f)
		{
			if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
			{
				depthOfField.active = true;
				depthOfField.focalLength.value = blur;
			}
			blur -= seconds;
			yield return new WaitForSeconds(seconds / blur);
		}

		blur = 0f;
		yield return null;
		
	}

	public void Blur()
	{
		blur = 150f;
		StartCoroutine(dampenBlur());
	}
}
