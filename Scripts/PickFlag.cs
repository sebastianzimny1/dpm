using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickFlag : MonoBehaviour
{
    public ResetFlag resetFlag;
    public string flagName;
    public Sprite flagImage;
    Image image;
    public GameObject country;
    private void Awake()
    {
         image = GetComponent<Image>();
    }
    public void ShowBackground(GameObject background)
    {
        resetFlag.TurnOffAllBackground();
        background.SetActive(true);
        GameData.Instance.flagName = flagName;
        GameData.Instance.flagImage = image.sprite;
        GameData.Instance.country = country;
    }
}
