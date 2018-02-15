using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject[] WeaponGams = null;
    public GameObject NowWeaponGams = null;                                                         //현재무기
    public GameObject DifferentWeaponGams = null;                                                   //다른손무기
    public GameObject BulletPrefabGams = null;
    public GameObject GlovePrefabGams = null;

    public Transform[] WeaponTr = null;
    public Transform BulletParentTr = null;

    public Item ItemSc = null;

    public SpriteRenderer[] WeaoponsSr = null;

    public Text WeaponText = null;

    Rigidbody PlayerRig = null;

    float fJumpPower = 0.0f;

    [SerializeField] bool bJumpAllow = false;
    [SerializeField] bool bWeaponSwap = false;

    // Use this for initialization
    void Start()
    {
        fJumpPower = 300.0f;
        PlayerRig = GetComponent<Rigidbody>();
        NowWeaponGams.tag = "Punch";
        DifferentWeaponGams.tag = "Punch";
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        if (Input.GetKey(KeyCode.Space)) { SGameMng.I.nPlayerHp -= 10; }                 //체력 테스트
    }

    void Move()
    {
        //float fX = Input.GetAxis("Horizontal");                                    //수평값을 알아오는 변수
        //float fY = Input.GetAxis("Vertical");                                      //수직값을 알아오는 변수

        //Debug.Log("수평값 : " + fX);
        //Debug.Log("수직값 : " + fY);

        //if (Input.GetMouseButtonDown(0) && !bJumpAllow)
        //{
        //    PlayerRig.AddForce(Vector2.up * fJumpPower);
        //    bJumpAllow = true;
        //}

    }

    public void PlayerJump()
    {
        if (!bJumpAllow)
        {
            PlayerRig.AddForce(Vector3.up * fJumpPower);
            bJumpAllow = true;
        }
    }

    public void BulletShot()
    {
        if (NowWeaponGams.tag == "AR")
        {
            //Debug.Log("AR총알");
            //Instantiate(BulletPrefabGams, Vector3.zero, Quaternion.identity, BulletParentTr);
            Instantiate(BulletPrefabGams, BulletParentTr);
        }
        else if (NowWeaponGams.tag == "SR")
        {
            //Debug.Log("SR총알");
            //Instantiate(BulletPrefabGams, Vector3.zero, Quaternion.identity, BulletParentTr);
            Instantiate(BulletPrefabGams, BulletParentTr);
        }
        else if (NowWeaponGams.tag == "SMG")
        {
            //Debug.Log("SMG총알");
            //Instantiate(BulletPrefabGams, Vector3.zero, Quaternion.identity, BulletParentTr);
            Instantiate(BulletPrefabGams, BulletParentTr);
        }
        else if (NowWeaponGams.tag == "ShotGun")
        {
            //Debug.Log("ShoutGun총알");
            //Instantiate(BulletPrefabGams, Vector3.zero, Quaternion.identity, BulletParentTr);
            Instantiate(BulletPrefabGams, BulletParentTr);
        }
        else if (NowWeaponGams.tag == "Pistol")
        {
            //Debug.Log("Pistol총알");
            //Instantiate(BulletPrefabGams, Vector3.zero, Quaternion.identity, BulletParentTr);
            Instantiate(BulletPrefabGams, BulletParentTr);
        }
        else if (NowWeaponGams.tag == "Punch")
        {
            //Debug.Log("근접공격");
            Instantiate(GlovePrefabGams, BulletParentTr);
        }
    }

    public void WeaponSwap()
    {
        if (ItemSc.nAmmorCount[0] >= 1)
        {
            if (!bWeaponSwap)
            {
                WeaponGams[0].transform.parent = WeaponTr[0];
                WeaponGams[1].transform.parent = WeaponTr[1];
                WeaponGams[0].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
                WeaponGams[1].transform.rotation = Quaternion.Euler(Vector3.zero);
                WeaoponsSr[0].sortingOrder = 10;
                WeaoponsSr[1].sortingOrder = 70;
                bWeaponSwap = true;
                for (int i = 0; i < WeaponGams.Length; i++) { WeaponGams[i].transform.localPosition = Vector3.zero; }
            }
            else
            {
                WeaponGams[0].transform.parent = WeaponTr[1];
                WeaponGams[1].transform.parent = WeaponTr[0];
                WeaponGams[0].transform.rotation = Quaternion.Euler(Vector3.zero);
                WeaponGams[1].transform.rotation = Quaternion.Euler(0f, 0f, -110f);
                WeaoponsSr[0].sortingOrder = 70;
                WeaoponsSr[1].sortingOrder = 10;
                bWeaponSwap = false;
                for (int i = 0; i < WeaponGams.Length; i++) { WeaponGams[i].transform.localPosition = Vector3.zero; }
            }
            StartCoroutine(SearchWeapon());                                                         //현재 무기 뭔지 알아오는 코루틴
        }
    }

    IEnumerator SearchWeapon()
    {
        yield return new WaitForSeconds(0.1f);
        NowWeaponGams = GameObject.Find("RightWeapon").transform.GetChild(0).gameObject;
        DifferentWeaponGams = GameObject.Find("LeftWeapon").transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            bJumpAllow = false;
        }
    }

}
