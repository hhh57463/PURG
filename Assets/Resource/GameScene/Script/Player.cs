using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] Weapons = null;

    public Transform[] WeaponTr = null;

    public SpriteRenderer[] WeaoponsSr = null;

    Rigidbody2D PlayerRig;

    float fJumpPower = 0.0f;

    [SerializeField] bool bJumpAllow = false;
    [SerializeField] bool bWeaponSwap = false;

    // Use this for initialization
    void Start()
    {
        fJumpPower = 500f;
        PlayerRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    void Move()
    {
        //float fX = Input.GetAxis("Horizontal");                                     //수평값을 알아오는 변수
        //float fY = Input.GetAxis("Vertical");                                       //수직값을 알아오는 변수

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
            PlayerRig.AddForce(Vector2.up * fJumpPower);
            bJumpAllow = true;
        }
    }

    public void WeaponSwap()
    {
        if (!bWeaponSwap)
        {
            Weapons[0].transform.parent = WeaponTr[0];
            Weapons[1].transform.parent = WeaponTr[1];
            Weapons[0].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
            Weapons[1].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            WeaoponsSr[0].sortingOrder = 10;
            WeaoponsSr[1].sortingOrder = 70;
            bWeaponSwap = true;
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            Weapons[0].transform.parent = WeaponTr[1];
            Weapons[1].transform.parent = WeaponTr[0];
            Weapons[0].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Weapons[1].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
            WeaoponsSr[0].sortingOrder = 70;
            WeaoponsSr[1].sortingOrder = 10;
            bWeaponSwap = false;
            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].transform.localPosition = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            bJumpAllow = false;
        }
    }

}
