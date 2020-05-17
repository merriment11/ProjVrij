using System;
using System.Collections;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
	public float growSpeed = 0.2f;
	//public float shrinkSpeed = 0.04f;
	public float minSize = 3.5f;
	public float maxSize = 18;
	bool canSee;
	int vision = 1;

	public float size;

	GameObject player;
	public GameObject spherePrefab;

	

	private void Start()
	{
		transform.localPosition = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(minSize, minSize, minSize);

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
				maxSize = 15;
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

		if (Input.GetButtonDown("Snap") && transform.localScale.x <= minSize)
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

	private void FixedUpdate()
	{
		
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
		float i = 0;
		while (i / 25 <= maxSize - minSize)
		{
			i += Time.deltaTime / 0.02f;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);
			Debug.Log("first: "+i);
		}

		yield return new WaitForSeconds(0.5f); //a little extra time to see
		Debug.Log("mid: " +i);
		while (i >= minSize)
		{
			Debug.Log("end: "+i);
			i -= Time.deltaTime / 0.02f;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);
		}
		/*
		for (float i = transform.localScale.x; i/25 <= maxSize - minSize; i++)
		{
			transform.localScale = new Vector3(minSize + i/25, minSize + i/25, minSize + i/25);
			//yield return new WaitForSeconds(0.0001f);
		}
		yield return new WaitForSeconds(0.5f); //a little extra time to see
		for (float i = maxSize; i >= minSize; i = i - 0.02f)
		{
			transform.localScale = new Vector3(i, i, i);
			//yield return new WaitForSeconds(0.00001f);
		}
		*/
		transform.localScale = new Vector3(minSize, minSize, minSize);
		//GetComponentInParent<RenewCircle>().RenewSphere();
		//Destroy(gameObject);
		yield return null;
	}
}
