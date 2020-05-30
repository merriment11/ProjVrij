using UnityEngine;

public class Raycast : MonoBehaviour
{
	private float range = 0f;
	public NarrationManager nm;
	public SnapScript ss;
	public GameObject mobieltje;

	private void Start()
	{
		ss = GetComponentInParent<SnapScript>();
	}

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

					Debug.Log(target.name);
					nm.PlayNarration(target.name);

					if (target.name == "Huistelefoon")
					{
						ss.vision = 2;
						mobieltje.SetActive(true);
					}

					target.tag = "Untagged";
				}
			}
		}
	}
}
