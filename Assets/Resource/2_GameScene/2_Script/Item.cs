using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject[] PlayerItemGams = null;                          //0:오른손 무기, 1:왼손 무기, 2:헬멧, 3:조끼
    public GameObject ItemCheckGams = null;

    public Player PlayerSc = null;

    public BoxCollider ItemBc = null;
    public SpriteRenderer ItemSr = null;

    public bool bItemMoveAllow = false;
    public bool bWearCheck = false;
    public bool bItemStart = false;
    public bool bPlusHp = false;

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
        if (bPlusHp)
        {
            if (SGameMng.I.nSaveHp < 80)
            {
                if (SGameMng.I.nSaveHp + 20 > SGameMng.I.nPlayerHp)
                {
                    SGameMng.I.nPlayerHp++;
                }
                else
                {
                    bPlusHp = false;
                }
            }
            else if (SGameMng.I.nSaveHp >= 80)
            {
                if (SGameMng.I.nPlayerHp < 100)
                {
                    SGameMng.I.nPlayerHp++; 
                }
                else
                {
                    bPlusHp = false;
                }
            }
        }
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
            bItemStart = false;
        }
    }

    public void ItemRezen()
    {
        nItemType = Random.RandomRange(1, 10);           //1:AR, 2:SR, 3,SMG, 4:샷건, 5:권총, 6:근접무기(프라이팬,빠루 등), 7:헬멧, 8:조끼, 9:힐템
        
        //nItemType = 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (bWearCheck)
        {
            if (col.CompareTag("Player"))
            {
                switch (nItemType)
                {
                    case 1:
                        Debug.Log("AR장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "AR";                      //우선 무기종류를 만들지 않았으므로 AR로 대체
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "AR";                //우선 무기종류를 만들지 않았으므로 AR로 대체
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 2:
                        Debug.Log("SR장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;                                   
                            PlayerSc.NowWeaponGams.tag = "SR";                  
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "SR";            
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 3:
                        Debug.Log("SMG장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "SMG";                 
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "SMG";           
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;


                    case 4:
                        Debug.Log("샷건장착");
                        if (nAmmorCount[0] == 0)
                        {                                                    
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "ShotGun";            
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "ShotGun";      
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 5:
                        Debug.Log("권총장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "Pistol";            
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "Pistol";      
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 6:
                        Debug.Log("근접무기장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "Punch";                   //우선 근접무기종류를 만들지 않았으므로 Punch로 대체
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "Punch";             //우선 근접무기종류를 만들지 않았으므로 Punch로 대체
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 7:
                        Debug.Log("헬멧장착");
                        if (nAmmorCount[1] == 0)
                        {
                            nAmmorCount[1]++;
                            PlayerItemGams[2].SetActive(true);
                        }
                        break;

                    case 8:
                        Debug.Log("조끼장착");
                        if (nAmmorCount[2] == 0)
                        {
                            nAmmorCount[2]++;
                            PlayerItemGams[3].SetActive(true);
                        }
                        break;

                    case 9:
                        Debug.Log("힐템");
                        SGameMng.I.nSaveHp = SGameMng.I.nPlayerHp;
                        bPlusHp = true;
                        break;
                }
                ItemBc.enabled = false;
                ItemSr.enabled = false;
                ItemCheckGams.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (bWearCheck)
        {
            if (col.CompareTag("Player"))
            {
                switch (nItemType)
                {
                    case 1:
                        Debug.Log("AR장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "AR";                      //우선 무기종류를 만들지 않았으므로 AR로 대체
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "AR";                //우선 무기종류를 만들지 않았으므로 AR로 대체
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 2:
                        Debug.Log("SR장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "SR";
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "SR";
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 3:
                        Debug.Log("SMG장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "SMG";
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "SMG";
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;


                    case 4:
                        Debug.Log("샷건장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "ShotGun";
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "ShotGun";
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 5:
                        Debug.Log("권총장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "Pistol";
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "Pistol";
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 6:
                        Debug.Log("근접무기장착");
                        if (nAmmorCount[0] == 0)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.NowWeaponGams.tag = "Punch";                   //우선 근접무기종류를 만들지 않았으므로 Punch로 대체
                            //PlayerItemGams[0].SetActive(true);
                        }
                        else if (nAmmorCount[0] >= 1)
                        {
                            nAmmorCount[0]++;
                            PlayerSc.DifferentWeaponGams.tag = "Punch";             //우선 근접무기종류를 만들지 않았으므로 Punch로 대체
                            //PlayerItemGams[1].SetActive(true);
                        }
                        break;

                    case 7:
                        Debug.Log("헬멧장착");
                        if (nAmmorCount[1] == 0)
                        {
                            nAmmorCount[1]++;
                            PlayerItemGams[2].SetActive(true);
                        }
                        break;

                    case 8:
                        Debug.Log("조끼장착");
                        if (nAmmorCount[2] == 0)
                        {
                            nAmmorCount[2]++;
                            PlayerItemGams[3].SetActive(true);
                        }
                        break;

                    case 9:
                        Debug.Log("힐템");
                        SGameMng.I.nSaveHp = SGameMng.I.nPlayerHp;
                        bPlusHp = true;
                        break;
                }
                ItemBc.enabled = false;
                ItemSr.enabled = false;
                ItemCheckGams.SetActive(false);
            }
        }
    }
}