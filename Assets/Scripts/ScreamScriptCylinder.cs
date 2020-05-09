using UnityEngine;

public class ScreamScriptCylinder : MonoBehaviour
{
	[SerializeField]
	GameObject player;
	public float growSpeed = 0.04f;
	public float shrinkSpeed = 0.005f;
	public float maxSize = 18;

	void Update()
    {
		if (Input.GetKey(KeyCode.F) && player.GetComponent<MyCharacterController>().move.x <= .5 && player.GetComponent<MyCharacterController>().move.z <= .5)
		{
			if (transform.localScale.x < maxSize)
			{
				transform.localScale += new Vector3(growSpeed, growSpeed*.75f, growSpeed);
			}
			else if (transform.localScale.x >= maxSize)
			{
				transform.localScale = new Vector3(maxSize, maxSize*.75f, maxSize);
			}
		}
		else if (transform.localScale.x >= 3.6)
		{
			float decreaseShrink = transform.localScale.x/4;
			transform.localScale -= new Vector3(shrinkSpeed*decreaseShrink, shrinkSpeed*decreaseShrink*.75f, shrinkSpeed*decreaseShrink);
		}
    }
}
