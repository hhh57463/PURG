using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject[] PlayerItemGams = null;                          //0:오른손 무기, 1:왼손 무기, 2:헬멧, 3:조끼
    public GameObject ItemCheckGams = null;

    public BoxCollider ItemBc = null;
    public SpriteRenderer ItemSr = null;

    public bool bItemMoveAllow = false;
    public bool bWearCheck = false;

    public int[] nAmmorCount = new int[3];                              //0:무기, 1:헬멧, 2:조끼
    int nItemType = 0;

    float fItemMoveSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        fItemMoveSpeed = 3.0f;
        bItemMoveAllow = true;
        for (int i = 0; i < nAmmorCount.Length; i++) { nAmmorCount[i] = 0; }
    }

    // Update is called once per frame
    void Update()
    {
        ItemMove();
    }

    void ItemMove()
    {
        if (!SGameMng.I.bPlayerDie && !bItemMoveAllow)
        {
            transform.Translate(Vector3.left * fItemMoveSpeed * Time.deltaTime);
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
            nItemType = 0;
            ItemCheckGams.SetActive(false);
        }
    }

    public void ItemRezen()
    {
        nItemType = Random.RandomRange(1, 5);           //1:무기, 2:근접무기(프라이팬,빠루 등), 3:헬멧, 4:조끼
    }

    private void OnTriggerEnter(Collider col)
    {
        if (bWearCheck)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("이곳에서 아이템이 어느정도 가까워 졌을시 장착 관련");

                switch (nItemType)
                {
                    case 1:
                        Debug.Log("무기장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] == 1)
                        {
                            nAmmorCount[0]++;
                            PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 2:
                        Debug.Log("근접무기장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] == 1)
                        {
                            nAmmorCount[0]++;
                            PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 3:
                        Debug.Log("헬멧장착");
                        if (nAmmorCount[1] == 0)
                        {
                            nAmmorCount[1]++;
                            PlayerItemGams[2].SetActive(true);
                        }
                        break;

                    case 4:
                        Debug.Log("조끼장착");
                        if (nAmmorCount[2] == 0)
                        {
                            nAmmorCount[2]++;
                            PlayerItemGams[3].SetActive(true);
                        }
                        break;
                }


                ItemBc.enabled = false;
                ItemSr.enabled = false;
                ItemCheckGams.SetActive(false);
            }
        }
    }
}