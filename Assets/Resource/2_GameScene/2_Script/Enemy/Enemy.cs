using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SearchSensor PlayerSearchSensor = null;

    public float fEnemySpeed = 0.0f;

    public bool bAttackForm = false;

    // Use this for initialization
    void Start()
    {
        fEnemySpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        ChangeForm();
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.left * fEnemySpeed * Time.deltaTime);
    }

    void ChangeForm()
    {
        if (PlayerSearchSensor.bPlayerSearch)
            bAttackForm = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("플레이어 사망! 게임 끝.");
        }
    }

    private void OnCollisionStay(Collision col)
    {

    }

}