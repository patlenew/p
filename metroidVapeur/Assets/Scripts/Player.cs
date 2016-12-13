using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    public float wallSlideSpeedMax = 3;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;
    int dir;

    public Vector2 wallJumpClimb, wallJumpOff, wallLeap;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    public bool moveAxis;
    bool jumpTrue = false;
    public GameObject armGun;
   

    Controller2D controller;
    Vector2 _input;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void Update()
    {
        
        flipCharacter();

        Vector2 input = _input;
        int wallDirectionX = (controller.collisions.left) ? -1 : 1;
        
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        bool wallSliding = false;

        if((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0 )
        {
            wallSliding = true;

            if(velocity.y  < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if(timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if(input.x != wallDirectionX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;

                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
                
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

       

        if (Input.GetKeyDown(KeyCode.Space)  || jumpTrue)
        {
            if(wallSliding)
            {
                if(wallDirectionX == input.x)
                {
                    velocity.x = -wallDirectionX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;

                }
                else if(input.x == 0)
                {
                    velocity.x = -wallDirectionX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirectionX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }

            if(controller.collisions.below)
            {
                velocity.y = jumpVelocity;
            }

            
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void flipCharacter()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       if (Input.GetAxisRaw("Horizontal") < 0 || dir == -1)
        {
           gameObject.GetComponent<SpriteRenderer>().flipX = true;
           armGun.transform.localPosition = new Vector3(-.96f, .15f, 0 );
            WeaponController.leftGun = true;
          
        }
        else
        {
            
             gameObject.GetComponent<SpriteRenderer>().flipX = false;
            armGun.transform.localPosition = new Vector3(.96f, .15f, 0);
            WeaponController.leftGun = false;
        }
        
    }

    public void btnFunction(int direction)
    {

        if (direction == 2)      
        {
            //_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _input = new Vector2(1, Input.GetAxisRaw("Vertical"));
            dir = 1;
        }    
        else if (direction == 1)
        {
            _input = new Vector2(-1, Input.GetAxisRaw("Vertical"));
            dir = -1;
        }
        else
        {
            _input = new Vector2(0, Input.GetAxisRaw("Vertical"));
            dir = 0;
        }
        

    }

    public void jumpButton(bool jumpEnable)
    {
        if(jumpEnable)
        {
            jumpTrue = true;
        }
        else
        {
            jumpEnable = false;
            jumpTrue = false;
        }
    }

    
}
