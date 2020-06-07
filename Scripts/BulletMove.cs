using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed;
    GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
        rb.AddForce(transform.forward * bulletSpeed);
    }
    public void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(WaitAndDestroy(0.02f));
    }

    IEnumerator WaitAndDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(this.gameObject);
    }
}