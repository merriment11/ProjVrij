using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Eyedrop : MonoBehaviour
{
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	public float blur = 100f;
	public float seconds = 3f;

	void Start()
    {
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
	}

	private void Update()
	{
		depthOfField.focalLength.value = blur;
	}

	IEnumerator dampenBlur()
    {
		blur -= seconds;
		yield return new WaitForSeconds(seconds/blur);

		if (blur <= 0)
		{
			StopCoroutine(dampenBlur());
		}

		yield return null;
	}

	public void Blur()
	{
		blur = 100f;
		StartCoroutine(dampenBlur());
	}
}
