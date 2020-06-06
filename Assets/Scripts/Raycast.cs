using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
	private float range = 0f;
	public NarrationManager nm;
	public PromptManager pm;
	public GameManager gm;
	public SnapScript ss;
	public GameObject mobieltje;
	public GameObject Key1;
	public GameObject Key2;
	public GameObject Key3;
	public GameObject flash;
	public KeyScript ks;

	private void Start()
	{
		ss = GetComponentInChildren<SnapScript>();
		gm = GameObject.Find("Player").GetComponent<GameManager>();
		nm.pm = pm;
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
					case ("Mobieltje"):
						{
							ss.vision = 3;
							Key1.SetActive(true);
							Key2.SetActive(true);
							Key3.SetActive(true);
							mobieltje.transform.GetChild(1).gameObject.SetActive(false);
							flash.GetComponent<Image>().color = Color.clear;
						}
						break;
					case ("Key3"):
						{
							gm.clickedKey = true;
							target.SetActive(false);
						}
						break;
					case ("Door"):
						{
							if (gm.clickedKey) gm.clickedDoor = true;
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
