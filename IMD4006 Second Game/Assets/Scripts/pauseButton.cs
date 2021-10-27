using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    //GameObject vehicle;
    public Button yourButton;
    //vehicleController[] vehicles;
    // Start is called before the first frame update
    void Start()
    {
        //vehicle = GameObject.FindGameObjectWithTag("Vehicle");
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        //vehicles = GetComponents<vehicleController>();
    }
        
    void TaskOnClick(){
        
        GameObject[] vehicles ;
        vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach(GameObject vehicle in vehicles) {
            if (vehicle.GetComponent<vehicleController>().pauseVehicle == true){
                vehicle.GetComponent<vehicleController>().pauseVehicle=false;
            } else if (vehicle.GetComponent<vehicleController>().pauseVehicle == false){
                vehicle.GetComponent<vehicleController>().pauseVehicle=true;
            }
         }

        // vehicles = GetComponents<vehicleController>();
        // Debug.Log("i am being pressed");
        // foreach (vehicleController vehicle in vehicles){
        //     vehicle.pauseToggle();
        //     Debug.Log("i am being registered by this car");
        // }
	}
}
