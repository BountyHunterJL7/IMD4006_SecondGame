using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class selectTrackType : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Button yourButton;
    
    GameObject[] thisObject;
        GameObject[] notThis1;
        GameObject[] notThis2;
        GameObject[] notThis3;
        
        GameObject gridPlaced;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        
        gridPlaced = GameObject.FindGameObjectWithTag("grid");

        
        
            thisObject = GameObject.FindGameObjectsWithTag("roadTrack");
            notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
            notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
            notThis3 = GameObject.FindGameObjectsWithTag("wetTrack");
            
    }
    void Update(){
        
        if (gridPlaced.GetComponent<PlaceTrack>().startGridPlaced==false){
            foreach(GameObject trackObject in thisObject){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis1){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis2){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis3){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
        }
    }
        
    void TaskOnClick(){
        

            if (yourButton.name == "roadButton"){
                thisObject = GameObject.FindGameObjectsWithTag("roadTrack");
                notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
                notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
                notThis3 = GameObject.FindGameObjectsWithTag("wetTrack");
            } else if (yourButton.name == "wetButton"){
                thisObject = GameObject.FindGameObjectsWithTag("wetTrack");
                notThis1 = GameObject.FindGameObjectsWithTag("roadTrack");
                notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
                notThis3 = GameObject.FindGameObjectsWithTag("dirtTrack");
            } else if (yourButton.name == "dirtButton"){
                thisObject = GameObject.FindGameObjectsWithTag("dirtTrack");
                notThis1 = GameObject.FindGameObjectsWithTag("roadTrack");
                notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
                notThis3 = GameObject.FindGameObjectsWithTag("wetTrack");
            } else if (yourButton.name == "iceButton"){
                thisObject = GameObject.FindGameObjectsWithTag("iceTrack");
                notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
                notThis2 = GameObject.FindGameObjectsWithTag("roadTrack");
                notThis3 = GameObject.FindGameObjectsWithTag("wetTrack");
            }
            
            foreach(GameObject trackObject in thisObject){
                trackObject.GetComponent<Image>().enabled=true;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis1){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis2){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
            foreach(GameObject trackObject in notThis3){
                trackObject.GetComponent<Image>().enabled=false;
                //notThis1.GetComponent<GameObject>().SetActive(true);
                //notThis2.GetComponent<GameObject>().SetActive(true);
            }
	}
}
