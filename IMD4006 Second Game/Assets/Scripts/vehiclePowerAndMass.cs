using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vehiclePowerAndMass : MonoBehaviour
{
    public InputField input;
    int power = 300;
    int vehicleMass = 1000;
    public GameObject vehiclePeram;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.name == "powerInput"){
            if (input.text != ""){
                power = int.Parse(input.text);
            }
            vehiclePeram.GetComponent<vehicleController>().vehiclePower = power;
        } else if (input.name == "massInput"){
            if (input.text != ""){
                vehicleMass = int.Parse(input.text);
            }
            vehiclePeram.GetComponent<Rigidbody>().mass = vehicleMass;
        }
    }
}
