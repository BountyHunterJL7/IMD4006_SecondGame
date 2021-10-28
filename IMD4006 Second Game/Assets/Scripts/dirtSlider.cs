using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dirtSlider : MonoBehaviour
{
    public Slider slider;
    GameObject[] dirtTerrain;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Update is called once per frame
    void ValueChangeCheck()
    {
        dirtTerrain = GameObject.FindGameObjectsWithTag("terrain");
        foreach (GameObject terrain in dirtTerrain)
        {
            terrain.GetComponent<terrainGen>().depth=(int)slider.value;
        }
        
    }
}
