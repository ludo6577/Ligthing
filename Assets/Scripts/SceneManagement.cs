using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{

    public Transform LightSelection;
    public Transform SceneSelection;

    public List<Light> Lights;

    private int currentLightIndex;
    private int? currentSceneIndex;

    public void LightClicked(int index)
    {
        currentLightIndex = index;

        invertScene();
    }

    public void SceneClicked(int index)
    {
        currentSceneIndex = index;
        var light = Lights[currentLightIndex-1];
        //TODO...
        if (index == 1)
        {
            light.color = new Color(0f,0f,255f,0.5f);
        }
        else if (index == 2)
        {
            light.color = new Color(0f, 255f, 0f, 0.5f);
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
        foreach (var light in Lights)
        {
            light.color = new Color(0f, 0f, 0f, 0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
