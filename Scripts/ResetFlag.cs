using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFlag : MonoBehaviour
{
    public List<GameObject> backgrounds;
    private void Start()
    {
        TurnOffAllBackground();
    }
    public void TurnOffAllBackground()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].SetActive(false);
        }
    }
}
