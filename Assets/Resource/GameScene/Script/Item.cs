using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public BoxCollider ItemBc = null;
    public SpriteRenderer ItemSr = null;

    public bool bItemMoveAllow = false;
    public bool bWearCheck = false;

    float fItemMoveSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        fItemMoveSpeed = 3.0f;
        bItemMoveAllow = true;
	}
	
	// Update is called once per frame
	void Update () {
        ItemMove();
	}

    void ItemMove()
    {
        if (!SGameMng.I.bPlayerDie && !bItemMoveAllow)
        {
            transform.Translate(Vector2.left * fItemMoveSpeed * Time.deltaTime);
        }

        if (transform.localPosition.x <= -25f) 
        {
            StartCoroutine(SGameMng.I.ItemSpawn());
            SGameMng.I.bItemAllow = false;
            SGameMng.I.nItemRand = 0;
            bItemMoveAllow = true;
            transform.localPosition = Vector3.zero;
            ItemBc.enabled = true;
            ItemSr.enabled = true;
            bWearCheck = false;
            //Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("이곳에서 아이템 장착 관련");
        }
    }

}
