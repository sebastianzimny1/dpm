using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountryManager : MonoBehaviour
{
    public GameObject backAndContinue;
    public GameObject playAgain;

    public List<string> allCountries;
    public List<string> Countries8;
    public List<string> Countries4;
    public List<string> Countries2;
      
    public List<TextMeshProUGUI> LadderEightTexts;
    public List<TextMeshProUGUI> LadderFourTexts;
    public List<TextMeshProUGUI> LadderTwoTexts;

    public GameObject EliminationsTeams;
    public GameObject SemiFinalTeams;
    public GameObject FinalTeams;
    public GameObject winnerTeam;

    public TextMeshProUGUI FirstTeamElimination;
    public TextMeshProUGUI FirstTeamSemiFinal;
    public TextMeshProUGUI FirstTeamFinal;
    public TextMeshProUGUI winner;

    public int currentStage ;

    public TextMeshProUGUI stageName;

    int randomWinner;
  
    private void OnEnable()
    {
        currentStage = PlayerPrefs.GetInt("currentStage", 0);

        EliminationsTeams.SetActive(false);
        SemiFinalTeams.SetActive(false);
        FinalTeams.SetActive(false);
        winnerTeam.SetActive(false);

        if (currentStage == 0)
        {        
            ShowContinueAndBackButtons();
            DeleteSelectedCountry();
            RandomEightCountries();
            FillLadderEight();
            EliminationsTeams.SetActive(true);
            FirstTeamElimination.text = GameData.Instance.flagName;
            stageName.text = "ELIMINATIONS";
            GameData.Instance.currentOpponent = Countries8[0];

        }
        else if (currentStage == 1)
        {
            ShowContinueAndBackButtons();
            EliminationsTeams.SetActive(true);
            SemiFinalTeams.SetActive(true);
            FirstTeamElimination.text = GameData.Instance.flagName;
            FirstTeamSemiFinal.text = GameData.Instance.flagName;

            for(int i=0;i<=6; i++)
            {
                Countries8.Add("null");
            }

            Countries8[0] = PlayerPrefs.GetString("e0");
            Countries8[1] = PlayerPrefs.GetString("e1");
            Countries8[2] = PlayerPrefs.GetString("e2");
            Countries8[3] = PlayerPrefs.GetString("e3");
            Countries8[4] = PlayerPrefs.GetString("e4");
            Countries8[5] = PlayerPrefs.GetString("e5");
            Countries8[6] = PlayerPrefs.GetString("e6");

            FillLadderEight();
            RandomFourCountries();
            FillLadderFour();
            stageName.text = "SEMI FINAL";
            GameData.Instance.currentOpponent = Countries4[0];
        }
        else if (currentStage == 2)
        {
            ShowContinueAndBackButtons();
            EliminationsTeams.SetActive(true);
            SemiFinalTeams.SetActive(true);
            FinalTeams.SetActive(true);
            FirstTeamElimination.text = GameData.Instance.flagName;
            FirstTeamSemiFinal.text = GameData.Instance.flagName;
            FirstTeamFinal.text = GameData.Instance.flagName;

            for (int i = 0; i <= 6; i++)
            {
                Countries8.Add("null");
            }

            Countries8[0] = PlayerPrefs.GetString("e0");
            Countries8[1] = PlayerPrefs.GetString("e1");
            Countries8[2] = PlayerPrefs.GetString("e2");
            Countries8[3] = PlayerPrefs.GetString("e3");
            Countries8[4] = PlayerPrefs.GetString("e4");
            Countries8[5] = PlayerPrefs.GetString("e5");
            Countries8[6] = PlayerPrefs.GetString("e6");

            FillLadderEight();

            for (int i = 0; i <= 2; i++)
            {
                Countries4.Add("null");
            }

            Countries4[0] = PlayerPrefs.GetString("s0");
            Countries4[1] = PlayerPrefs.GetString("s1");
            Countries4[2] = PlayerPrefs.GetString("s2");

            FillLadderFour();

            RandomTwoCountries();
            FillLadderTwo();

            winner.text = GameData.Instance.flagName;
            stageName.text = "FINAL";
            GameData.Instance.currentOpponent = Countries2[0];
        }
        else if (currentStage == 3)
        {
            ShowPlayAgainButton();

            EliminationsTeams.SetActive(true);
            SemiFinalTeams.SetActive(true);
            FinalTeams.SetActive(true);
            winnerTeam.SetActive(true);
            FirstTeamElimination.text = GameData.Instance.flagName;
            FirstTeamSemiFinal.text = GameData.Instance.flagName;
            FirstTeamFinal.text = GameData.Instance.flagName;

            for (int i = 0; i <= 6; i++)
            {
                Countries8.Add("null");
            }

            Countries8[0] = PlayerPrefs.GetString("e0");
            Countries8[1] = PlayerPrefs.GetString("e1");
            Countries8[2] = PlayerPrefs.GetString("e2");
            Countries8[3] = PlayerPrefs.GetString("e3");
            Countries8[4] = PlayerPrefs.GetString("e4");
            Countries8[5] = PlayerPrefs.GetString("e5");
            Countries8[6] = PlayerPrefs.GetString("e6");

            FillLadderEight();

            for (int i = 0; i <= 2; i++)
            {
                Countries4.Add("null");
            }

            Countries4[0] = PlayerPrefs.GetString("s0");
            Countries4[1] = PlayerPrefs.GetString("s1");
            Countries4[2] = PlayerPrefs.GetString("s2");

            FillLadderFour();

            Countries2.Add("null");
            Countries2[0] = PlayerPrefs.GetString("f0");

            FillLadderTwo();

            winner.text = GameData.Instance.flagName;
            stageName.text = "WINNER";
        }
    }

    public void DeleteSelectedCountry()
    {
        for (int i = 0; i < allCountries.Count; i++)
        {
            if(allCountries[i]== GameData.Instance.flagName)
            {
                allCountries.Remove(allCountries[i]);
            }
        }
    }
    public void RandomEightCountries()
    {
        for (int i = 0;i<=6;i++)
        {
            int random = Random.Range(0, allCountries.Count-1);
            Countries8.Add(allCountries[random]);
            allCountries.RemoveAt(random);         
        }
        PlayerPrefs.SetString("e0", Countries8[0]);
        PlayerPrefs.SetString("e1", Countries8[1]);
        PlayerPrefs.SetString("e2", Countries8[2]);
        PlayerPrefs.SetString("e3", Countries8[3]);
        PlayerPrefs.SetString("e4", Countries8[4]);
        PlayerPrefs.SetString("e5", Countries8[5]);
        PlayerPrefs.SetString("e6", Countries8[6]);
    }

    public void FillLadderEight()
    {
        for(int i =0;i<=6;i++)
        {
            LadderEightTexts[i].text = Countries8[i];
        }
    }

    public void RandomFourCountries()
    {
        randomWinner = 2;
        for (int i = 0;i<=2;i++)
        {          
            Countries4.Add(Countries8[randomWinner]);
            randomWinner += 2;
        }
        PlayerPrefs.SetString("s0", Countries4[0]);
        PlayerPrefs.SetString("s1", Countries4[1]);
        PlayerPrefs.SetString("s2", Countries4[2]);
    }

    public void FillLadderFour()
    {
        for(int i = 0;i<=2;i++)
        {
            LadderFourTexts[i].text = Countries4[i];
        }
    }

    public void RandomTwoCountries()
    {
        randomWinner = Random.Range(1, 3);
        Countries2.Add(Countries4[randomWinner]);
        PlayerPrefs.SetString("f0", Countries2[0]);
    }

    public void FillLadderTwo()
    {       
        LadderTwoTexts[0].text = Countries2[0];
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMainMenu()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsContinue", 0);
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowPlayAgainButton()
    {
        backAndContinue.SetActive(false);
        playAgain.SetActive(true);
    }

    public void ShowContinueAndBackButtons()
    {
        backAndContinue.SetActive(true);
        playAgain.SetActive(false);
    }

    public void PlayAgain()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("IsContinue", 0);
        SceneManager.LoadScene("MainMenu");
    }
}
