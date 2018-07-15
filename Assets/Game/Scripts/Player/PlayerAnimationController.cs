using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animPlayer;


	// Use this for initialization
	void Start ()
    {
        animPlayer = this.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Walk()
    {
        ResetAllAnimations();
        animPlayer.SetBool("Walk", true);
    }

    public void StopWalk()
    {
        ResetAllAnimations();
        animPlayer.SetBool("Walk", false);
    }
    
    public void StopClimp()
    {
        ResetAllAnimations();
        animPlayer.SetBool("StopClimp", true);
    }

    public void Up()
    {
        ResetAllAnimations();
        animPlayer.SetBool("Up", true);
    }

    public void StopUp()
    {
        ResetAllAnimations();
        animPlayer.SetBool("StopUp", true);
    }

    public void  ResetAllAnimations()
    {
        animPlayer.SetBool("Walk", false);
        animPlayer.SetBool("Up", false);
        animPlayer.SetBool("Idle", false);
        animPlayer.SetBool("StopUp", false);
        animPlayer.SetBool("Climp", false);
        animPlayer.SetBool("StopClimp", false);
    }

    public void Idle()
    {
        ResetAllAnimations();
        animPlayer.SetBool("Idle", true);
    }

    public void Climp()
    {
        ResetAllAnimations();
        animPlayer.SetBool("Climp", true);
    }

}
