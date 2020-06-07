using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayData : MonoBehaviour
{
    #region Singleton
    private static GamePlayData instance = null;

    // Game Instance Singleton
    public static GamePlayData Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
       // DontDestroyOnLoad(this.gameObject);
    }
    #endregion
    public int enemyAmount;
    public int friendlyAmount;

    private void OnEnable()
    {
        enemyAmount = 5;
        friendlyAmount = 5;
    }

    public void DecreaseEnemyAmount()
    {
        enemyAmount--;
        CanvasManager.Instance.RefreshScoreBoard();
        if (enemyAmount==0)
        {
            CanvasManager.Instance.ShowWinPanel();
        }
    }

    public void DecreaseFriendlyAmount()
    {
        friendlyAmount--;
        CanvasManager.Instance.RefreshScoreBoard();
    }

    public void ResetValues()
    {
        PlayerController.Instance.ammo = 50;
        PlayerController.Instance.hp = 100;
        CanvasManager.Instance.RefreashAmmo();
        CanvasManager.Instance.RefreashHp();
    } 
}
