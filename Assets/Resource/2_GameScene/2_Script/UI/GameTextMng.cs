using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTextMng : MonoBehaviour {

    //public Player PlayerSc = null;

    public Text PlayerHp = null;
    

	void Start () {

	}

	void Update () {
		
        PlayerHp.text = SGameMng.I.fPlayerHp.ToString();
	}
}
