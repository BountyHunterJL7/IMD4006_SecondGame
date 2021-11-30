using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hideTutorial : MonoBehaviour
{
     public Button yourButton;
     

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
        
    void TaskOnClick(){
        GameObject[] totorialText ;
        totorialText = GameObject.FindGameObjectsWithTag("tutorial");
        foreach(GameObject text in totorialText) {
            if (text.activeInHierarchy == true){
                text.SetActive(false);
            } else if (text.activeInHierarchy == false){
                text.SetActive(true);
            }
         }
	}
}
