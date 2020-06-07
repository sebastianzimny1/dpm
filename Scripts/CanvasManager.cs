using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    private static CanvasManager _instance;

    public static CanvasManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CanvasManager>();
            }

            return _instance;
        }
    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    #endregion
    public PlayerController playerController;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject crossHair;
    public GameObject HUDPanel;
    public GameObject pausePanel;

    public TextMeshProUGUI texthp;
    public TextMeshProUGUI textAmmo;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textNickName;
    public TextMeshProUGUI textFriendlyAmount;
    public TextMeshProUGUI textEnemyAmount;
    public Image flagImage;
    public Image flagImageFriendly;

    public Material skyboxMorning;
    public Material skyboxMidday;
    public Material skyboxEvening;

    public bool isPaused = false;

    public Light directionalLight;

    private Color middayLightColor = new Color(0.75f, 0.75f, 0.75f, 1);
    private Color eveningLightColor = new Color(0, 0, 0, 1);
    public void Awake()
    {
        GameData.Instance.stage = PlayerPrefs.GetInt("currentStage");
        if(GameData.Instance.stage==0)
        {
            RenderSettings.skybox = skyboxMorning;
        }

        if (GameData.Instance.stage == 1)
        {
            directionalLight.color = middayLightColor;
            RenderSettings.skybox = skyboxMidday;
        }

        if (GameData.Instance.stage == 2)
        {
            directionalLight.color = eveningLightColor;
            RenderSettings.skybox = skyboxEvening;
        }
        GetGameDate();
        VisibleHUD(true);
    }
    public void Start()
    {
        Time.timeScale = 1;
        AssignHUDElements();
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        VisibleCursor(false);
        LockCursor(false);
        pausePanel.SetActive(false);
    }

    public void GetGameDate()
    {
        textFriendlyAmount.text = GamePlayData.Instance.friendlyAmount.ToString();
        textEnemyAmount.text = GamePlayData.Instance.enemyAmount.ToString();
        textNickName.text = "" + GameData.Instance.nickName;
        flagImage.sprite = GameData.Instance.flagImage;
        flagImageFriendly.sprite = Resources.Load<Sprite>(GameData.Instance.currentOpponent);
    }

    public void StartGame()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        VisibleCursor(false);
        LockCursor(false);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Stage");
    }

    public void VisibleHUD(bool state)
    {
        HUDPanel.SetActive(state);
    }

    public void AssignHUDElements()
    {
        textAmmo.text = "" + playerController.ammo;
        texthp.text = "" + playerController.hp;
        textTime.text = "" + playerController.time;
        textPoints.text = "" + playerController.points;
    }

    public void VisibleCursor(bool state)
    {
        Cursor.visible = state;
    }

    public void LockCursor(bool state)
    {
        if (state == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (state == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        RefreashHp();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void RefreashAmmo()
    {
        textAmmo.text = "" + playerController.ammo;
    }

    public void RefreashHp()
    {
        texthp.text = "" + playerController.hp;
    }

    public void RefreashPoints()
    {
        textPoints.text = "" + playerController.points;
    }

    public void RefreshScoreBoard()
    {
        textFriendlyAmount.text = GamePlayData.Instance.friendlyAmount.ToString();
        textEnemyAmount.text = GamePlayData.Instance.enemyAmount.ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
        PlayerPrefs.DeleteAll();
    }

    public void ShowGameOverPanel()
    {
        crossHair.SetActive(false);

        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ShowWinPanel()
    {
        int currentStage = PlayerPrefs.GetInt("currentStage", 0);
        currentStage++;
        PlayerPrefs.SetInt("currentStage", currentStage);
        crossHair.SetActive(false);
        Time.timeScale = 0;
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGamePlay()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsContinue", 0);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadStage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        LockCursor(false);
        VisibleCursor(true);
    }

    public void ReturnToGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        VisibleCursor(false);
        isPaused = false;
    }
}
