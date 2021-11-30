using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snowSlider : MonoBehaviour
{
    public Slider slider;
    GameObject[] snowTerrain;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        snowTerrain = GameObject.FindGameObjectsWithTag("snowTerrain");
        foreach (GameObject sTerrain in snowTerrain)
        {
            sTerrain.GetComponent<Transform>().localPosition = new Vector3(0, slider.value - 0.25f, 0);
        }
        
    }
}
