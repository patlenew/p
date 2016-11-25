using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject bulletCont; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject bul = Instantiate(bulletCont, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity) as GameObject;
            /* Controller2D controller = bul.GetComponent<Controller2D>();
             BulletContainer bulCont = bul.GetComponent<BulletContainer>();
             bulCont.velocityBul.x += 200f * Time.deltaTime;
             */
            bul.AddComponent<Rigidbody2D>();
            bul.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5000f);

            Destroy(bul, 1.0f);
        }
	}
}
