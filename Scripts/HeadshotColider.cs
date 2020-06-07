using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadshotColider : MonoBehaviour
{
    public EnemyMove enemyMove;
    void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.SplashSound();      
        enemyMove.HeadshotHit();    
    }
}
