using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleUiCheck : MonoBehaviour
{
    GameObject[] liveVehicles;
    public GameObject input1;
    public GameObject input2;
    public GameObject input3;
    // Start is called before the first frame update
    void Start()
    {
        liveVehicles = GameObject.FindGameObjectsWithTag("Vehicle");

        input1.GetComponent<Transform>().position = new Vector3(50,25*liveVehicles.Length,0);
        input2.GetComponent<Transform>().position = new Vector3(125,25*liveVehicles.Length,0);
        input3.GetComponent<Transform>().position = new Vector3(180,25*liveVehicles.Length,0);

        for (int i = 0; i<liveVehicles.Length; i++){
            liveVehicles[i] = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
