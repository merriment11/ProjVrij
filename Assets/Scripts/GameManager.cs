using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectedKeys;
    public bool NewKey;
    // Start is called before the first frame update
    void Start()
    {
        collectedKeys = 0;
        NewKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedKeys == 1 && NewKey)
        {
            Debug.Log(collectedKeys);
            NewKey = false;
        }
        if (collectedKeys == 2 && NewKey)
        {
            Debug.Log(collectedKeys);
            NewKey = false;
        }
        if (collectedKeys == 3 && NewKey)
        {
            Debug.Log(collectedKeys);
            UnlockArea();
            NewKey = false;
        }
    }

    private void UnlockArea()
    {
        Debug.Log("You did it");
    }
}
