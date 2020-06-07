using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    private void Update()
    {
        Instantiate(bullet, this.transform.position, transform.rotation);     
    }
}
