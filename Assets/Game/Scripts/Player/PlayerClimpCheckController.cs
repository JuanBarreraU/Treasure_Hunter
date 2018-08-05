using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimpCheckController : MonoBehaviour
{
    public void OnTriggerStart(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
        }
    }



    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<MovementController>().blCanClimp = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<MovementController>().blCanClimp = false;
            this.GetComponentInParent<MovementController>().blClimp = false;
        }
    }
}
