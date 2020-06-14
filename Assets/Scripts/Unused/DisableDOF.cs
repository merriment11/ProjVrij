using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DisableDOF : MonoBehaviour
{
	//This is a testing script on how to enable and disable the depth of view.
	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	private void Start()
	{
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
	}

	void Update()
    {
		if (PostProcessVolume.profile.TryGetSettings(out depthOfField))
		{
			//for debugging purposes
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				depthOfField.active = true;
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				depthOfField.active = false;
			}
		}
	}
}
