using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimpCheckController : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            
            if (this.GetComponentInParent<PlayerMovementController>().blCanUpOrDown == false)
            {
                //this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                this.GetComponentInParent<PlayerAnimationController>().StopClimp();
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            }

        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<PlayerMovementController>().blCanClimp = true;
            if (this.GetComponentInParent<PlayerMovementController>().blCanClimp == true || this.GetComponentInParent<PlayerMovementController>().blInFloor == false && this.GetComponentInParent<PlayerMovementController>().blInSubPlatform == false)
            {
                this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
                this.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                this.GetComponentInParent<PlayerMovementController>().blWalk = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<PlayerMovementController>().blCanClimp = false;
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 2;
        }
    }
}
