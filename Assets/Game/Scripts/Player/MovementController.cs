using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float fltDirX;

    //Esta variable corresponde al valor del movimiento en el eje Y.
    private float fltDirY;

    //Variables para el movimiento y el salto, ajustables desde el inspector.
    public float fltMovementSpeed;
    public float fltClimpSpeed;
    public float fltJumpForce;

    //Rigidbody del personaje principal.
    private Rigidbody2D rbPlayer;

    public bool blWalk = false;
    public bool blGoToUpOrDown = false;
    public bool blInFloor = false;
    public bool blCanUpOrDown = false;
    public bool blCanClimp = false;
    public bool blClimp = false;
    public bool blInSubPlatform = false;
    public bool blUp = false;
    public bool blStopClimp = false;

    // Use this for initialization
    void Start ()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();
       if(blInFloor == true)
       {
            Idle();
       }
    }
	
	// Update is called once per frame
	void Update ()
    {
        fltDirX = CrossPlatformInputManager.GetAxis("Horizontal") * fltMovementSpeed * Time.deltaTime;
        fltDirY = CrossPlatformInputManager.GetAxis("Vertical") * fltClimpSpeed * Time.deltaTime;
    }

    public void FixedUpdate()
    {
        if(blInFloor == true)
        {
            this.GetComponent<PlayerAnimationController>().Idle();
        }

        if (blWalk == true)
        {
            rbPlayer.velocity = new Vector2(fltDirX, rbPlayer.velocity.y);
            this.GetComponent<PlayerAnimationController>().Walk();
        }

        

        if(blUp == true && blCanUpOrDown == true)
        { 
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, fltDirY);
            rbPlayer.gravityScale = 0;
            this.GetComponent<PlayerAnimationController>().Up();
        }

        if(blWalk == true && blCanClimp == true && blInSubPlatform == false && blCanUpOrDown == false)
        {
            if(blStopClimp == false)
            {
                Climp();
            }

            if (blStopClimp == true)
            {
                StopClimp();
            }

        }

        Fall();

        
    }

    public void Idle()
    {
        
            rbPlayer.velocity = new Vector2(0f, 0f);
            this.GetComponent<PlayerAnimationController>().Idle();
        
    }

    public void Walk()
    {
        if (blInFloor == true || blInSubPlatform == true || blCanClimp == true)
        {
            blWalk = true;
            blStopClimp = false;
        }
        
    }

    public void StopWalk()
    {
            blWalk = false;
            Idle();
    }

    public void Up()
    { 
        if(blCanUpOrDown == true)
        {
            blUp = true;
        }
        
    }

    public void StopUp()
    {
            blUp = false;
            rbPlayer.velocity = new Vector2(0f, 0f);
            this.GetComponent<PlayerAnimationController>().StopUp();
    }

    public void Climp()
    {

            blClimp = true;
            this.GetComponent<PlayerAnimationController>().Climp();
    }

    public void StopClimp()
    {
        if (blWalk == false && blCanClimp == true && blInSubPlatform == false && blCanUpOrDown == false)
        {
            blStopClimp = true;
            this.GetComponent<PlayerAnimationController>().StopClimp();
        }
    }

    public void Fall()
    {
        if(blInFloor == false && blInSubPlatform == false && blCanUpOrDown == false && blCanClimp == false)
        {
            rbPlayer.gravityScale = 2;
        }
    }

    public void LookToRight()
    {
        this.transform.localScale = new Vector3(0.175f, 0.175f, 0f);
    }

    public void LookToLeft()
    {
        this.transform.localScale = new Vector3(-0.175f, 0.175f, 0f);
    }


}
