using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTextMng : MonoBehaviour {

    //public Player PlayerSc = null;

    public Text PlayerHp = null;
    public Text Survivor = null;

	void Start () {

	}

	void Update () {
		
        PlayerHp.text = SGameMng.I.nPlayerHp.ToString();
        Survivor.text = SGameMng.I.nSurvivor.ToString();
	}
}
