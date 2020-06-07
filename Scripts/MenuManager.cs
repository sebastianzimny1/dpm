using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject countryAndNicknamePanel;
    public GameObject shopPanel;
    public GameObject continueButton;
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;
    public GameObject fillName;
    public GameObject chooseFlag;
    public TMP_InputField inputField;
    public void OnEnable()
    {
        fillName.SetActive(false);
        chooseFlag.SetActive(false);
        DisplayMainMenu();       
        if(PlayerPrefs.GetInt("IsContinue") ==1)
        {
            continueButton.SetActive(true);
            GameData.Instance.flagName = PlayerPrefs.GetString("flagName");
            GameData.Instance.nickName = PlayerPrefs.GetString("nickName");
            AssignFlag();
        }

        if (PlayerPrefs.GetInt("IsContinue") == 0)
        {
            continueButton.SetActive(false);
        }
    }

    public void AssignFlag()
    {
        GameData.Instance.flagImage = Resources.Load<Sprite>(GameData.Instance.flagName);
    }

    public void PlayGame()
    {
        DisplaCountryAndNicknamePanel();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsContinue",0);
        continueButton.SetActive(false);
        GameData.Instance.currentOpponent = "";
        GameData.Instance.flagName = "";
        GameData.Instance.nickName = "";
        GameData.Instance.flagImage = null;
        GameData.Instance.stage = 0;
        GameData.Instance.country = null;
    }

    public void Continue()
    {
        SceneManager.LoadScene("Stage");
    }
    public void DisplayMainMenu()
    {
        mainMenuPanel.SetActive(true);
        countryAndNicknamePanel.SetActive(false);    
        shopPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void DisplaCountryAndNicknamePanel()
    {
        mainMenuPanel.SetActive(false);
        countryAndNicknamePanel.SetActive(true);
        shopPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void DisplaShopPanel()
    {
        mainMenuPanel.SetActive(false);
        countryAndNicknamePanel.SetActive(false);
        shopPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void DisplaStagePanel()
    {
        mainMenuPanel.SetActive(false);
        countryAndNicknamePanel.SetActive(false);
        shopPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void DisplaCreditsPanel()
    {
        countryAndNicknamePanel.SetActive(false);
        shopPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void DisplaHowToPlayPanel()
    {
        countryAndNicknamePanel.SetActive(false);
        shopPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void OpenStageScene()
    {
        if (inputField.text == "")
        {
            fillName.SetActive(true);
            StartCoroutine(Wait());
        }

        else if(GameData.Instance.flagName == "")
        {
            chooseFlag.SetActive(true);
            StartCoroutine(WaitFlag());
        }
        else
        {
            PlayerPrefs.SetInt("IsContinue", 1);
            SceneManager.LoadScene("Stage");
            PlayerPrefs.SetString("flagName", GameData.Instance.flagName);
            PlayerPrefs.SetString("nickName", GameData.Instance.nickName);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        fillName.SetActive(false);
    }

    IEnumerator WaitFlag()
    {
        yield return new WaitForSeconds(2);
        chooseFlag.SetActive(false);
    }
}
