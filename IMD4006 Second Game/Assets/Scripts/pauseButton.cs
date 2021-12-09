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

    public AudioSource vehicle1;
    public AudioSource vehicle2;
    public AudioSource vehicle3;
    public AudioSource vehicle4;
    public AudioSource vehicle5;
    public AudioSource vehicle6;
    public AudioSource vehicle7;

    //public bool allHaveGone = false;

    private bool firstStart = false;
    //vehicleController[] vehicles;
    // Start is called before the first frame update
    void Start()
    {
        //vehicle = GameObject.FindGameObjectWithTag("Vehicle");
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        //vehicles = GetComponents<vehicleController>();
    }

    IEnumerator ExampleCoroutine(GameObject[] vehicleArray)
    {
        firstStart=true;
        high.volume = 0.5f;
        low.volume = 0;
        for (int i = 0; i < vehicleArray.Length; i++){
            yield return new WaitForSeconds(1);

            vehicleArray[i].GetComponent<vehicleController>().pauseVehicle=false;

            if (vehicleArray.Length >= 0){
                vehicle1.volume = 0.2f;
            } if (vehicleArray.Length >= 2){
                vehicle2.volume = 0.2f;
            } if (vehicleArray.Length >= 4){
                vehicle3.volume = 0.2f;
            } if (vehicleArray.Length >= 6){
                vehicle4.volume = 0.2f;
            } if (vehicleArray.Length >= 8){
                vehicle5.volume = 0.2f;
            } if (vehicleArray.Length >= 9){
                vehicle6.volume = 0.2f;
            } if (vehicleArray.Length >= 10){
                vehicle1.volume = 0.2f;
            }
        }
        //allHaveGone = true;
    }
        
    void TaskOnClick(){
        GameObject[] tutorial ;
            tutorial = GameObject.FindGameObjectsWithTag("tutorial");
            foreach(GameObject text in tutorial) {
                if (text.activeInHierarchy == true){
                    text.SetActive(false);
                }
            }
        
        GameObject[] vehicles ;
        vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        if (!firstStart){
            StartCoroutine(ExampleCoroutine(vehicles));
        } else {
            foreach(GameObject vehicle in vehicles) {
            //if (allHaveGone==true){
            if (vehicle.GetComponent<vehicleController>().pauseVehicle == true){
                vehicle.GetComponent<vehicleController>().pauseVehicle=false;                
                high.volume = 0.5f;
                low.volume = 0;

                if (vehicles.Length >= 0){
                vehicle1.volume = 0.2f;
            } if (vehicles.Length >= 2){
                vehicle2.volume = 0.2f;
            } if (vehicles.Length >= 4){
                vehicle3.volume = 0.2f;
            } if (vehicles.Length >= 6){
                vehicle4.volume = 0.2f;
            } if (vehicles.Length >= 8){
                vehicle5.volume = 0.2f;
            } if (vehicles.Length >= 9){
                vehicle6.volume = 0.2f;
            } if (vehicles.Length >= 10){
                vehicle1.volume = 0.2f;
            }
            }  else if (vehicle.GetComponent<vehicleController>().pauseVehicle == false){
                vehicle.GetComponent<vehicleController>().pauseVehicle=true;
                high.volume = 0;
                low.volume = 0.5f;
                vehicle1.volume = 0;
                vehicle2.volume = 0;
                vehicle3.volume = 0;
                vehicle4.volume = 0;
                vehicle5.volume = 0;
                vehicle6.volume = 0;
                vehicle7.volume = 0;

            }
            //}
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
