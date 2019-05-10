using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public RedBallScript redBall;
    public GreenBallScript greenBall;
    public SnackEgg snakeBall;
    public SnakeCoil snake;
    private float timer = 1;
    private int rand;

	void Start ()
    {

	}

	void Update ()
    {
		if(timer <= 0)
        {
            timer = 3;
            rand = Random.Range(0, 4);
            if (snake.spawned == false && snakeBall.died == true)
            {
                snakeBall.spawnSnakeEgg();
            }
            else if(redBall.died == true && (rand == 1 || rand == 2 || rand == 4))
            {
                redBall.spawnRedBall();
            }
            else if(greenBall.died == true && rand == 3)
            {
                greenBall.spawnGreenBall();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
}
