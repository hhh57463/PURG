using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    Material BackGroundMat = null;

    // Use this for initialization
    void Start()
    {
        BackGroundMat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bPlayerDie)
            BackGroundScroll();
    }

    void BackGroundScroll()
    {
        Vector2 newOffset = BackGroundMat.mainTextureOffset;

        newOffset.Set(newOffset.x + (0.2f * Time.deltaTime), 0f);
        BackGroundMat.mainTextureOffset = newOffset;
    }

}
