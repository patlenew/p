using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BulletContainer : MonoBehaviour {

    public  Vector3 velocityBul;
	public bool isEnemyBullet;
           GameObject playerLife;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isEnemyBullet && col.gameObject.layer == 10)
        {
            Debug.Log("kikou");
            Destroy(col.gameObject);
            Destroy(this);
        }
        else if (isEnemyBullet && col.gameObject.name == "Player")
        {
        
            playerLife = col.gameObject.GetComponent<PlayerController>().playerLifeP;
            playerLife.transform.localScale = new Vector3(playerLife.transform.localScale.x - .15f, playerLife.transform.localScale.y);
            

            if (playerLife.transform.localScale.x <= 0)
            {
                Debug.Log("sssss");
                playerLife.transform.localScale = new Vector3(0, playerLife.transform.localScale.y);
                SceneManager.LoadScene(0);
            }
            Destroy(this);
        }
        else if (isEnemyBullet && col.gameObject.name == "EnnemiPre")
        {
            Debug.Log("jme tire la face lgros");
            Destroy(this);

        }
        else if (!isEnemyBullet && col.gameObject.name == "mrBoss")
        {
            Debug.Log("ses le boss");
        }

			
    }
}
