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

}
