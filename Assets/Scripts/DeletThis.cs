using UnityEngine;

public class DeletThis : MonoBehaviour
{
	float timer;
	float time = 3f;

    void Update()
    {
		timer+=Time.deltaTime;

		if (timer >= time)
		{ Destroy(gameObject); }

		delThisFUCK(int 5);
	}
}
