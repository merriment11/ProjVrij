using UnityEngine;

public class Raycast : MonoBehaviour
{
	private float range = 0f;

	void Update()
	{
		range = GetComponentInChildren<SnapScript>().size;

		if (Input.GetButtonDown("Fire1"))
		{
			ShootRay();
		}
	}

	void ShootRay()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.gameObject);
			if (hit.transform.gameObject.tag == "Clickable")
			{
				GameObject target = hit.transform.gameObject;
				if (target != null)
				{
					if (target.GetComponentInChildren<AudioSource>() != null)
					{
						target.GetComponentInChildren<AudioSource>().enabled = false;
					}
					else
					{
						PlayNarration();
					}
				}
			}
		}
	}
}
