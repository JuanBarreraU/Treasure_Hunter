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
        }

        if(col.tag == "SubPlatformDef")
        {
            this.GetComponentInParent<MovementController>().blInSubPlatform = true;
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
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
