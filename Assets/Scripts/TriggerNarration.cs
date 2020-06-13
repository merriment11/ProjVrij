using UnityEngine;

public class TriggerNarration : MonoBehaviour
{
	NarrationManager nm;

    void Start()
    {
		nm = GameManager.instance.nm;
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "player")
		{ nm.PlayNarration(gameObject.name); }
	}
}
