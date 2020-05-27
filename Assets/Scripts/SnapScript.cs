using System;
using System.Collections;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
	public int vision = 1;
	private float growSpeed = 0.2f;
	private float shrinkSpeed = 0.04f;
	private float minSize = 3.5f;
	private float maxSize = 18;
	private float pauseShrink = 0.5f;

	public float size; //for the raycast script

	GameObject player;
	public GameObject spherePrefab;

	//bool canSee;

	private void Start()
	{
		transform.localPosition = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(minSize, minSize, minSize);

		player = transform.parent.parent.gameObject;
	}

	private void Update()
	{
		//for debugging purposes
		if (Input.GetKeyDown(KeyCode.Alpha1)) vision = 1;
		if (Input.GetKeyDown(KeyCode.Alpha2)) vision = 2;
		if (Input.GetKeyDown(KeyCode.Alpha3)) vision = 3;

		switch (vision) //levels of vision (for now, press your keyboard 1, 2 and 3 to change them)
		{
			case (1):
				growSpeed = 100;
				shrinkSpeed = 100;
				minSize = 3.5f;
				maxSize = 13;
				pauseShrink = 0.5f;
				break;
			case (2):
				growSpeed = 125;
				shrinkSpeed = 100;
				minSize = 3.5f;
				maxSize = 15;
				pauseShrink = 0.5f;
				break;
			case (3):
				growSpeed = 150;
				shrinkSpeed = 100;
				minSize = 3.5f;
				maxSize = 18;
				pauseShrink = 0.5f;
				break;
			case (4):
				shrinkSpeed = 400;
				break;
		}

		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z;

		if (Input.GetButtonDown("Snap") && transform.localScale.x <= minSize)
		{
			if (xSpeed <= .25f && -.25f <= xSpeed && zSpeed <= .25f && -.25f <= zSpeed)
			{
				StartCoroutine("GrowCircle"); //start the growth of the sphere so you can see
			}
		}

		size = transform.localScale.x; //so the raycast script can access it

		//part of the old code
		/*if (xSpeed >= .25f || -.25f >= xSpeed || zSpeed >= .25f || -.25f >= zSpeed)
		{
			canSee = false;
		}*/
	}

	//old code with button needs to be kept pressed
	/*void FixedUpdate()
	{
		if (Input.GetButton("Snap") && canSee)
		{
			if (transform.localScale.x < maxSize)
			{
				transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed);
			}
			else if (transform.localScale.x >= maxSize)
			{
				transform.localScale = new Vector3(maxSize, maxSize, maxSize);
			}
		}
		else if (transform.localScale.x >= 3.6)
		{
			float decreaseShrink = transform.localScale.x/4;
			transform.localScale -= new Vector3(shrinkSpeed*decreaseShrink, shrinkSpeed*decreaseShrink, shrinkSpeed*decreaseShrink);
		}

		if (Input.GetButton("Snap") && canSee)
		{
			StartCoroutine("GrowCircle");
		}
    }*/

	IEnumerator GrowCircle()
	{
		int tempvision = vision;
		bool broken = false;
		float i = 0; //the for loops didn't work well, so we decided to use while loops. The 'I' is kept from this
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
	}
}
