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
    public float fltMovementSpeed = 5f;
    public float fltClimpSpeed;
    public float fltJumpForce = 700f;

    //Rigidbody del personaje principal.
    private Rigidbody2D rbPlayer;

    public bool blWalk = false;
    public bool blGoToUpOrDown = false;
    public bool blInFloor = false;
    public bool blCanUpOrDown = false;




	// Use this for initialization
	void Start ()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        fltDirX = CrossPlatformInputManager.GetAxis("Horizontal")* fltMovementSpeed * Time.deltaTime;
        fltDirY = CrossPlatformInputManager.GetAxis("Vertical") * fltClimpSpeed * Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }

        if (blCanUpOrDown == true && blWalk == false && blGoToUpOrDown == false && blInFloor == false)
        {
            StopUp();
        }
    }

    private void FixedUpdate()
    {
        

        if(blWalk == true)
        {
            rbPlayer.gravityScale = 2;
            rbPlayer.velocity = new Vector2(fltDirX, rbPlayer.velocity.y);
        }

        if(blGoToUpOrDown == true && blCanUpOrDown == true)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, fltDirY);

            if (blCanUpOrDown == false)
            {
                rbPlayer.velocity = new Vector2(0f, 0f);
                blGoToUpOrDown = false;
            }
        }
    }

    public void Idle()
    {
        if(blGoToUpOrDown == false && blWalk == false)
        {
            if(blInFloor == true)
            {
                rbPlayer.velocity = new Vector2(0f, 0f);
                this.GetComponent<PlayerAnimationController>().Idle();
            }
        }
    }

    public void DoJump()
    {
        if(rbPlayer.velocity.y == 0 && blInFloor == true)
        {
            rbPlayer.AddForce(new Vector2(0, fltJumpForce), ForceMode2D.Force);
        }
    }
    
    public void Walk()
    {
        if (blInFloor == true)
        {
            blWalk = true;
            this.GetComponent<PlayerAnimationController>().Walk();
        }
        if(blInFloor == false)
        {
            blWalk = false;

        }
        
    }

    public void StopWalk()
    {
        blWalk = false;
        this.GetComponent<PlayerAnimationController>().StopWalk();
    }

    public void GoToUpOrDown()
    {
        if(blCanUpOrDown == true)
        {
            blGoToUpOrDown = true;
            this.GetComponent<PlayerAnimationController>().Up();
        }

    }

    public void StopUp()
    {
        blGoToUpOrDown = false;
        if (blCanUpOrDown == true)
        {
            rbPlayer.velocity = new Vector2(0f, 0f);
            blGoToUpOrDown = false;
            this.GetComponent<PlayerAnimationController>().StopUp();

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
