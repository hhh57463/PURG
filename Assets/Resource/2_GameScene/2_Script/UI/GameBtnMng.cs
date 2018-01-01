using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnMng : MonoBehaviour {

    public Player PlayerSc = null;

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
        Debug.Log("공격 버튼!");
    }

}
