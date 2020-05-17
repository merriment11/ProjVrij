using System;
using System.Collections;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
	public float growSpeed = 0.2f;
	//public float shrinkSpeed = 0.04f;
	public float maxSize = 18;
	bool canSee;
	int vision = 1;

	public float size;

	GameObject player;
	public GameObject spherePrefab;

	private void Start()
	{
		transform.localPosition = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(3, 3, 3);

		player = transform.parent.parent.gameObject;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) vision = 1;
		if (Input.GetKeyDown(KeyCode.Alpha2)) vision = 2;
		if (Input.GetKeyDown(KeyCode.Alpha3)) vision = 3;

		switch (vision)
		{
			case (1):
				growSpeed = 0.15f;
				//shrinkSpeed = 0.04f;
				maxSize = 12;
				break;
			case (2):
				growSpeed = 0.2f;
				//shrinkSpeed = 0.03f;
				maxSize = 18;
				break;
			case (3):
				growSpeed = 0.30f;
				//shrinkSpeed = 0.02f;
				maxSize = 24;
				break;
		}

		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z; //wellicht manager voor maken

		if (Input.GetButtonDown("Snap"))
		{
			if (xSpeed <= .25f && -.25f <= xSpeed && zSpeed <= .25f && -.25f <= zSpeed)
			{
				StartCoroutine("GrowCircle");
			}
		}

		/*if (xSpeed >= .25f || -.25f >= xSpeed || zSpeed >= .25f || -.25f >= zSpeed)
		{
			canSee = false;
		}*/

		size = transform.localScale.x; //so the raycast script can access it
	}

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
		for (float i = transform.localScale.x; i/50 <= maxSize-3; i++)
		{
			transform.localScale = new Vector3(3+i/50,3+i/50,3+i/50);
			yield return new WaitForSeconds(0.000001f);
		}
		yield return new WaitForSeconds(1f); //a little extra time to see
		for (float i = maxSize - 3; i / 50 <= maxSize - 3; i--)
		{
			transform.localScale = new Vector3(3 + i / 50, 3 + i / 50, 3 + i / 50);
			yield return new WaitForSeconds(0.000001f);
		}
		GetComponentInParent<RenewCircle>().RenewSphere();
		Destroy(gameObject);
		yield return null;
	}
}
