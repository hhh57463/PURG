using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SearchSensor PlayerSearchSensor = null;

    public GameObject EnemyBulletPrefabGams = null;
    public GameObject EnemyGlovePrefabGams = null;
    public Transform EnemyBulletParentTr = null;

    public float fEnemySpeed = 0.0f;
    public float fBulletDelay = 0.0f;

    public bool bAttackForm = false;
    public bool bBulletShot = false;

    // Use this for initialization
    void Start()
    {
        fEnemySpeed = 1.0f;
        //무기에 따라 처음 Start부분에서 SGameMng에있는 fEnemyBulletDelay의 속도를 맞춰줘야함.
        SGameMng.I.EnemySpawn();
        switch(SGameMng.I.nEnemyType)
        {
            case 1:
                SGameMng.I.fEnemyBulletDelay = 0.1f;
                break;
            case 2:
                SGameMng.I.fEnemyBulletDelay = 3.0f;
                break;
            case 3:
                SGameMng.I.fEnemyBulletDelay = 0.05f;
                break;
            case 4:
                SGameMng.I.fEnemyBulletDelay = 1.0f;
                break;
            case 5:
                SGameMng.I.fEnemyBulletDelay = 3.0f;
                break;
            case 6:
                SGameMng.I.fEnemyBulletDelay = 2.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        ChangeForm();
        Attack();
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.left * fEnemySpeed * Time.deltaTime);
    }

    void Attack()
    {
        if (bAttackForm)
        {
            if (!bBulletShot)
            {
                fBulletDelay = Time.time;
                BulletShot();
                bBulletShot = true;
            }
            if (Time.time > fBulletDelay + SGameMng.I.fEnemyBulletDelay)                                //연사속도
            {
                bBulletShot = false;
            }
        }
    }

    void ChangeForm()
    {
        if (PlayerSearchSensor.bPlayerSearch)
            bAttackForm = true;
    }

    public void BulletShot()
    {
        if (SGameMng.I.nEnemyType == 1)
        {
            Instantiate(EnemyBulletPrefabGams, EnemyBulletParentTr);
        }
        else if (SGameMng.I.nEnemyType == 2)
        {
            Instantiate(EnemyBulletPrefabGams, EnemyBulletParentTr);
        }
        else if (SGameMng.I.nEnemyType == 3)
        {
            Instantiate(EnemyBulletPrefabGams, EnemyBulletParentTr);
        }
        else if (SGameMng.I.nEnemyType == 4)
        {
            Instantiate(EnemyBulletPrefabGams, EnemyBulletParentTr);
        }
        else if (SGameMng.I.nEnemyType == 5)
        {
            Instantiate(EnemyBulletPrefabGams, EnemyBulletParentTr);
        }
        else if (SGameMng.I.nEnemyType == 6)
        {
            Instantiate(EnemyGlovePrefabGams, EnemyBulletParentTr);
        }
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