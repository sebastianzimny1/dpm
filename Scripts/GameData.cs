using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region SINGLETON PATTERN
        private static GameData _instance;

        public static GameData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameData>();
                }

                return _instance;
            }
        }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public string currentOpponent;
    public string flagName;
    public string nickName;
    public Sprite flagImage;
    public int stage;
    public GameObject country;
}
