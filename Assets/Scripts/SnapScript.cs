﻿using UnityEngine;

public class SnapScript : MonoBehaviour
{
	[SerializeField]
	GameObject player;
	public float growSpeed = 0.2f;
	public float shrinkSpeed = 0.04f;
	public float maxSize = 18;
	int vision = 1;
	public float size;

	bool canSee;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) vision = 1;
		if (Input.GetKeyDown(KeyCode.Alpha2)) vision = 2;
		if (Input.GetKeyDown(KeyCode.Alpha3)) vision = 3;

		switch (vision)
		{
			case (1):
				growSpeed = 0.15f;
				shrinkSpeed = 0.04f;
				maxSize = 10;
				break;
			case (2):
				growSpeed = 0.2f;
				shrinkSpeed = 0.03f;
				maxSize = 18;
				break;
			case (3):
				growSpeed = 0.30f;
				shrinkSpeed = 0.02f;
				maxSize = 26;
				break;
		}

		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z; //wellicht manager voor maken

		if (Input.GetButtonDown("Snap"))
		{
			if (xSpeed <= .25f && -.25f <= xSpeed && zSpeed <= .25f && -.25f <= zSpeed)
			{
				canSee = true;
			}
		}

		if (xSpeed >= .25f || -.25f >= xSpeed || zSpeed >= .25f || -.25f >= zSpeed)
		{
			canSee = false;
		}

		size = transform.localScale.x; //so the raycast script can access it
	}

	void FixedUpdate()
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
    }
}
