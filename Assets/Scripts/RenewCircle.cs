using UnityEngine;

public class RenewCircle : MonoBehaviour
{
	[SerializeField]
	GameObject spherePrefab;

    public void RenewSphere()
	{
		Instantiate(spherePrefab, GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().rotation, transform);
	}
}
