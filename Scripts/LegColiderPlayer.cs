using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegColiderPlayer : MonoBehaviour
{
    public PlayerController playerController;
    void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.SplashSound();
        playerController.LegstHit();     
    }
}
