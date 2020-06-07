using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public PlayerController playerController;
   // public CanvasManager canvasManager;
    public GameObject bullet;
    void Update()
    {
        if (CanvasManager.Instance.isPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerController.ammo > 0)
                {
                    SoundManager.Instance.ShootSound();
                    Instantiate(bullet, this.transform.position, transform.rotation);
                    playerController.ammo--;
                    CanvasManager.Instance.RefreashAmmo();
                }
            }
        }
    }
}
