using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float fBulletSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        fBulletSpeed = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
        BulletMove();
        BulletDestroy();
	}

    void BulletMove()
    {
        transform.Translate(Vector3.up * fBulletSpeed * Time.deltaTime);
    }

    void BulletDestroy()
    {
        if (transform.localPosition.x > 5f)
        {
            Destroy(gameObject);
        }
    }

}
