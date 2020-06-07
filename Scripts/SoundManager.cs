using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SoundManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public AudioClip shoot;
    public AudioClip ammoLoad;
    public AudioClip splash;
    public AudioClip knifeHit;
    public AudioSource audioSource;
    
    public void ShootSound()
    {
        audioSource.PlayOneShot(shoot);
    }

    public void AmmoLoadSound()
    {
        audioSource.PlayOneShot(ammoLoad);
    }

    public void SplashSound()
    {
        audioSource.PlayOneShot(splash);
    }

    public void KnifeSound()
    {
        audioSource.PlayOneShot(knifeHit);
    }
}
