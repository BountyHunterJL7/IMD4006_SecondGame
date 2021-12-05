using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrack : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform track;
    public Transform track2;
    public Transform trackC1;
    public Transform trackC2;
    public Transform trackC3;
    public Transform trackC4;

    public Transform wetTrack;
    public Transform wetTrack2;
    public Transform wetTrackC1;
    public Transform wetTrackC2;
    public Transform wetTrackC3;
    public Transform wetTrackC4;

    public Transform dirtTrack;
    public Transform dirtTrack2;
    public Transform dirtTrackC1;
    public Transform dirtTrackC2;
    public Transform dirtTrackC3;
    public Transform dirtTrackC4;

    public Transform iceTrack;
    public Transform iceTrack2;
    public Transform iceTrackC1;
    public Transform iceTrackC2;
    public Transform iceTrackC3;
    public Transform iceTrackC4;

    public Transform startTrack;
    public Transform car;
    public Transform truck;

    public Transform[] cars;
    public Transform[] trucks;

    public AudioSource high;
    public AudioSource low;
    

    public Transform onMousePrefab;

    public int carSpawnNum=1;
    public int truckSpawnNum=1;
    public bool startGridPlaced = false;

    public Vector3 smoothMousePos;
    [SerializeField] private int height;
    [SerializeField] private int width;

    Vector3 mousePosition;
    private Node[,] nodes;
    private Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        plane = new Plane(Vector3.up, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePositionOnGrid();
    }

    void GetMousePositionOnGrid(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out var enter)){
            mousePosition = ray.GetPoint(enter);
            smoothMousePos = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodes){
                if ((node.cellPos.x <= mousePosition.x +7 && node.cellPos.x >= mousePosition.x -7) && (node.cellPos.z >= mousePosition.z -7 && node.cellPos.z <= mousePosition.z +7) && node.isPlaceable){
                    if (Input.GetMouseButtonUp(0) && onMousePrefab !=null){
                        node.isPlaceable = false;
                        onMousePrefab.GetComponent<ObjFollowMouse>().onGrid = true;
                        onMousePrefab.position = node.cellPos + new Vector3(0, 0.5f, 0);
                        onMousePrefab = null;
                    }
                }
            }
        }
    }

    public void OnMOuseClickOnUI(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(track, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUI2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(track2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIc1(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(trackC1, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIc2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(trackC2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIc3(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(trackC3, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIc4(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(trackC4, mousePosition, Quaternion.identity);
        }
    }

    //wet
    public void OnMOuseClickOnUIw(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrack, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIw2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrack2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIwc1(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrackC1, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIwc2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrackC2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIwc3(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrackC3, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIwc4(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(wetTrackC4, mousePosition, Quaternion.identity);
        }
    }

    //dirt
    public void OnMOuseClickOnUId(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrack, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUId2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrack2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIdc1(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrackC1, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIdc2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrackC2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIdc3(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrackC3, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIdc4(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(dirtTrackC4, mousePosition, Quaternion.identity);
        }
    }

    //ice
    public void OnMOuseClickOnUIi(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrack, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIi2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrack2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIic1(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrackC1, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIic2(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrackC2, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIic3(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrackC3, mousePosition, Quaternion.identity);
        }
    }
    public void OnMOuseClickOnUIic4(){
        if (onMousePrefab == null){
            onMousePrefab = Instantiate(iceTrackC4, mousePosition, Quaternion.identity);
        }
    }

    public void OnMOuseClickOnUIStart(){
        if (onMousePrefab == null){
            startGridPlaced = true;
            onMousePrefab = Instantiate(startTrack, mousePosition, Quaternion.identity);
            
        }
    }

    public void OnMOuseClickOnUIcar(){
        GameObject[] vehicles ;
        vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach(GameObject vehicle in vehicles) {
            if (vehicle.GetComponent<vehicleController>().pauseVehicle == false){
                vehicle.GetComponent<vehicleController>().pauseVehicle=true;
                high.volume=0;
                low.volume=0.5f;
            } 
         }
        if (carSpawnNum < 7){
                onMousePrefab = Instantiate(cars[carSpawnNum-1], GameObject.Find("spawn"+carSpawnNum).transform.position, Quaternion.identity);
                carSpawnNum++;
                onMousePrefab = null;
        }
        
    }

    public void OnMOuseClickOnUItruck(){
        GameObject[] vehicles ;
        vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach(GameObject vehicle in vehicles) {
            if (vehicle.GetComponent<vehicleController>().pauseVehicle == false){
                vehicle.GetComponent<vehicleController>().pauseVehicle=true;
                high.volume=0;
                low.volume=0.5f;
            } 
         }
        if(truckSpawnNum<7){
                onMousePrefab = Instantiate(trucks[truckSpawnNum-1], GameObject.Find("truckSpawn"+truckSpawnNum).transform.position, Quaternion.identity);
                truckSpawnNum++;
                onMousePrefab = null;
        }
        
    }

    
    private void CreateGrid() {
        nodes = new Node[width,height];
        var name = 0;

            for (int i = 0; i < width; i++){
                for (int j = 0; j< height; j++){
                    Vector3 worldPos = new Vector3(-195 + i*65f, 0, -195 + j*65f);
                    Transform obj = Instantiate(gridCellPrefab,worldPos, Quaternion.identity);
                    obj.name = "Cell" + name;
                    nodes[i,j] = new Node(isPlaceable:true, worldPos,obj);
                    name++;
                }
            }
    }
}

public class Node {
    public bool isPlaceable;
    public Vector3 cellPos;
    public Transform obj;

    public Node (bool isPlaceable, Vector3 cellPos, Transform obj){
        this.isPlaceable = isPlaceable;
        this.cellPos = cellPos;
        this.obj = obj;
    }
}
