using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SnapScript : MonoBehaviour
{
	public int vision = 1;
	private float growSpeed = 0.2f;
	private float shrinkSpeed = 0.04f;
	private float minSize = 3.5f;
	private float maxSize = 18;
	private float pauseShrink = 0.5f;

	public Image fade;
	public IEnumerator coroutine;

	public float size; //for the raycast script

	GameObject player;
	public GameObject spherePrefab;

	public AudioSource Right;	

	private void Start()
	{
		transform.localPosition = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(minSize, minSize, minSize);

		player = transform.parent.parent.gameObject;
		coroutine = GrowCircle();
	}

	private void Update()
	{
		/*for debugging purposes (remove quotes to press your keyboard 1, 2 and 3 to change them)
		if (Input.GetKeyDown(KeyCode.Alpha1)) vision = 1;
		if (Input.GetKeyDown(KeyCode.Alpha2)) vision = 2;
		if (Input.GetKeyDown(KeyCode.Alpha3)) vision = 3;*/

		switch (vision) //levels of vision
		{
			case (0): //only for menu
				growSpeed = 200;
				shrinkSpeed = 125;
				minSize = 3.5f;
				maxSize = 500;
				pauseShrink = 0.5f;
				break;
			case (1):
				growSpeed = 200;
				shrinkSpeed = 125;
				minSize = 3.5f;
				maxSize = 13;
				pauseShrink = 0.5f;
				break;
			case (2):
				growSpeed = 225;
				shrinkSpeed = 125;
				minSize = 3.5f;
				maxSize = 15;
				pauseShrink = 0.5f;
				break;
			case (3):
				growSpeed = 250;
				shrinkSpeed = 125;
				minSize = 3.5f;
				maxSize = 18;
				pauseShrink = 0.5f;
				break;
			case (4): //this triggers if you press too early
				shrinkSpeed = 400;
				break;
		}

		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z;

		if (Input.GetButtonDown("Snap"))
		{
			if (xSpeed <= .25f && -.25f <= xSpeed && zSpeed <= .25f && -.25f <= zSpeed)
			{
				StartCoroutine(coroutine); //start the growth of the sphere so you can see
			}
		}

		size = transform.localScale.x; //so the raycast script can access it
	}

	IEnumerator GrowCircle()
	{
		float i = 0; //the for loops didn't work well, so we decided to use while loops. The 'I' is kept from this
		Right.Play();
		while (i / 25 <= 30) //grow the sphere
		{
			i += Time.deltaTime * growSpeed;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);

			fade.color = Color.Lerp(Color.clear, Color.black, i / 500f);
			if (Input.GetButtonDown("Snap") && transform.localScale.x > minSize + 1)
			{
				transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere
				fade.color = Color.clear;
				StopCoroutine(coroutine);
			}
		}
			
		transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere
		fade.color = Color.clear;
		yield return null;
	}

	/*IEnumerator GrowCircleOld() 
	{
		int tempvision = vision;
		bool broken = false;
		float i = 0; //the for loops didn't work well, so we decided to use while loops. The 'I' is kept from this
		Right.Play();
		while (i / 25 <= maxSize - minSize) //grow the sphere
		{
			i += Time.deltaTime * growSpeed;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);
			if (Input.GetButtonDown("Snap") && transform.localScale.x > minSize + 1)
			{
				vision = 4;
				broken = true;
				break;
			}
		}

		if (broken == false)
		{
			yield return new WaitForSeconds(pauseShrink); //a little extra time to see
		}


		while (i >= minSize) //shrink the sphere
		{
			if (Input.GetButtonDown("Snap") && transform.localScale.x > minSize + 1)
			{
				broken = true;
				vision = 4;
			}
			i -= Time.deltaTime * shrinkSpeed;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);
		}

		transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere
		vision = tempvision;

		if (broken == true)
		{
			StartCoroutine("GrowCircle");
		}

		yield return null;
	}*/
}
