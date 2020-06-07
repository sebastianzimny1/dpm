using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegColider : MonoBehaviour
{
    public EnemyMove enemyMove;
    void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.SplashSound();
        enemyMove.LegCollider();      
    }
}
