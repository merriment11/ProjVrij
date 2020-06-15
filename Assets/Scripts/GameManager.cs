using UnityEngine;

public class GameManager : MonoBehaviour
{
	public NarrationManager nm;
	public PromptManager pm;
	public MaterialManager mm;

	public GameObject playerObject;

	public GameObject bathroomDoor;
	public GameObject bathroomDoorNeed;
    public GameObject bathroomDoorRotator;
    public GameObject MainDoor;
    public GameObject MainDoorNeed;
    public GameObject MainDoorRotator;
    public bool clickedMainKey;
    public bool clickedBathroomKey;
    public bool clickedDoor;

	//A count for what puzzle the player is at
	public int puzzle = 1;

    AudioSource ac;

	internal static GameManager instance = null;	

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}

		playerObject = GameObject.Find("Player");
	}

	void Start()
    {
		nm = GetComponent<NarrationManager>();
		pm = GetComponent<PromptManager>();
		mm = GetComponent<MaterialManager>();

		ac = nm.Narration;
        clickedDoor = false;
        clickedMainKey = false;
    }

    void Update()
    {
        if (clickedMainKey && clickedDoor)
        {
            //Debug.Log("unlocking main door1");
            MainDoor.transform.RotateAround(MainDoorRotator.transform.position, Vector3.up, 30 * Time.deltaTime);
            //Debug.Log(MainDoor.transform.localRotation.y);
            if (MainDoor.transform.localRotation.eulerAngles.y > 90)
            {
                clickedMainKey = false;
                clickedDoor = false;
            }
        }

        if (clickedBathroomKey && clickedDoor)
        {
            //Debug.Log("unlocking main door1");
            bathroomDoor.transform.RotateAround(bathroomDoorRotator.transform.position, Vector3.up, 30 * Time.deltaTime);
            //Debug.Log(MainDoor.transform.localRotation.y);
            if (bathroomDoor.transform.localRotation.eulerAngles.y > 179)
            {
                clickedBathroomKey = false;
                clickedDoor = false;
            }
        }

        if (!ac.isPlaying && bathroomDoorNeed.tag == "Untagged")
        {
            bathroomDoorNeed.tag = "Clickable";
        }
        if (!ac.isPlaying && MainDoorNeed.tag == "Untagged")
        {
            MainDoorNeed.tag = "Clickable";
        }
    }
}
