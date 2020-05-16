using UnityEngine;

public class ScreamScript : MonoBehaviour
{
	[SerializeField]
	GameObject player;
	public float growSpeed = 0.04f;
	public float shrinkSpeed = 0.005f;
	public float maxSize = 18;

	bool canSee;

	void FixedUpdate()
	{
		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z; //wellicht manager voor maken

		if (Input.GetKeyDown(KeyCode.F))
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

		if (Input.GetKey(KeyCode.F) && canSee)
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
