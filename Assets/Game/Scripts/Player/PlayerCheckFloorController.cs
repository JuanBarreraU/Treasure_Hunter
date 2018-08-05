using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckFloorController : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Platform")
        {
            //this.GetComponentInParent<PlayerMovementController>().blInFloor = true;
            this.GetComponentInParent<MovementController>().blInFloor = true;
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 2;
        }

        if(col.tag == "SubPlatformDef")
        {
            this.GetComponentInParent<MovementController>().blInSubPlatform = true;
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            print("Subplatform");
        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Platform")
        {
            this.GetComponentInParent<MovementController>().blInFloor = false;
        }
        if (col.tag == "SubPlatformDef")
        {
            this.GetComponentInParent<MovementController>().blInSubPlatform = false;
            //this.GetComponentInParent<Rigidbody2D>().gravityScale = 2;
        }
    }

}
