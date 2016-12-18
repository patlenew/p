﻿using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    public enum moveType {UseTransform, UsePhysics};
    public moveType moveTypes;
    public Transform[] pathPoints;
    public int currentPath = 0;
    public float reachDistance = 5f;
    float speed = 2.35f;
    Rigidbody2D rigid;
    public GameObject playerRef;
    public GameObject armGunEnemy;
    public bool spottedPlayer;
	SpriteRenderer sprit;
	EnemyScann Scan;

    // Use this for initialization
    void Start () {
		sprit = GetComponent<SpriteRenderer> ();
		Scan = GetComponent<EnemyScann> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
        switch(moveTypes)
        {
            case moveType.UseTransform:

                UseTransform();
                break;
            case moveType.UsePhysics:
                UsePhysics();
                break;
        }

	}


    void UseTransform()
    {
		if (!spottedPlayer) {
			Vector3 dir = pathPoints [currentPath].position - transform.localPosition;
			Vector3 dirNorm = dir.normalized;

			transform.Translate (dirNorm * (speed * Time.fixedDeltaTime));

			if (dir.magnitude <= reachDistance) {
				currentPath++;

				sprit.flipX = false;
				armGunEnemy.transform.localPosition = new Vector3 (0.183f, -0.071f, 0);

				if (currentPath >= pathPoints.Length) {
					sprit.flipX = true;
					currentPath = 0;
					armGunEnemy.transform.localPosition = new Vector3 (-0.183f, -0.071f, 0);
				}
			}
		}//When Spotted
		else
		{
			ChargePlayer ();
		}

    }
	void ChargePlayer()
	{
		Vector3 dirNorm;
		if (transform.position.x > Scan.playerT.position.x)
		{
			sprit.flipX = true;
			dirNorm = Vector2.left;
			armGunEnemy.transform.localPosition = new Vector3 (-0.183f, -0.071f, 0);
		} 
		else
		{
			sprit.flipX = false;
			dirNorm = Vector2.right;

			armGunEnemy.transform.localPosition = new Vector3 (0.183f, -0.071f, 0);

		}

		transform.Translate (dirNorm * (speed * Time.fixedDeltaTime));
	}
    void UsePhysics()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity += new Vector2(dirNorm.x * (speed * Time.fixedDeltaTime),rigid.velocity.y);

        if (dir.magnitude <= reachDistance)
        {
            Debug.Log("aaa");
            currentPath++;
            if (currentPath >= pathPoints.Length)
            {
                currentPath = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        if(pathPoints == null)
        {
            return;
        }

        foreach(Transform pathPoint in pathPoints)
        {
            if(pathPoint)
            {
                Gizmos.DrawSphere(pathPoint.position, reachDistance);
            }
        }
    }

    public void enemyShoot(bool spot)
    {
        spottedPlayer = spot;
       // gameObject.GetComponentInChildren<Transform>().LookAt(refPlayer);
        
    }

    
}
