using System.Collections;
using UnityEngine;

public class MobileSphere : MonoBehaviour
{
	bool growing = false;

    void Update()
    {
		if (growing == false)
		{
			//StartCoroutine("GrowCircle");
			growing = true;
		}
	}

	IEnumerator GrowSphere()
	{
		for (float i = 0; i < 5; i += Time.deltaTime)
		{
			yield return null;
			transform.localScale = new Vector3(1 + i*2, 1 + i*2, 1 + i*2);
		}
	}
}
