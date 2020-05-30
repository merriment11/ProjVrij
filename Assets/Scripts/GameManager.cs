using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door1;
    public GameObject MainDoor;
    public GameObject MainDoorRotator;
    [SerializeField] bool openingMainDoor;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (openingMainDoor || Input.GetKey(KeyCode.E))
        {
            //Debug.Log("unlocking main door1");
            MainDoor.transform.RotateAround(MainDoorRotator.transform.position, Vector3.up, 30 * Time.deltaTime);
            //Debug.Log(MainDoor.transform.localRotation.y);
            if (MainDoor.transform.localRotation.eulerAngles.y > 90)
            {
                openingMainDoor = false;
            }
        }
    }

    public void GetKey(string key)
    {
        Debug.Log(key);
        if (key == "Key2") 
        {
            UnlockDoor1();
        }
        if (key == "Key3") 
        {
            Debug.Log("unlocked main door1");
            openingMainDoor = true;
        }
    }

    private void UnlockDoor1()
    {
        Debug.Log("unlocked bathroom");
    }
   // private IEnumerator UnlockMainDoor()
   // {
     //   Debug.Log("unlocked main door2");
        
     //   float i = 0; //the for loops didn't work well, so we decided to use while loops. The 'I' is kept from this
     //   MainDoor.transform.RotateAround(MainDoorRotator.transform.position, Vector3.up, 40 * Time.deltaTime);

    //    return null;
   // }

}
