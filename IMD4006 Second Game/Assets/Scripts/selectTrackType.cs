using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class selectTrackType : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Button yourButton;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
        
    void TaskOnClick(){
        GameObject[] thisObject;
        GameObject[] notThis1;
        GameObject[] notThis2;
            thisObject = GameObject.FindGameObjectsWithTag("roadTrack");
            notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
            notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
        if (yourButton.name == "roadButton"){
            thisObject = GameObject.FindGameObjectsWithTag("roadTrack");
            notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
            notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
        } else if (yourButton.name == "dirtButton"){
            thisObject = GameObject.FindGameObjectsWithTag("dirtTrack");
            notThis1 = GameObject.FindGameObjectsWithTag("roadTrack");
            notThis2 = GameObject.FindGameObjectsWithTag("iceTrack");
        } else if (yourButton.name == "iceButton"){
            thisObject = GameObject.FindGameObjectsWithTag("iceTrack");
            notThis1 = GameObject.FindGameObjectsWithTag("dirtTrack");
            notThis2 = GameObject.FindGameObjectsWithTag("roadTrack");
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
        
	}
}
