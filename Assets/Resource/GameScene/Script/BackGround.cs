using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    [SerializeField] Material BackGroundMat = null;

    //public Material[] MapMats = null;

    //[SerializeField] SpriteRenderer MapSr = null;
    //public Sprite[] MapSps = null;

    // Use this for initialization
    void Start()
    {
        BackGroundMat = GetComponent<SpriteRenderer>().material;
        //MapSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bPlayerDie) { BackGroundScroll(); }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    BackGroundMat = MapMats[0];
        //    MapSr.sprite = MapSps[0];
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    BackGroundMat = MapMats[1];
        //    MapSr.sprite = MapSps[1];
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    BackGroundMat = MapMats[2];
        //    MapSr.sprite = MapSps[2];
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    BackGroundMat = MapMats[3];
        //    MapSr.sprite = MapSps[3];
        //}
    }

    void BackGroundScroll()
    {
        Vector2 newOffset = BackGroundMat.mainTextureOffset;

        newOffset.Set(newOffset.x + (0.2f * Time.deltaTime), 0f);
        BackGroundMat.mainTextureOffset = newOffset;
    }

}
