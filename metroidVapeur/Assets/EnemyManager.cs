using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    int hp;
    float reloadTime;
    string weaponType;

	// Use this for initialization
	void Start () {

        BasicEnemy baseEne = new BasicEnemy();
        hp = baseEne.hpBasic;
        reloadTime = baseEne.reloadTime;
        weaponType = baseEne.weaponType;

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "bulletPre")
        {
            Debug.Log("kikou");
            Destroy(this);
        }
    }
}
