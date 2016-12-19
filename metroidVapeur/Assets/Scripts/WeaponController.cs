using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject bulletCont;
    bool activeGun;
    public static bool leftGun;
   
    public AudioSource audioS;
    public AudioClip tir;
    Animator animatorGun;
    [SerializeField]
    bool coold;

	// Use this for initialization
	void Start () {
        animatorGun = GetComponent<Animator>();
        coold = true;
	}
	
	// Update is called once per frame
	void Update () {
	  if((Input.GetKeyDown(KeyCode.E) || activeGun) && coold)
        {
            
            StartCoroutine(coolDownGun());
            GameObject bul;
            animatorGun.SetBool("isShooting", true);
            /* Controller2D controller = bul.GetComponent<Controller2D>();
             BulletContainer bulCont = bul.GetComponent<BulletContainer>();
             bulCont.velocityBul.x += 200f * Time.deltaTime;
             */
            if (leftGun)
            {
                bul = Instantiate(bulletCont, new Vector3(transform.position.x - .55f, transform.position.y + .1f, transform.position.z), Quaternion.identity) as GameObject;
                bul.AddComponent<Rigidbody2D>();
                bul.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4000f);
            }
            else
            {
                bul = Instantiate(bulletCont, new Vector3(transform.position.x + .55f, transform.position.y + .1f, transform.position.z), Quaternion.identity) as GameObject;
                bul.AddComponent<Rigidbody2D>();
                bul.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4000f);
            }

            Destroy(bul, .7f);
            
            activeGun = false;
            audioS.PlayOneShot(tir);
        }

       
	}

    IEnumerator coolDownGun()
    {
        coold = false;
        yield return new WaitForSeconds(.2f);
        animatorGun.SetBool("isShooting", false);
        yield return new WaitForSeconds(.5f);
        coold = true;
        
    }
    


    public void bulletBtn(bool active)
    {
       
        if(active)
        {
            activeGun = active;
            
        }
    }

}
