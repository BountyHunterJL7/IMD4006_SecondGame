using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleUiCheck : MonoBehaviour
{
    GameObject[] liveVehicles;
    public GameObject input1;
    public GameObject input2;
    public GameObject input3;
    public GameObject desc1;
    public GameObject desc2;
    public GameObject desc3;
    // Start is called before the first frame update
    void Start()
    {
        liveVehicles = GameObject.FindGameObjectsWithTag("Vehicle");

        desc1.GetComponent<Transform>().position = new Vector3(50,25*liveVehicles.Length,0);
        input1.GetComponent<Transform>().position = new Vector3(120,25*liveVehicles.Length,0);
        desc2.GetComponent<Transform>().position = new Vector3(205,25*liveVehicles.Length,0);
        input2.GetComponent<Transform>().position = new Vector3(265,25*liveVehicles.Length,0);
        desc3.GetComponent<Transform>().position = new Vector3(335,25*liveVehicles.Length,0);
        input3.GetComponent<Transform>().position = new Vector3(415,25*liveVehicles.Length,0);

        for (int i = 0; i<liveVehicles.Length; i++){
            liveVehicles[i] = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
