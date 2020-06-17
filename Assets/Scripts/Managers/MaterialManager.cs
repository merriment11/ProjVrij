using UnityEngine;

public class MaterialManager : MonoBehaviour
{
	public Material dark;
	public Material blue;

	public void ChangeMaterialToDark(GameObject target)
	{
		target.GetComponent<MeshRenderer>().material = dark;
	}

	public void ChangeMaterialToBlue(GameObject target)
	{
		target.GetComponent<MeshRenderer>().material = blue;
	}
}
