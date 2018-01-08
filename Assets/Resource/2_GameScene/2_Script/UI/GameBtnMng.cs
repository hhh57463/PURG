using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnMng : MonoBehaviour {

    public Player PlayerSc = null;
    public bool bAttackBtnAllow = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("AttackBtn"))
                {
                    bAttackBtnAllow = true;
                }
            }
        }

        if (bAttackBtnAllow)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform.CompareTag("AttackBtn"))
                    {
                        PlayerAttackBtn();
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                bAttackBtnAllow = false;
            }
        }
    }


    public void PlayerJumpBtn()
    {
        PlayerSc.PlayerJump();
    }

    public void PlayerWeaponSwap()
    {
        PlayerSc.WeaponSwap();
    }

    public void PlayerAttackBtn()
    {
        //Debug.Log("공격 버튼!");
        if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "AR")
        {
            Debug.Log("AR총알");
        }
        else if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "SR")
        {
            Debug.Log("SR총알");
        }
        else if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "SMG")
        {
            Debug.Log("SMG총알");
        }
        else if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "ShotGun")
        {
            Debug.Log("ShoutGun총알");
        }
        else if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "Pistol")
        {
            Debug.Log("Pistol총알");
        }
        else if (SGameMng.I.PlayerSc.NowWeaponGams.tag == "Punch")
        {
            Debug.Log("근접공격");
        }

    }



}
