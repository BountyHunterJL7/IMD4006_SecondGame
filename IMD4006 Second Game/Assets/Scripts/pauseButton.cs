using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseButton : MonoBehaviour
{
    //GameObject vehicle;
    public Button yourButton;
    public AudioSource high;
    public AudioSource low;
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
                high.volume = 0.5f;
                low.volume = 0;
            } else if (vehicle.GetComponent<vehicleController>().pauseVehicle == false){
                vehicle.GetComponent<vehicleController>().pauseVehicle=true;
                high.volume = 0;
                low.volume = 0.5f;
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
