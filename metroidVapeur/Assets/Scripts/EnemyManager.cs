using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public Transform player;
    int hp;
    float reloadTime;
    string weaponType;
    float MaxDist = 7;
    float MinDist = 3;
    float moveSpeed = 4;
    Controller2D controller;
    Vector3 velocity;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float velocityXSmoothing;
    float gravity;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;

    // Use this for initialization
    void Start () {

        controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);

        BasicEnemy baseEne = new BasicEnemy();
        hp = baseEne.hpBasic;
        reloadTime = baseEne.reloadTime;
        weaponType = baseEne.weaponType;

        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        int wallDirectionX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = _input.x * moveSpeed;
       
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        onFollowPlayer();

        if(col.gameObject.name == "bulletPre")
        {
            Debug.Log("kikou");
            Destroy(this);
        }
    }

    void onFollowPlayer()
    {
       // transform.LookAt(player);

        
    }
}
