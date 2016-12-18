using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    public  Vector3 velocityBul;
	public bool isEnemyBullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if (!isEnemyBullet && col.gameObject.name == "EnnemiPre") 
		{
			Debug.Log ("kikou");
			Destroy (col.gameObject);
		} 
		else if (isEnemyBullet && col.gameObject.name == "Player")
		{
			Debug.Log ("player ded");

		}
		else if (isEnemyBullet && col.gameObject.name == "EnnemiPre")
		{
			Debug.Log ("jme tire la face lgros");

		}

			
    }
}
