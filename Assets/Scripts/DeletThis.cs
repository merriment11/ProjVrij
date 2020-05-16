
using UnityEngine;

public class DeletThis : MonoBehaviour
{
	float timer;
	float time = 1000;

    void Update()
    {
		timer++;
		if (timer == time)
		{ Destroy(gameObject); }
	}
}
