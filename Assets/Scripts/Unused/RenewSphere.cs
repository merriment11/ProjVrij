using UnityEngine;

public class RenewSphere : MonoBehaviour
{
	[SerializeField]
	GameObject spherePrefab;

    public void NewSphere()
	{
		Instantiate(spherePrefab, GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().rotation, transform);
	}
}
