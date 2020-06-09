using UnityEngine;

public class DeletThis : MonoBehaviour
{
	//this script exists to delete prompts after an amount of seconds
	float timer;
	public float seconds = 3f;

    void Update()
    {
		timer += Time.deltaTime;

		if (timer >= seconds)
		{ Destroy(gameObject); }
	}
}
