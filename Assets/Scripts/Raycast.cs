using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class Raycast : MonoBehaviour
{
	private float range = 0f;

	public NarrationManager nm;
	public Eyedrop ed;
	public MaterialManager mm;
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	public SnapScript ss;
	public KeyScript ks;

	public GameObject huistelefoon;
	public GameObject mobieltje;
	public GameObject boekenkast;

	//public GameObject Key1; unused
	public GameObject Key2;
	public GameObject Key3;

	public GameObject Radio;
	public GameObject TV;

	public GameObject backDoor;

	AudioSource tv;
	AudioSource radio;

	private void Start()
	{
		ss = GetComponentInChildren<SnapScript>();
		ed = GetComponent<Eyedrop>();
		mm = GameManager.instance.mm;

		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();

		tv = TV.GetComponentInChildren<AudioSource>();
		radio = Radio.GetComponentInChildren<AudioSource>();
	}

	void Update()
	{
		range = ss.size;

		if (Input.GetButtonDown("Fire1"))
		{
			GameObject target = ShootRay();
			if (target != null)
			{
				GameManager.instance.pm.RemovePrompt("shoot");
				switch (target.name)
				{
					case ("Kussen"):
						{
							mm.ChangeMaterialToDark(target);
							StartCoroutine(Activate(huistelefoon, 18f));
						}
						break;
					case ("Huistelefoon"):
						{
							ss.vision = 2;
							StartCoroutine(Activate(mobieltje, 14f));
							GameManager.instance.puzzle = 2;
							ed.Blur();

							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(1).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(2).gameObject);
						}
						break;
					case ("Mobieltje"):
						{
							ss.vision = 3;
							mobieltje.transform.GetChild(1).gameObject.SetActive(false);
							ed.Blur();
							GameManager.instance.puzzle = 3;

							StartCoroutine(Activate(boekenkast, 20f));

							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(1).gameObject);

							if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
							{
								depthOfField.focalLength.value = 0;
							}
						}
						break;
					case ("Boekenkast"):
						{
							GameManager.instance.puzzle = 4;
							//StartCoroutine(Activate(Key1, 10f)); was used previously, not anymore
							StartCoroutine(Activate(Key2, 10f));
							StartCoroutine(Activate(Key3, 10f));
							tv.Play();

							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(1).gameObject);

							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(1).gameObject);
							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(2).gameObject);
						}
						break;
					case ("Key2"):
						{
							GameManager.instance.clickedBathroomKey = true;
							target.SetActive(false);

							GameObject BathroomDoor = GameManager.instance.bathroomDoor;
							mm.ChangeMaterialToBlue(BathroomDoor.transform.GetChild(1).gameObject);
							mm.ChangeMaterialToBlue(BathroomDoor.transform.GetChild(2).gameObject);

							GameObject MainDoor = GameManager.instance.MainDoor;
							mm.ChangeMaterialToBlue(MainDoor.transform.GetChild(1).gameObject);
							mm.ChangeMaterialToBlue(MainDoor.transform.GetChild(2).gameObject);
						}
						break;
					case ("Key3"):
						{
							GameManager.instance.clickedMainKey = true;
							target.SetActive(false);
						}
						break;
					case ("BathroomDoor"):
						{
							if (GameManager.instance.clickedBathroomKey)
							{
								GameManager.instance.clickedDoor = true;
								target.tag = "Untagged";

								mm.ChangeMaterialToDark(target.transform.parent.GetChild(1).gameObject);
								mm.ChangeMaterialToDark(target.transform.parent.GetChild(2).gameObject);
							}
						}
						break;
					case ("MainDoor"):
						{
							if (GameManager.instance.clickedMainKey)
							{
								GameManager.instance.puzzle = 5;
								GameManager.instance.clickedDoor = true;
								StartCoroutine(ShowBlood());
								target.tag = "Untagged";
								
								ed.Blur();
								tv.Stop();
								radio.Stop();
								
								mm.ChangeMaterialToDark(target.transform.parent.GetChild(1).gameObject);
								mm.ChangeMaterialToDark(target.transform.parent.GetChild(2).gameObject);

								mm.ChangeMaterialToDark(TV.transform.GetChild(0).GetChild(0).gameObject);
								mm.ChangeMaterialToDark(TV.transform.GetChild(0).GetChild(1).gameObject);
								mm.ChangeMaterialToDark(TV.transform.GetChild(0).GetChild(2).gameObject);

								mm.ChangeMaterialToDark(Radio.transform.GetChild(0).GetChild(0).gameObject);
								mm.ChangeMaterialToDark(Radio.transform.GetChild(0).GetChild(1).gameObject);
								mm.ChangeMaterialToDark(Radio.transform.GetChild(0).GetChild(2).gameObject);

								mm.ChangeMaterialToBlue(backDoor.transform.GetChild(1).gameObject);
								mm.ChangeMaterialToBlue(backDoor.transform.GetChild(2).gameObject);
							}
						}
						break; 
					
					case("BackDoor"):
						{
							if (GameManager.instance.puzzle == 5)
							{
								mm.ChangeMaterialToDark(backDoor.transform.GetChild(1).gameObject);
								mm.ChangeMaterialToDark(backDoor.transform.GetChild(2).gameObject);
								GameManager.instance.sm.EndGame();
							}
						}
						break;
					case ("TV"):
						{	
							if (GameManager.instance.puzzle == 4)
							{
								radio.Play();
								tv.Stop();

								mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(0).gameObject);
								mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(1).gameObject);
								mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(2).gameObject);

								mm.ChangeMaterialToBlue(Radio.transform.GetChild(0).GetChild(0).gameObject);
								mm.ChangeMaterialToBlue(Radio.transform.GetChild(0).GetChild(1).gameObject);
								mm.ChangeMaterialToBlue(Radio.transform.GetChild(0).GetChild(2).gameObject);
							}
						}
						break;
					case ("Radio"):
						{
							radio.Stop();
							tv.Play();

							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(1).gameObject);
							mm.ChangeMaterialToDark(target.transform.GetChild(0).GetChild(2).gameObject);

							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(0).gameObject);
							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(1).gameObject);
							mm.ChangeMaterialToBlue(TV.transform.GetChild(0).GetChild(2).gameObject);
						}
						break;
				}

				if (target.GetComponentInChildren<AudioSource>() != null && target.name != "TV" && target.name != "Radio")
				{
					target.GetComponentInChildren<AudioSource>().enabled = false;
				}
				if (target.name != "BackDoor" || target.name != "achterdeur")
				{
					nm.PlayNarration(target.name);
				}

				if (target.name != "TV" && target.name != "Radio" && target.name != "BackDoor")
				{
					target.tag = "Untagged";
				}
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
			if (go.name == "Mobieltje")
			{
				nm.PlayNarration(go.name + "VoorInteractie");
			}
		}

		yield return null;
	}

	IEnumerator ShowBlood()
    {
		yield return new WaitForSeconds(15);
		GameManager.instance.blood.SetActive(true);
		yield return null;
	}
}
