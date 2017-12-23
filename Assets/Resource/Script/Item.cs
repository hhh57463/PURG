using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    float fItemMoveSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        fItemMoveSpeed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        ItemMove();
	}

    void ItemMove()
    {
        if (!SGameMng.I.bPlayerDie)
        {
            transform.Translate(Vector2.left * fItemMoveSpeed * Time.deltaTime);
        }

        if (transform.localPosition.x <= -25f)
        {
            Destroy(gameObject);
        }
    }

}
