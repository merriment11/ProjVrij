using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class FlashFade : MonoBehaviour
{
	public IEnumerator FadeToClear(Image image, float seconds)
	{
		Color startColor = Color.white;
		image.color = startColor;
		float t = 0;
		yield return new WaitForSeconds(.5f);
		while (t < 1)
		{
			t += Time.deltaTime * 1f / seconds;
			image.color = Color.Lerp(startColor, Color.clear, t);
			yield return null;
		}
		yield return null;
	}
}
