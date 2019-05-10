using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{

    private string HoldSprite;
    public Sprite newStage;
    public Sprite oldStage;

    void Start()
    {
        //HoldSprite = Resources.Load("Assets/Sprite/"); //to load sprites to change tiles too?
    }


    [System.Serializable]
    public class Grid
    {
        public GameObject[] GridH;
    }
    public Grid[] GridV;

    public void changeColorPos(int V, int H)
    {
        GridV[V].GridH[H].GetComponentInParent<SpriteRenderer>().sprite = newStage;
    }

    public void changeColorCon(int V, int H)
    {
        GridV[V].GridH[H].GetComponentInParent<SpriteRenderer>().sprite = oldStage;
    }
}