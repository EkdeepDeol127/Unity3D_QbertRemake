using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallScript : MonoBehaviour {

    public StageScript stage;
    public QBertScript Qbert;
    private GameObject redBall;
    public int Vertical = 0;
    public int Horizontal = 0;
    private int rand;
    private float timer = 1;
    public bool died = true;

    void Start ()
    {
        redBall = this.gameObject;
        redBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
    }
	
	void Update ()
    {
        if(died == false)
        {
            if (timer <= 0)
            {
                timer = 1;
                rand = Random.Range(0, 2);
                if ((rand == 1 || rand == 2) && Vertical < 6 && Horizontal < Vertical)//right
                {
                    Vertical++;
                    Horizontal++;
                    redBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorCon(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else if (Vertical < 6)//left
                {
                    Vertical++;
                    redBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorCon(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else
                {
                    died = true;
                    redBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
	}

    public void spawnRedBall()
    {
        Vertical = 0;
        Horizontal = 0;
        rand = Random.Range(0, 2);
        if (rand == 1)//which side to drop on
        {
            Vertical++;
            Horizontal++;
        }
        else
        {
            Vertical++;
        }
        redBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
        stage.changeColorCon(Vertical, Horizontal);//for starting position
        died = false;
    }

    public void reset()
    {
        timer = 1f;
        died = true;
        redBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
    }

    private void checkIfSameTile()
    {
        if (Qbert.Vertical == Vertical && Qbert.Horizontal == Horizontal)
        {
            Qbert.qbertDied();
            reset();
        }
    }
}
