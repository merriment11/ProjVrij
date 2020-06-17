using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SnapScript : MonoBehaviour
{
	public int vision = 1;
	private float growSpeed = 0.2f;
	private float minSize = 3.5f;
	private float fadeOut = 750f;
	public Image fade;

	public float size; //for the raycast script

	GameObject player;
	public GameObject spherePrefab;

	public AudioSource Right;

	UnityEngine.SceneManagement.Scene scene;

	private void Start()
	{
		transform.localPosition = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(minSize, minSize, minSize);

		player = transform.parent.parent.gameObject;
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
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
				growSpeed = 250;
				minSize = 3.5f;
				break;
			case (1):
				growSpeed = 250;
				minSize = 3.5f;
				fadeOut = 750f;
				break;
			case (2):
				growSpeed = 250;
				minSize = 3.5f;
				fadeOut = 750f;
				break;
			case (3):
				growSpeed = 250;
				minSize = 3.5f;
				fadeOut = 750f;
				break;
		}

		float xSpeed = player.GetComponent<MyCharacterController>().move.x;
		float zSpeed = player.GetComponent<MyCharacterController>().move.z;

		if (Input.GetButtonDown("Snap"))
		{
			if (xSpeed <= .25f && -.25f <= xSpeed && zSpeed <= .25f && -.25f <= zSpeed)
			{
				GameManager.instance.pm.RemovePrompt("start");
				if (scene.name == "Menu")
				{
					StartCoroutine(GrowCircleMenu()); //start the growth of the sphere so you can see
				}
				else
				{
					StartCoroutine(GrowCircle());
				}
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

			fade.color = Color.Lerp(Color.clear, Color.black, i / fadeOut);
			if (Input.GetButtonDown("Snap") && transform.localScale.x > minSize + 1)
			{
				transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere
				fade.color = Color.clear;	
				yield break;
			}
		}
			
		transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere
		fade.color = Color.clear;
		yield return null;
	}

	IEnumerator GrowCircleMenu() 
	{
		float i = 0; //the for loops didn't work well, so we decided to use while loops. The 'I' is kept from this
		Right.Play();
		while (i / 25 <= 500) //grow the sphere
		{
			i += Time.deltaTime * growSpeed;
			yield return null;
			transform.localScale = new Vector3(minSize + i / 25, minSize + i / 25, minSize + i / 25);
		}

		transform.localScale = new Vector3(minSize, minSize, minSize); //reset the sphere

		yield return null;
	}
}
