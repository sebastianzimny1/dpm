using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestColiderPlayer : MonoBehaviour
{
    public PlayerController playerController;
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Knife")
        {      
            SoundManager.Instance.SplashSound();
            playerController.ChestHit();
        }         
    }
}
