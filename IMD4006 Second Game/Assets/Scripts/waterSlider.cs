using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterSlider : MonoBehaviour
{
    public Slider slider;
    GameObject[] waterTerrain;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        waterTerrain = GameObject.FindGameObjectsWithTag("waterTerrain");
        foreach (GameObject wTerrain in waterTerrain)
        {
            wTerrain.GetComponent<Transform>().localPosition = new Vector3(0, - (slider.value * 0.9f) + 0.8f, 0);
        }
        
    }
}
