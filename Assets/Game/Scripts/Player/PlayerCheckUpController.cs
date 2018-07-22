using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckUpController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Stairs")
        {

            if(this.GetComponentInParent<MovementController>().blInFloor == false)
            {
                this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                this.GetComponentInParent<PlayerAnimationController>().StopUp();
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            }
            
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Stairs" )
        {
            this.GetComponentInParent<MovementController>().blCanUpOrDown = true;
            if(this.GetComponentInParent<MovementController>().blGoToUpOrDown == true)
            {
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            }
        //    if (this.GetComponentInParent<PlayerMovementController>().blGoToUpOrDown == true || this.GetComponentInParent<PlayerMovementController>().blInFloor == false && this.GetComponentInParent<PlayerMovementController>().blInSubPlatform == false)
        //    {
        //        this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
        //        this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        //        this.GetComponentInParent<PlayerMovementController>().blWalk = false;
        //    }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Stairs")
        {
            this.GetComponentInParent<MovementController>().blCanUpOrDown = false;
            //this.GetComponentInParent<Rigidbody2D>().gravityScale = 2;
        }
    }
}
