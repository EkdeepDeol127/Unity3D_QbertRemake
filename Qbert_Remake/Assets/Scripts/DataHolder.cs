using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public int[] highScores;
    public string[] initials;
    public int location = 0;

    public void NewHighScore(string playerName, int amount)
    {
        initials[location] = playerName;
        highScores[location] = amount;
    }

    public bool checkHighScore(int amount)
    {
        bool check = false;
        for (int j = 0; j < 10; j++)
        {
            if (highScores[j] < amount)
            {
                check = true;
                location = j;
                break;
            }
        }
        if(check == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
