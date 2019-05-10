using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

    public QBertScript Qbert;
    public Transform ElevatorStop;
    public Transform ElevatorStart;
    private bool thisElevator = false;
    private float speed;
	
	void Update ()
    {
        if(Qbert.onElevator == true && thisElevator == true)
        {
            speed = Time.deltaTime * 0.8f;
            if (this.transform.position != ElevatorStop.position)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, ElevatorStop.position, speed);
                Qbert.gameObject.transform.position = this.GetComponentInChildren<Transform>().transform.position;
            }
            else
            {
                Qbert.reset();
                Qbert.onElevator = false;
                thisElevator = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void thisOne()
    {
        thisElevator = true;
    }

    private void reset()
    {
        thisElevator = false;
        this.transform.position = ElevatorStart.position;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}
