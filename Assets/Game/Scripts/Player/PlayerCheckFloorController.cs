using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckFloorController : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Platform")
        {
            this.GetComponentInParent<PlayerMovementController>().blInFloor = true;
        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Platform")
        {
            this.GetComponentInParent<PlayerMovementController>().blInFloor = false;
        }
    }

}
