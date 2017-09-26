using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    [HideInInspector]
    public float Intensity;
    [HideInInspector]
    public float IntensityChangeSpeed = 0.1f;

    [HideInInspector]
    public Color Color;
    [HideInInspector]
    public float ColorChangeSpeed = 0.1f;

    private Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(light.intensity != Intensity)
        {
            light.intensity = Mathf.Lerp(light.intensity, Intensity, IntensityChangeSpeed);
        }

        if (light.color != Color)
        {
            light.color = Color.Lerp(light.color, Color, ColorChangeSpeed);
        }
    }
}
