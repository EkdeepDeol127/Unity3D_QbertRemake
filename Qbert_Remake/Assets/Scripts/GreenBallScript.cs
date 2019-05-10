using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallScript : MonoBehaviour {

    public StageScript stage;
    public QBertScript Qbert;
    private GameObject greenBall;
    public int Vertical = 0;
    public int Horizontal = 0;
    private int rand;
    private float timer = 1;
    public bool died = true;

    void Start()
    {
        greenBall = this.gameObject;
        greenBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
    }

    void Update()
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
                    greenBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Vertical < 6)//left
                {
                    Vertical++;
                    greenBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else
                {
                    died = true;
                    greenBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void spawnGreenBall()
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
        greenBall.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
        died = false;
    }

    public void reset()
    {
        timer = 1f;
        died = true;
        greenBall.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
    }

    public void stopTime()
    {
        Debug.Log("Time STOP!");
    }

    private void checkIfSameTile()
    {
        if (Qbert.Vertical == Vertical && Qbert.Horizontal == Horizontal)
        {
            stopTime();
            reset();
        }
    }
}
