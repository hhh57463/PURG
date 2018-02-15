using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(NearAttack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NearAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
