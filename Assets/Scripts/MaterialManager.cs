using UnityEngine;

public class MaterialManager : MonoBehaviour
{
	public Material dark;
	public Material blue;

	void Start()
    {
        
    }


    void Update()
    {
        
    }

	public void ChangeMaterialToDark(GameObject target)
	{
		target.GetComponent<MeshRenderer>().material = dark;
	}

	public void ChangeMaterialToBlue(GameObject target)
	{
		target.GetComponent<MeshRenderer>().material = dark;
	}
}
