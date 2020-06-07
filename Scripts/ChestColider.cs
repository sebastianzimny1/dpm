using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestColider : MonoBehaviour
{

    public EnemyMove enemyMove;
    public bool isHit = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Knife")
        {
            if(isHit==false)
            {
                isHit = true;
                StartCoroutine(WaitAndChangeHitState(1,false));
                SoundManager.Instance.KnifeSound();
                enemyMove.KnifeColider();
            }
            
        }
        else
        {
            SoundManager.Instance.SplashSound();
            enemyMove.ChestCollider();
        }    
    }

    IEnumerator WaitAndChangeHitState(float delayTime,bool state)
    {
        yield return new WaitForSeconds(delayTime);
        isHit = state;
    }
}
