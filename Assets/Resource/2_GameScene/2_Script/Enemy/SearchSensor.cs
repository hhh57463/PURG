using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchSensor : MonoBehaviour {

    public bool bPlayerSearch = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            bPlayerSearch = true;
        }
    }

}
