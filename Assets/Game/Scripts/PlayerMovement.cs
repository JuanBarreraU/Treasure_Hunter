using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbPlayerRB;
    public float fltMaxVelocity;
    public bool blGoToRight = false;
    public bool blGoToLeft = false;
    public bool blGoToUp = false;
    public bool blCanUp = false;
    private Animator animPlayerAnimator;

	// Use this for initialization
	void Start ()
    {
        rgbPlayerRB = this.GetComponent<Rigidbody2D>();
        animPlayerAnimator = this.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(blGoToRight == true)
        {
            rgbPlayerRB.velocity = new Vector2(fltMaxVelocity, rgbPlayerRB.velocity.y)* Time.deltaTime;
        }
       
        if(blGoToLeft == true)
        {
            rgbPlayerRB.velocity = new Vector2(-fltMaxVelocity, rgbPlayerRB.velocity.y)* Time.deltaTime;
        }

        if(blGoToUp == true)
        {
            rgbPlayerRB.velocity = new Vector2(rgbPlayerRB.velocity.x , fltMaxVelocity) * Time.deltaTime;
        }
	}

    public void MoveToRight()
    {
        animPlayerAnimator.SetBool("Walk", true);
        this.transform.localScale = new Vector3(0.175f, 0.175f, 0f);
        blGoToRight = true;
    }

    public void MoveToLeft()
    {
        animPlayerAnimator.SetBool("Walk", true);
        this.transform.localScale = new Vector3(-0.175f, 0.175f, 0f);
        blGoToLeft = true;
    }

    public void MoveToUp()
    {
        if(blCanUp == true)
        {
            animPlayerAnimator.SetBool("Up", true);
            this.transform.localScale = new Vector3(0.175f, 0.175f, 0f);
            blGoToUp = true;
        }
    }

    public void Idle()
    {
        rgbPlayerRB.velocity = new Vector2(0f, 0f);
        animPlayerAnimator.SetBool("Walk", false);
        animPlayerAnimator.SetBool("Up", false);
        blGoToRight = false;
        blGoToLeft = false;
        blGoToUp = false;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Stairs")
        {
            blCanUp = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Stairs")
        {
            blCanUp = false;
        }
    }
}
