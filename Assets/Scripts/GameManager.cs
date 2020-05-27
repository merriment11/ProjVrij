using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door1;
    public GameObject MainDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetKey(string key)
    {
        if (key == "Key2") 
        {
            UnlockDoor1();
        }
        if (key == "Key3") 
        {
            UnlockMainDoor();
        }
    }

    private void UnlockDoor1()
    {
        Debug.Log("unlocked bathroom");
    }
    private void UnlockMainDoor()
    {
        Debug.Log("unlocked main door");
    }

}
