using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MobileSphere : MonoBehaviour
{
	bool growing = false;
	[SerializeField]
	private GameObject flash;
	private FlashFade flashfade;

	void Update()
    {
		if (growing == false)
		{
			StartCoroutine("GrowSphere");
			growing = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.name == "PlayerModel")
		{
			Debug.Log("hit");
			flashfade = flash.GetComponent<FlashFade>();
			StartCoroutine(flashfade.FadeToClear(flash.GetComponent<Image>(), 2));
		}
	}

	IEnumerator GrowSphere()
	{
		for (float i = 0; i < 5; i += Time.deltaTime)
		{
			yield return null;
			transform.localScale = new Vector3(1 + i*6, 1 + i*6, 1 + i*6);
		}

		growing = false;
		yield return null;
	}
}
