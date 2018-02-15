using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float fMoveSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        fMoveSpeed = 29.0f;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
        BulletDestroy();
    }

    void BulletMove()
    {
        transform.Translate(Vector3.up * fMoveSpeed * Time.deltaTime);
    }

    void BulletDestroy()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (SGameMng.I.nPlayerHp > 0)
                SGameMng.I.nPlayerHp -= 5;

            Destroy(gameObject);
        }
    }

}
