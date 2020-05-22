using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DisableDOF : MonoBehaviour
{
	//This is a testing script on how to enable and disable the depth of view.
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

    void Update()
    {
		if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
		{
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				depthOfField.active = true;
				Debug.Log("enabled");
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				depthOfField.active = false;
				Debug.Log("disabled");
			}
		}
	}
}
