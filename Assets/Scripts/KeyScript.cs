using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    GameManager gm;


    private void Start()
    {
        gm = GameObject.Find("Player").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError(collision);
        gm.collectedKeys++;
        gm.NewKey = true;
        this.gameObject.SetActive(false);
    }
}
