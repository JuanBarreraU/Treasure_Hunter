using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimpCheckController : MonoBehaviour {

    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.tag == "Hang")
    //    {

    //    }
    //}

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<MovementController>().blCanClimp = true;
            this.GetComponentInParent<Rigidbody2D>().gravityScale = 0;
            print("Cuerda");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Hang")
        {
            this.GetComponentInParent<MovementController>().blCanClimp = false;
        }
    }
}
