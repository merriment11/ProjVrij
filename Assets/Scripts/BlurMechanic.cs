using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurMechanic : MonoBehaviour
{
	AudioSource ac;
	Transform playerTransform;

	[SerializeField]
	private PostProcessVolume PostProcessVolume;
	DepthOfField depthOfField;

	public GameObject Camera;
	Vector3 initialPosition;

	[Tooltip ("400 works okay as a baseline for the tv and radio")]
	public float amountOfBlur = 400f;

	void Start()
    {
		ac = GetComponent<AudioSource>();
		playerTransform = GameManager.instance.playerObject.transform;
		PostProcessVolume = GameManager.instance.playerObject.GetComponentInChildren<PostProcessVolume>();
		Camera = PostProcessVolume.gameObject;
		initialPosition = Camera.transform.localPosition;
	}

	void Update()
	{
		if (PostProcessVolume.profile.TryGetSettings(out depthOfField) && ac != null && GameManager.instance.puzzle == 4 && ac.isPlaying)
		{
			depthOfField.active = true;
			depthOfField.focalLength.value = amountOfBlur / Vector3.Distance(playerTransform.position, transform.position);

			if (Vector3.Distance(playerTransform.position, transform.position) <= 10f)
			{
				Camera.transform.localPosition = initialPosition + Random.insideUnitSphere / (Vector3.Distance(playerTransform.position, transform.position) * 5f);
			}
		}
	}
}
