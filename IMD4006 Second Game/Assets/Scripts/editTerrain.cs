using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editTerrain : MonoBehaviour
{
    public GameObject point;
    public GameObject pathParent;
    public Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnMouseOver () 
    {
        if(Input.GetMouseButtonDown(0))
        {
            setParent();
        }
            
        else if(Input.GetMouseButtonDown(1))
        {
            Destroy (gameObject);
             
        }
            
        else if(Input.GetMouseButtonDown(2))
        {
            
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setParent (){
        oldPos = point.transform.position;
        pathParent = GameObject.FindGameObjectWithTag("PathTag");
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        point.transform.parent = pathParent.transform;
        //point.transform.position = oldPos;
    }
}
