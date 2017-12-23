using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D PlayerRig;
    float fJumpPower = 0.0f;
    [SerializeField] bool bJumpAllow = false;

    // Use this for initialization
    void Start()
    {
        fJumpPower = 500f;
        PlayerRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //float fX = Input.GetAxis("Horizontal");                                     //수평값을 알아오는 변수
        //float fY = Input.GetAxis("Vertical");                                       //수직값을 알아오는 변수

        if (Input.GetMouseButtonDown(0) && !bJumpAllow)
        {
            PlayerRig.AddForce(Vector2.up * fJumpPower);
            bJumpAllow = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            bJumpAllow = false;
        }
    }

}
