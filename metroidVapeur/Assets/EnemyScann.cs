using UnityEngine;
using System.Collections;

public class EnemyScann : MonoBehaviour {

    public Transform playerT;
    bool attackMode, onAttackCooldown;
    float absPos;
	SpriteRenderer sprit;
	EnemyFollow Follow;

	public GameObject bulletE;
	// Use this for initialization
	void Start () {
		sprit = GetComponent<SpriteRenderer>();
		Follow = GetComponent<EnemyFollow>();
	}
	
	// Update is called once per frame
	void Update () {

        absPos = Mathf.Abs(playerT.transform.position.x - transform.position.x);

        if(absPos < 12)
        {
            attackMode = true;
            if(!onAttackCooldown)
            {
                onAttackCooldown = true;
				Shoot ();
				Follow.SpottedEnemy(true);
                StartCoroutine(DelayAttack());
            }
        }
        else
        {
            attackMode = false;
			Follow.SpottedEnemy(false);
           
        }
	
	}

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(1f);
        onAttackCooldown = false;

    }
	void Shoot()
	{
		Debug.Log ("spotted");

		GameObject bul = Instantiate(bulletE, transform.GetChild(0).position, Quaternion.identity) as GameObject;
		bul.AddComponent<Rigidbody2D>();
		if(!sprit.flipX)
			bul.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5000f);
		else
			bul.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5000f);

		bul.GetComponent<BulletContainer> ().isEnemyBullet = true;

		Destroy(bul, 1.0f);
	}
}
