using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleController : MonoBehaviour
{
    //basic movement
    [Header("Movement")]
    public float vehiclePower = 100;
    public float steeringAngle = 80;
    public float turnSpeed = 15;
    public float currentSpeed;
    public float maxSpeed = 100;
    public float maxBrakeTorque = 2000;
    public bool brake;
    public bool pauseVehicle = true;

    [Header("Sensors")]
    public float sensorLength = 1f;
    public Vector3 frontSensorPos = new Vector3(0, 0.2f, 0.5f);
    public float frontSideSensorPos = 0.2f;
    public float frontSensorAngle = 30;
 
    [Header("Physics")]
    public WheelCollider[] wheels;
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    public GameObject massCenter;
    public Rigidbody rigidbody;
    //pathfinding
    [Header("Path Finding")]
    public Transform path;
    private List<Transform> points;
    private int currentPoint = 0;
    private bool avoid = false;
    private float targetAngle = 0;
    
    [Header("Tires")]
    public bool race;
    public bool allTerrain;
    public bool dirtnsnow;
    public bool wet;
    public bool studded;

    private void Start (){
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = massCenter.transform.localPosition;
        path = GameObject.FindGameObjectWithTag("PathTag").transform;

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        points = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i ++){
            if (pathTransform[i] != path.transform) {
                points.Add(pathTransform[i]);
            }
        }
    }

    private void FixedUpdate(){
        SensorCheck();
        ApplySteer();
        Drive();
        PointFinder();
        lerpSteerAngle();
        Braking();
        pause();
        TireCheck();
    }

    private void pause() {
        if (pauseVehicle){
            rigidbody.isKinematic = true;

            
        }
        else {
            rigidbody.isKinematic = false;

            Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
            points = new List<Transform>();

            for (int i = 0; i < pathTransform.Length; i ++){
                if (pathTransform[i] != path.transform) {
                    points.Add(pathTransform[i]);
                }
            }
        }
    }

    private void TireCheck(){
        if (race)
        {
            allTerrain = false;
            dirtnsnow = false;
            wet = false;
            studded = false;
        }
        else if (allTerrain)
        {
            race = false;
            dirtnsnow = false;
            wet = false;
            studded = false;
        }
        else if (dirtnsnow)
        {
            race = false;
            allTerrain = false;
            wet = false;
            studded = false;
        }
        else if (wet)
        {
            race = false;
            allTerrain = false;
            dirtnsnow = false;
            studded = false;
        }
        else if (studded)
        {
            race = false;
            allTerrain = false;
            dirtnsnow = false;
            wet = false;
        }
    }

    private void SensorCheck() {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos += transform.forward * frontSensorPos.z;
        sensorStartPos += transform.up * frontSensorPos.y;
        float avoidLevel = 0;
        avoid = false;        

        sensorStartPos += transform.right * frontSideSensorPos;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)) {
            if (!hit.collider.CompareTag("Track")){
                Debug.DrawLine(sensorStartPos, hit.point);
                avoid = true;
                avoidLevel -= 1f;
            }
        }
        

        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength)) {
            if (!hit.collider.CompareTag("Track")){
                Debug.DrawLine(sensorStartPos, hit.point);
                avoid = true;
                avoidLevel -= 0.5f;
            }
        }
        

        sensorStartPos -= transform.right * frontSideSensorPos *2;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)) {
            if (!hit.collider.CompareTag("Track")){
                Debug.DrawLine(sensorStartPos, hit.point);
                avoid = true;
                avoidLevel += 1f;
            }
        }
        

        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength)) {
            if (!hit.collider.CompareTag("Track")){
                Debug.DrawLine(sensorStartPos, hit.point);
                avoid = true;
                avoidLevel += 0.5f;
            }
        }

        if (avoidLevel == 0){
            if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)) {
                if (!hit.collider.CompareTag("Track")){
                    Debug.DrawLine(sensorStartPos, hit.point);
                    avoid = true;
                    if (hit.normal.x< 0) {
                        avoidLevel = -1f;
                    } else {
                        avoidLevel = 1f;
                    }
                }
                
            }
        }

        if(avoid){
            targetAngle = steeringAngle * avoidLevel;
        }
        
    }

    private void ApplySteer() {
        if (avoid) return;
        Vector3 relativeVector = transform.InverseTransformPoint(points[currentPoint].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * steeringAngle;
        targetAngle = newSteer;
    }

    private void Drive() {
        currentSpeed = 2 * Mathf.PI * wheelL.radius * wheelL.rpm * 60/1000;

        if (currentSpeed < maxSpeed && !brake){
            //drive wheels
            foreach (var wheel in wheels){

                wheel.motorTorque = ((vehiclePower * 5) / 4);

            }
        } else {
            foreach (var wheel in wheels){

                wheel.motorTorque = 0;

            }
        }
    }

    private void PointFinder() {
        if (Vector3.Distance(transform.position, points[currentPoint].position) < 7 && currentSpeed > 40){
            brake = true;
        }
        else if (currentSpeed < 30){
            brake=false;
        }
        if (Vector3.Distance(transform.position, points[currentPoint].position) < 3){
            if (currentPoint == points.Count - 1) {
                currentPoint = 0;
            } else{
                currentPoint++;
            }
        }
    }

    private void Braking() {
        if (brake) {
            wheelL.brakeTorque = maxBrakeTorque;
            wheelR.brakeTorque = maxBrakeTorque;
        }else {
            wheelL.brakeTorque = 0;
            wheelR.brakeTorque = 0;
        }
    }

    private void lerpSteerAngle() {
        wheelL.steerAngle = Mathf.Lerp(wheelL.steerAngle, targetAngle, Time.deltaTime * turnSpeed);
        wheelR.steerAngle = Mathf.Lerp(wheelL.steerAngle, targetAngle, Time.deltaTime * turnSpeed);
    }
}
