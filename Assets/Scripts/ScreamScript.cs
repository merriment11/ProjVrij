using UnityEngine;

public class ScreamScript : MonoBehaviour
{
	[SerializeField]
	GameObject player;

	void Update()
    {
		if (Input.GetKey(KeyCode.F) && player.GetComponent<MyCharacterController>().move == Vector3.zero)
		{
			if (transform.localScale.x < 16)
			{
				transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
			}
			else if (transform.localScale.x >= 16)
			{
				transform.localScale = new Vector3(16, 16, 16);
			}
		}
		else if (transform.localScale.x >= 1)
		{
			transform.localScale -= new Vector3(0.08f,0.08f,0.08f);
		}
    }
}
