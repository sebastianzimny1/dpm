using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldNickname : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SetNickname()
    {
        GameData.Instance.nickName = inputField.text; 
    }
}
