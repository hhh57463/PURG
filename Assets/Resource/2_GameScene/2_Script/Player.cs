using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] WeaponGams = null;

    public Item ItemSc = null;

    public Transform[] WeaponTr = null;

    public SpriteRenderer[] WeaoponsSr = null;

    Rigidbody PlayerRig;

    float fJumpPower = 0.0f;

    [SerializeField] bool bJumpAllow = false;
    [SerializeField] bool bWeaponSwap = false;

    // Use this for initialization
    void Start()
    {
        fJumpPower = 300.0f;
        PlayerRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        if (Input.GetKey(KeyCode.Space)) { SGameMng.I.fPlayerHp -= 10.0f; }                 //체력 테스트
    }

    void Move()
    {
        //float fX = Input.GetAxis("Horizontal");                                    //수평값을 알아오는 변수
        //float fY = Input.GetAxis("Vertical");                                      //수직값을 알아오는 변수

        //Debug.Log("수평값 : " + fX);
        //Debug.Log("수직값 : " + fY);

        //if (Input.GetMouseButtonDown(0) && !bJumpAllow)
        //{
        //    PlayerRig.AddForce(Vector2.up * fJumpPower);
        //    bJumpAllow = true;
        //}

    }

    public void PlayerJump()
    {
        if (!bJumpAllow)
        {
            PlayerRig.AddForce(Vector3.up * fJumpPower);
            bJumpAllow = true;
        }
    }

    public void WeaponSwap()
    {
        if (ItemSc.nAmmorCount[0] >= 2)
        {
            if (!bWeaponSwap)
            {
                WeaponGams[0].transform.parent = WeaponTr[0];
                WeaponGams[1].transform.parent = WeaponTr[1];
                WeaponGams[0].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
                WeaponGams[1].transform.rotation = Quaternion.Euler(Vector3.zero);
                WeaoponsSr[0].sortingOrder = 10;
                WeaoponsSr[1].sortingOrder = 70;
                bWeaponSwap = true;
                for (int i = 0; i < WeaponGams.Length; i++) { WeaponGams[i].transform.localPosition = Vector3.zero; }
            }
            else
            {
                WeaponGams[0].transform.parent = WeaponTr[1];
                WeaponGams[1].transform.parent = WeaponTr[0];
                WeaponGams[0].transform.rotation = Quaternion.Euler(Vector3.zero);
                WeaponGams[1].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
                WeaoponsSr[0].sortingOrder = 70;
                WeaoponsSr[1].sortingOrder = 10;
                bWeaponSwap = false;
                for (int i = 0; i < WeaponGams.Length; i++) { WeaponGams[i].transform.localPosition = Vector3.zero; }
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            bJumpAllow = false;
        }
    }

}
