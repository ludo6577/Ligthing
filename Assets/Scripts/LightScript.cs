using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light light;

	// Use this for initialization
	void Start ()
	{
	    light = GetComponent<Light>();
	}

    public void SetColor(Color color)
    {
        light.color = color;
    }
}
