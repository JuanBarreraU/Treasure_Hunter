using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Esta variable corresponde al valor del movimiento en el eje X.
    private float fltDirX;

    //Esta variable corresponde al valor del movimiento en el eje Y.
    private float fltDirY;

    //Variables para el movimiento y el salto, ajustables desde el inspector.
    public float fltHorizontalSpeed;
    public float fltVerticalSpeed;
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




	// Use this for initialization
	void Start ()
    {
        this.GetComponent<PlayerAnimationController>().Idle();
        rbPlayer = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        fltDirX = CrossPlatformInputManager.GetAxis("Horizontal") * fltHorizontalSpeed * Time.deltaTime;
        fltDirY = CrossPlatformInputManager.GetAxis("Vertical") * fltVerticalSpeed * Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }

        Walk();
        UpAndDown();
    }

    public void MoveToHorizontal()
    {
        if(blInFloor == true || blInSubPlatform == true)
        {
            blWalk = true;
        }
    }

    public void StopMoveToHorizontal()
    {
        blWalk = false;
        if (blInFloor == true || blInSubPlatform == false)
        {
            this.GetComponent<PlayerAnimationController>().Idle();
            rbPlayer.velocity = new Vector2(0, 0);
        }
    }

    public void MoveToVertical()
    {
        if(blInFloor == true && blCanUpOrDown == true || blCanUpOrDown == true)
        {
            blGoToUpOrDown = true;
        }
        
    }

    public void StopMoveToVertical()
    {
        if (blInFloor == false || blCanUpOrDown == true)
        {
            blGoToUpOrDown = false;
            rbPlayer.velocity = new Vector2(0, 0);
        }
    }

    public void Walk()
    {
        if (blWalk == true)
        {
            rbPlayer.velocity = new Vector2(fltDirX, rbPlayer.velocity.y);
            this.GetComponent<PlayerAnimationController>().Walk();
            if (fltDirX == 1)
            {
                LookToRight();
            }
            else if (fltDirX == -1)
            {
                LookToLeft();
            }
        }
    }

    public void UpAndDown()
    {
        if (blGoToUpOrDown == true && blCanUpOrDown == true)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, fltDirY);
            if(blInFloor == false)
            {
                this.GetComponent<PlayerAnimationController>().UpAndDown();
            }
            else if(blInFloor == true || blInSubPlatform == true)
            {
                this.GetComponent<PlayerAnimationController>().Idle();
            }

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

    public void DoJump()
    {
        if (/*rbPlayer.velocity.y == 0 &&*/ blInFloor == true)
        {
            rbPlayer.AddForce(new Vector2(0, fltJumpForce), ForceMode2D.Force);
        }
    }


}
