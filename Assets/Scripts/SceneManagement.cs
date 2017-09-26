using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Scenario
{
    [SerializeField]
    public string ScenarioName;

    [SerializeField]
    [Range(0, 20)]
    public float LightsIntensity;

    [SerializeField]
    public Color LightsColor;
}


public class SceneManagement : MonoBehaviour
{
    public Transform LightSelection;
    public Transform SceneSelection;

    public List<Button> LightsButtons;
    //public List<Light> Lights;

    public List<LightsGroups> Groups;
    public List<Scenario> Scenarios;

    private int currentLightIndex;
    private int currentSceneIndex;

    public void LightClicked(int index)
    {
        currentLightIndex = index;

        invertScene();
    }

    public void SceneClicked(int index)
    {
        currentSceneIndex = index;

        var lightButton = LightsButtons[currentLightIndex - 1];
        var lights = Groups[currentLightIndex - 1].Lights;
        var scenario = Scenarios[currentSceneIndex - 1];

        lightButton.GetComponent<Image>().color = new Color(scenario.LightsColor.r, scenario.LightsColor.g, scenario.LightsColor.b, 0.25f);

        foreach (var light in lights)
        {
            light.Color = scenario.LightsColor;
            light.Intensity = scenario.LightsIntensity;
        }

        invertScene();
    }



    private void invertScene()
    {
        var ligthActive = LightSelection.gameObject.activeSelf;
        LightSelection.gameObject.SetActive(!ligthActive);
        SceneSelection.gameObject.SetActive(ligthActive);
    }


    // Use this for initialization
    void Start () {
        LightSelection.gameObject.SetActive(true);
        SceneSelection.gameObject.SetActive(false);
        foreach (var light in LightsButtons)
        {
            light.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.25f);
        }

        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate(478, 718, 60); //2D
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	}
}
