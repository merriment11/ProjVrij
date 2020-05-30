using UnityEngine;

public class Raycast : MonoBehaviour
{
	private float range = 0f;
	public NarrationManager nm;
	public SnapScript ss;
	public GameObject mobieltje;

	private void Start()
	{
		ss = GetComponentInChildren<SnapScript>();
	}

	void Update()
	{
		range = GetComponentInChildren<SnapScript>().size;

		if (Input.GetButtonDown("Fire1"))
		{
			GameObject target = ShootRay();

			if (target != null)
			{
				Debug.Log(target);
				
				switch (target.name)
				{
					case ("Huistelefoon"):
						{
							ss.vision = 2;
							mobieltje.SetActive(true);
						}
						break;
				}

				if (target.GetComponentInChildren<AudioSource>() != null)
				{
					target.GetComponentInChildren<AudioSource>().enabled = false;
				}

				nm.PlayNarration(target.name);
				target.tag = "Untagged";
			}
		}
	}

	GameObject ShootRay()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, range))
		{
			if (hit.transform.gameObject.tag == "Clickable")
			{
				return hit.transform.gameObject;
			}
		}
		return null;
	}
}
