using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpManager : MonoBehaviour
{
    #region Singleton

    public static DamagePopUpManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]
    private GameObject damagePopUpPrefab;

    public void DisplayDamagePopUp(int amount, Transform popUpParent)
    {
        GameObject go = Instantiate(damagePopUpPrefab, popUpParent.transform.position, Quaternion.identity, popUpParent);
        go.GetComponent<DamagePopUp>().SetUp(amount);
    }
}
