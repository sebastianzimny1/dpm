using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerController>();
            }

            return _instance;
        }
    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    #endregion
    public int hp;
    public int ammo;
    public int points;
    public int time;
  
    public void ChestHit()
    {
        int damage = Random.Range(28, 40);
        hp -= damage;
        if (hp <= 0)
        {
            Time.timeScale = 0;
            CanvasManager.Instance.ShowGameOverPanel();
        }
    }

    public void HeadHit()
    {
        hp -= 100;
        if (hp <= 0)
        {
            Time.timeScale = 0;
            CanvasManager.Instance.ShowGameOverPanel();
        }
    }

    public void LegstHit()
    {
        int damage = Random.Range(2, 18);
        hp -= damage;
        if (hp <= 0)
        {
            Time.timeScale = 0;
            CanvasManager.Instance.ShowGameOverPanel();
        }
    }
}
