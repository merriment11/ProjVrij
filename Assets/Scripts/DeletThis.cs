
using UnityEngine;

public class DeletThis : MonoBehaviour
{
	float timer;
	float time = 5;

    void Update()
    {
		timer+=Time.deltaTime;
		if (timer == time)
		{ Destroy(gameObject); }
	}
}
