using System;
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "PlayerModel")
        {
            gm.GetKey(this.gameObject.name);
            PlaySound();
            this.gameObject.SetActive(false);
        }
        
    }

    private void PlaySound()
    {
    }
}
