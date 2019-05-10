using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBertScript : MonoBehaviour {

    public StageScript stage;
    public ElevatorScript elevator1;
    public ElevatorScript elevator2;
    public InGameMenu gameMenu;
    public UIBehavior UI;
    public SnackEgg egg;
    public SnakeCoil coil;
    public RedBallScript redBall;
    public GreenBallScript greenBall;
    private GameObject QBert;
    public bool onElevator = false;
    public int Vertical = 0;
    public int Horizontal = 0;
    public bool jumpedOff = false;

    void Start ()
    {
        QBert = this.gameObject;
        QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
    }
	
	void Update ()
    {
		if(Input.anyKeyDown && onElevator == false)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Keypad7))//top left
            {
                if (Vertical > 0 && Horizontal > 0)
                {
                    Vertical--;
                    Horizontal--;
                    QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorPos(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else if(Vertical == 4 && Horizontal == 0)//left elevator ("elevator (2)")
                {
                    QBert.transform.position = stage.GridV[7].GridH[1].GetComponentInParent<Transform>().transform.position;
                    onElevator = true;
                    elevator2.thisOne();
                }
                else
                {
                    jumpedOff = true;
                    qbertDied();
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Keypad3))//bottom right
            {
                if (Vertical < 6)
                {
                    Vertical++;
                    Horizontal++;
                    QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorPos(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else
                {
                    jumpedOff = true;
                    qbertDied();
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Keypad1))//bottom left
            {
                if (Vertical < 6)
                {
                    Vertical++;
                    QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorPos(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else
                {
                    jumpedOff = true;
                    qbertDied();
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Keypad9))//top right
            {
                if (Vertical > 0 && Horizontal < Vertical)
                {
                    Vertical--;
                    QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    stage.changeColorPos(Vertical, Horizontal);
                    checkIfSameTile();
                }
                else if (Vertical == 4 && Horizontal == 4)//right elevator ("elevator")
                {
                    QBert.transform.position = stage.GridV[7].GridH[0].GetComponentInParent<Transform>().transform.position;
                    onElevator = true;
                    elevator1.thisOne();
                }
                else
                {
                    jumpedOff = true;
                    qbertDied();
                }
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                gameMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("Invalid Input");
            }
        }
	}

    public void qbertDied()
    {
        UI.LifeLoss();
        reset();
    }

    public void reset()
    {
        if((jumpedOff || onElevator == true))//so qbert only respawns at the top if he fell off the pyramid
        {
            Vertical = 0;
            Horizontal = 0;
            jumpedOff = false;
        }
        QBert.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
    }

    private void checkIfSameTile()
    {
        if ((Vertical == egg.Vertical && Horizontal == egg.Horizontal) || (Vertical == coil.Vertical && Horizontal == coil.Horizontal) 
            || (Vertical == redBall.Vertical && Horizontal == redBall.Horizontal))
        {
            qbertDied();
            egg.reset();
            coil.reset();
            redBall.reset();
            greenBall.reset();
        }
        else if(Vertical == greenBall.Vertical && Horizontal == greenBall.Horizontal)
        {
            greenBall.stopTime();
            greenBall.reset();
        }
    }
}
