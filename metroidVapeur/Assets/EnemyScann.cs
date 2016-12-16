using UnityEngine;
using System.Collections;

public class EnemyScann : MonoBehaviour {

    public Transform playerT;
    bool attackMode, onAttackCooldown;
    float absPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        absPos = Mathf.Abs(playerT.transform.position.x - transform.position.x);

        if(absPos < 14)
        {
            attackMode = true;
            if(!onAttackCooldown)
            {
                onAttackCooldown = true;
                StartCoroutine(DelayAttack());
            }
        }
        else
        {
            attackMode = false;
        }
	
	}

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(2f);
        WeaponEnemyCont.shootEnableE = true;
        onAttackCooldown = false;
        Debug.Log("it over");

    }
}
