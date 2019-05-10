using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBehavior : MonoBehaviour {

    public Image Life1;
    public Image Life2;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void LifeLoss()
    {
        if(Life1.enabled == false)
        {
            Life2.enabled = false;
        }
        else
        {
            Life1.enabled = false;
        }
    }
}
