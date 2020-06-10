using UnityEngine;

public class KeyScript : MonoBehaviour
{
    GameManager gm;
    Raycast ray;

    private void Start()
    {
        gm = GameObject.Find("Player").GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "PlayerModel")
        {
            gm.GetKey(gameObject.name);
            PlaySound();
            gameObject.SetActive(false);
        }
        
    }

    private void PlaySound()
    {

    }
}
