using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Raycast : MonoBehaviour
{
	private float range = 0f;

	public NarrationManager nm;
	public PromptManager pm;
	public Eyedrop ed;

	public SnapScript ss;
	public GameObject mobieltje;
	public GameObject boekenkast;
	public GameObject Key1;
	public GameObject Key2;
	public GameObject Key3;
	public GameObject flash;
	public KeyScript ks;

	public AudioSource tv;
	public AudioSource radio;


	private void Start()
	{
		ss = GetComponentInChildren<SnapScript>();
		ed = GetComponent<Eyedrop>();
		nm.pm = pm;
	}

	void Update()
	{
		range = ss.size;

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
							StartCoroutine(Activate(mobieltje, 14f));
							GameManager.instance.puzzle = 2;
							ed.Blur();
						}
						break;
					case ("Mobieltje"):
						{
							ss.vision = 3;
							mobieltje.transform.GetChild(1).gameObject.SetActive(false);
							flash.GetComponent<Image>().color = Color.clear;
							ed.Blur();
							GameManager.instance.puzzle = 3;
							StartCoroutine(Activate(boekenkast, 14f));
						}
						break;
					case ("Boekenkast"):
						{
							GameManager.instance.puzzle = 4;
							//StartCoroutine(Activate(Key1, 10f)); was used previously, not anymore
							StartCoroutine(Activate(Key2, 10f));
							StartCoroutine(Activate(Key3, 10f));
							tv.Play();
						}
						break;
					case ("Key2"):
						{
							GameManager.instance.clickedBathroomKey = true;
							target.SetActive(false);
						}
						break;
					case ("Key3"):
						{
							GameManager.instance.clickedMainKey = true;
							target.SetActive(false);
						}
						break;

					case ("MainDoor"):
						{
							if (GameManager.instance.clickedMainKey)
							{
								GameManager.instance.clickedDoor = true;
								GameManager.instance.puzzle = 5;
								ed.Blur();
								tv.Stop();
								radio.Stop();
							}
						}
						break; 
					case("BathroomDoor"):
						{
							if (GameManager.instance.clickedBathroomKey) GameManager.instance.clickedDoor = true;
						}
						break;
					case("BackDoor"):
						{
							//if (GameManager.instance.clickedBathroomKey) GameManager.instance.clickedDoor = true;
							//end of game
						}
						break;
					case ("FrontDoor"):
						{
							//if (GameManager.instance.clickedBathroomKey) GameManager.instance.clickedDoor = true;
							//voice line: not the right door
						}
						break;

					case ("TV"):
						{	
							if (GameManager.instance.puzzle == 4)
							{ radio.Play(); }
							tv.Stop();
						}
						break;
					case ("Radio"):
						{
							radio.Stop();
							tv.Play();
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

	IEnumerator Activate(GameObject go, float timer)
	{

		while (timer > 0)
		{
			yield return new WaitForSeconds (1);
			timer--;
		}

		if (timer  <= 0)
		{
			go.SetActive(true);
			nm.PlayNarration(go.name + "VoorInteractie");
		}

		yield return null;
	}
}
