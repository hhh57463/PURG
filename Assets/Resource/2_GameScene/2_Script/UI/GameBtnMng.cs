using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnMng : MonoBehaviour
{

    public Player PlayerSc = null;

    public bool bAttackBtnAllow = false;
    public bool bBulletShot = false;

    public float fBulletDelay = 0.0f;

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
        if (!bBulletShot)
        {
            fBulletDelay = Time.time;
            SGameMng.I.PlayerSc.BulletShot();
            bBulletShot = true;
        }
        if (Time.time > fBulletDelay + SGameMng.I.fBulletDelay)                                //연사속도
        {
            bBulletShot = false;
        }
    }
}
