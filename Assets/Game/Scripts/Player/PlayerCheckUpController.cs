using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckUpController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.tag == "Stairs")
        //{

        //    if (this.GetComponentInParent<PlayerMovementController>().blInFloor == false)
        //    {
        //        this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        //        this.GetComponentInParent<PlayerAnimationController>().StopUp();
        //        this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
        //    }

        //}
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Stairs")
        {
            this.GetComponentInParent<PlayerMovementController>().blCanUpOrDown = true;
            if (this.GetComponentInParent<PlayerMovementController>().blInFloor == false &&
                this.GetComponentInParent<PlayerMovementController>().blGoToUpOrDown == false)
            {
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
                this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                this.GetComponentInParent<PlayerAnimationController>().StopUp();
            }

        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Stairs")
        {
            this.GetComponentInParent<PlayerMovementController>().blCanUpOrDown = false;
            //this.GetComponentInParent<PlayerAnimationController>().StopUp();
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 2;

        }
    }
}
