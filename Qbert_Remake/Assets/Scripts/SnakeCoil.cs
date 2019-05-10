using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCoil : MonoBehaviour {

    public StageScript stage;
    public QBertScript Qbert;
    private GameObject snake;
    public int Vertical = 0;
    public int Horizontal = 0;
    private float timer = 1.5f;
    public bool spawned = false;

	void Start ()
    {
        snake = this.gameObject;
        snake.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
    }
	
	void Update ()
    {
        if(spawned == true)
        {
            if (timer <= 0 && Qbert.onElevator == false)//fix movement so its always move closer to qbert
            {
                timer = 1.5f;
                if (Qbert.Horizontal < Horizontal && Horizontal > 0 && Vertical > 0)//top left
                {
                    Vertical--;
                    Horizontal--;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Qbert.Horizontal > Horizontal && Vertical < 6)//bottom right
                {
                    Vertical++;
                    Horizontal++;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Qbert.Vertical < Vertical && Horizontal < Vertical && Vertical > 0)//top right
                {
                    Vertical--;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Qbert.Vertical > Vertical && Vertical < 6)//bottom left
                {
                    Vertical++;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Qbert.Vertical == Vertical && Qbert.Horizontal != Horizontal && Qbert.Horizontal < Horizontal)
                {
                    Vertical--;
                    Horizontal--;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else if (Qbert.Vertical == Vertical && Qbert.Horizontal != Horizontal && Qbert.Horizontal > Horizontal)
                {
                    Vertical--;
                    snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
                    checkIfSameTile();
                }
                else
                {
                    Debug.Log("Snake can't move");
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
	}

    public void spawnSnake(int V, int H)
    {
        Vertical = V;
        Horizontal = H;
        snake.transform.position = stage.GridV[Vertical].GridH[Horizontal].GetComponentInParent<Transform>().transform.position;
        spawned = true;
    }

    public void reset()
    {
        timer = 1.5f;
        spawned = false;
        snake.transform.position = stage.GridV[8].GridH[0].GetComponentInParent<Transform>().transform.position;
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
