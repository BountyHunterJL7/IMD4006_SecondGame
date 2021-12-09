using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roadPerameters : MonoBehaviour
{
    public Slider terrainSlider;

    // Start is called before the first frame update
    void Start()
    {
        terrainSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        GameObject[] terrainType;       
        terrainType = GameObject.FindGameObjectsWithTag("dirtTrack");

        if (terrainSlider.name == "snowCover"){
            terrainType = GameObject.FindGameObjectsWithTag("ice");
        } else if (terrainSlider.name == "wetness"){
            terrainType = GameObject.FindGameObjectsWithTag("wet");
        }

        foreach (GameObject groundTerrain in terrainType)
        {
            groundTerrain.GetComponent<BoxCollider>().material.dynamicFriction=terrainSlider.value;
            groundTerrain.GetComponent<BoxCollider>().material.staticFriction=terrainSlider.value;
        }
        
    }
}
