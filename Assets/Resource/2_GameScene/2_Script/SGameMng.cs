using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{

    private static SGameMng _Instance = null;

    public Player PlayerSc = null;
    public Item ItemSc = null;

    public bool bPlayerDie = false;
    public bool bItemAllow = false;

    public int nItemRand = 0;
    public int nSurvivor = 0;
    public int nNowWeaponType = 0;
    public int nPlayerHp = 0;
    public int nSaveHp = 0;

    public float fBulletDelay = 0.0f;


    public static SGameMng I
    {
        get
        {
            if (_Instance.Equals(null))
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        nPlayerHp = 100;
        nSurvivor = 100;
        nNowWeaponType = 0;                                             //처음엔 주먹
        fBulletDelay = 1.0f;
        StartCoroutine(ItemSpawn());
    }

    private void Update()
    {
        ItemPercent();
        BulletDelaySetting();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("Item"))
                {
                    Debug.Log("이곳에서 아이템 클릭시 하는 이벤트 발생");

                    if (!ItemSc.bWearCheck)
                    {
                        ItemSc.bWearCheck = true;
                        ItemSc.ItemCheckGams.SetActive(true);
                    }
                    else
                    {
                        ItemSc.bWearCheck = false;
                        ItemSc.ItemCheckGams.SetActive(false);
                    }
                }
            }
        }

        //if (nItemRand == 0)
        //{

        //}
        //else if (nItemRand % 2 == 0)                     //짝수           출현
        //{
        //    bItemAllow = true;
        //    ItemSc.bItemMoveAllow = false;
        //    ItemSc.ItemRezen();
        //    //nItemRand = 0;
        //}
        //else/* if (nItemRand & 2 == 1)*/                  //홀수          X   
        //{
        //    bItemAllow = false;
        //    //nItemRand = 0;
        //    ItemSc.bItemMoveAllow = false;
        //    ItemSc.ItemBc.enabled = false;
        //    ItemSc.ItemSr.enabled = false;
        //}

    }

    void ItemPercent()                                                                      //생존자 수에따른 아이템 출현 확률 조정
    {
        if (!ItemSc.bItemStart)
        {
            if (nSurvivor >= 90)
            {
                //Debug.Log("아이템 출현 확률 : 90%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 9)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 79)
            {
                //Debug.Log("아이템 출현 확률 : 80%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 8)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 69)
            {
                //Debug.Log("아이템 출현 확률 : 70%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 7)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 59)
            {
                //Debug.Log("아이템 출현 확률 : 60%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 6)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 49)
            {
                //Debug.Log("아이템 출현 확률 : 50%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 5)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 39)
            {
                //Debug.Log("아이템 출현 확률 : 40%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 4)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 29)
            {
                //Debug.Log("아이템 출현 확률 : 30%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 3)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 19)
            {
                //Debug.Log("아이템 출현 확률 : 20%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 2)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }

            else if (nSurvivor >= 9)
            {
                //Debug.Log("아이템 출현 확률 : 10%");
                if (nItemRand == 0)
                {

                }
                else if (nItemRand <= 1)
                {
                    bItemAllow = true;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.bItemStart = true;
                    ItemSc.ItemRezen();
                    //nItemRand = 0;
                }
                else/* if (nItemRand & 2 == 1)*/
                {
                    bItemAllow = false;
                    //nItemRand = 0;
                    ItemSc.bItemMoveAllow = false;
                    ItemSc.ItemBc.enabled = false;
                    ItemSc.ItemSr.enabled = false;
                }
            }
        }
    }

    public IEnumerator ItemSpawn()
    {
        Debug.Log("코루틴 시작!");
        yield return new WaitForSeconds(5f);
        if (!bPlayerDie)
        {
            nItemRand = Random.Range(1, 11);                                //짝수면 출현 홀수면 X
            //ItemSc.bItemStart = true;
            Debug.Log("랜덤값 지정 완료, 값 : " + nItemRand);
            //StartCoroutine(ItemSpawn());
        }
    }

    void BulletDelaySetting()
    {
        if (PlayerSc.NowWeaponGams.tag == "AR")
        {
            fBulletDelay = 0.05f;
        }
        else if (PlayerSc.NowWeaponGams.tag == "SR")
        {
            fBulletDelay = 1.5f;
        }
        else if (PlayerSc.NowWeaponGams.tag == "SMG")
        {
            fBulletDelay = 0.01f;
        }
        else if (PlayerSc.NowWeaponGams.tag == "Pistol")
        {
            fBulletDelay = 0.5f;
        }
        else if (PlayerSc.NowWeaponGams.tag == "ShotGun")
        {
            fBulletDelay = 1.6f;
        }
        else if (PlayerSc.NowWeaponGams.tag == "Punch")
        {
            fBulletDelay = 1.0f;
        }
    }

}