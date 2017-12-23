using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{

    private static SGameMng _Instance = null;

    public bool bPlayerDie = false;

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
                    //Destroy(hit.transform);
                    //Debug.Log("ADSFASDFADFADSFAFDASFD");
                }
            }
        }

    }
}