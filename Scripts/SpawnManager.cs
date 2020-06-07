using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform enemyLeftPosition;
    public Transform enemyRightPosition;
    public Transform friendlyRightPosition;
    public Transform friendlyLeftPosition;

    public GameObject enemyPrefab;
    public GameObject friendlyPrefab;

    private string enemyCountry;
    public void Start()
    {
        CheckCountry();
        AssignEnemyAndFriendlyPrefab();
        SpawnEnemyLeft();
        SpawnEnemyRight();
        SpawnFriendlyLeft();
        SpawnFriendlyRight();
    }

    public void CheckCountry()
    {
        enemyCountry = GameData.Instance.currentOpponent;
    }

    public void AssignEnemyAndFriendlyPrefab()
    {
        enemyPrefab = Resources.Load<GameObject>("ModelsCountries/Enemy" + enemyCountry);
        friendlyPrefab = Resources.Load<GameObject>("FriendlyBots/Enemy" + GameData.Instance.flagName+"F");
    }

    public void SpawnEnemyLeft()
    {
        Instantiate(enemyPrefab, enemyLeftPosition.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemyLeftPosition.position + new Vector3(1,0,0), Quaternion.identity);
        Instantiate(enemyPrefab, enemyLeftPosition.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }

    public void SpawnEnemyRight()
    {
        Instantiate(enemyPrefab, enemyRightPosition.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemyRightPosition.position + new Vector3(1, 0, 0), Quaternion.identity);
    }

    public void SpawnFriendlyLeft()
    {
        Instantiate(friendlyPrefab, friendlyLeftPosition.position, Quaternion.identity);
        Instantiate(friendlyPrefab, friendlyLeftPosition.position + new Vector3(1, 0, 0), Quaternion.identity);
        Instantiate(friendlyPrefab, friendlyLeftPosition.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }

    public void SpawnFriendlyRight()
    {
        Instantiate(friendlyPrefab, friendlyRightPosition.position, Quaternion.identity);
    }
}
