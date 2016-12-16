using UnityEngine;
using System.Collections;

public class WeaponEnemyCont : MonoBehaviour {

    public GameObject bulletE;
    public static bool shootEnableE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(shootEnableE)
        {
            GameObject bul = Instantiate(bulletE, transform.position, Quaternion.identity) as GameObject;
            bul.AddComponent<Rigidbody2D>();
            bul.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5000f);
            Destroy(bul, 1.0f);
            shootEnableE = false;
        }
	
	}
}
