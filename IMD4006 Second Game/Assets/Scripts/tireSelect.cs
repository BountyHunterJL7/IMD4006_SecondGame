using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tireSelect : MonoBehaviour
{
    //Attach this script to a Dropdown GameObject
    Dropdown m_Dropdown;
    //This is the string that stores the current selection m_Text of the Dropdown
    //This Text outputs the current selection to the screen
    //This is the index value of the Dropdown
    int m_DropdownValue;

    GameObject[] wheels = new GameObject[4];
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;

    void Start()
    {
        //Fetch the DropDown component from the GameObject
        m_Dropdown = GetComponent<Dropdown>();
        wheels[0]=wheel1;
        wheels[1]=wheel2;
        wheels[2]=wheel3;
        wheels[3]=wheel4;
    }

    void Update()
    {
        m_DropdownValue = m_Dropdown.value;
        foreach (GameObject wheel in wheels){
            if (m_DropdownValue == 0){
                wheel.GetComponent<enableWheelPhysicMaterial>().race=true;
                wheel.GetComponent<enableWheelPhysicMaterial>().allTerrain=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().dirtnsnow=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().wet=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().studded=false;
            } else if (m_DropdownValue == 1){
                wheel.GetComponent<enableWheelPhysicMaterial>().race=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().allTerrain=true;
                wheel.GetComponent<enableWheelPhysicMaterial>().dirtnsnow=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().wet=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().studded=false;
            } else if (m_DropdownValue == 2){
                wheel.GetComponent<enableWheelPhysicMaterial>().race=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().allTerrain=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().dirtnsnow=true;
                wheel.GetComponent<enableWheelPhysicMaterial>().wet=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().studded=false;
            } else if (m_DropdownValue == 3){
                wheel.GetComponent<enableWheelPhysicMaterial>().race=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().allTerrain=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().dirtnsnow=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().wet=true;
                wheel.GetComponent<enableWheelPhysicMaterial>().studded=false;
            } else if (m_DropdownValue == 4){
                wheel.GetComponent<enableWheelPhysicMaterial>().race=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().allTerrain=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().dirtnsnow=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().wet=false;
                wheel.GetComponent<enableWheelPhysicMaterial>().studded=true;
            } 
        }
       
    }
}
