using UnityEngine;

public class TriggerNarration : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player")
		{ GameManager.instance.nm.PlayNarration(gameObject.name); }
		gameObject.SetActive(false);
	}
}
