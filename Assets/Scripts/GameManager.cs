using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bathroomDoor;
    public GameObject bathroomDoorRotator;
    public GameObject MainDoor;
    public GameObject MainDoorRotator;
    public bool clickedMainKey;
    public bool clickedBathroomKey;
    public bool clickedDoor;

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
	}

	// Start is called before the first frame update
	void Start()
    {
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
    }
}
