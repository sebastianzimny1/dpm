using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopUp : MonoBehaviour
{
    public TextMeshPro textMesh;
    private Color textColor;
    private Transform playerTransform;
    private float dissapearTimer = 0.5f;
    private float fadeOutSpeed = 5f;
    private float moveYSpeed = 1f;

    public void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    public void SetUp(int amount)
    {
        textMesh = GetComponent<TextMeshPro>();
        textColor = textMesh.color;
        textMesh.SetText(amount.ToString());
    }

    public void LateUpdate()
    {
        transform.LookAt(2 * transform.position - playerTransform.position);
        transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f);
        dissapearTimer -= Time.deltaTime;
        if(dissapearTimer <= 0)
        {
            textColor.a -= fadeOutSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a <=0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
