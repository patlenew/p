using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BulletContainer : MonoBehaviour {

    public  Vector3 velocityBul;
	public bool isEnemyBullet;
           GameObject playerLife, bossLif;
           Main getStuff;
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

                Camera.main.GetComponent<Main>().receiveWin(false);

                playerLife.transform.localScale = new Vector3(0, playerLife.transform.localScale.y);
                Destroy(col.gameObject);

            }
            else
            Destroy(this);

            
      
        }
        else if (isEnemyBullet && col.gameObject.name == "EnnemiPre")
        {
      
            Destroy(this);

        }
        else if (!isEnemyBullet && col.gameObject.name == "mrBoss")
        {
            bossLif = col.gameObject.GetComponent<Boss1_Manager>().bossVie;
            bossLif.transform.localScale = new Vector3(bossLif.transform.localScale.x - .15f, bossLif.transform.localScale.y);
            if (bossLif.transform.localScale.x <= 0)
            {
                Camera.main.GetComponent<Main>() .receiveWin(true);
                
                bossLif.transform.localScale = new Vector3(0, bossLif.transform.localScale.y);
                Destroy(col.gameObject);
            }
            else
            Destroy(this);

            
          
        }

			
    }

   
}
