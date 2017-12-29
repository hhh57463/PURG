using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{

    private static SGameMng _Instance = null;

    public Item ItemSc = null;

    public bool bPlayerDie = false;
    public bool bItemAllow = false;

    public int nItemRand = 0;

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
        StartCoroutine(ItemSpawn());
    }

    private void Update()
    {
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
                    }
                    else
                    {
                        ItemSc.bWearCheck = false;
                    }

                }
            }
        }

        if (nItemRand == 0)
        {

        }
        else if (nItemRand % 2 == 0)                     //짝수
        {
            bItemAllow = true;
            ItemSc.bItemMoveAllow = false;
            //nItemRand = 0;
        }
        else/* if (nItemRand & 2 == 1)*/            //홀수
        {
            bItemAllow = false;
            //nItemRand = 0;
            ItemSc.bItemMoveAllow = false;
            ItemSc.ItemBc.enabled = false;
            ItemSc.ItemSr.enabled = false;
        }

    }

    public IEnumerator ItemSpawn()
    {
        Debug.Log("코루틴 시작!");
        yield return new WaitForSeconds(5f);                              
        if (!bPlayerDie)
        {
            nItemRand = Random.Range(1, 10);                                //짝수면 출현 홀수면 X
            Debug.Log("랜덤값 지정 완료, 값 : " + nItemRand);
            //StartCoroutine(ItemSpawn());
        }
    }

}