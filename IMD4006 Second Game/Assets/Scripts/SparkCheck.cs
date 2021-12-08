using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkCheck : MonoBehaviour
{
    public GameObject spark;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "wall" || col.gameObject.tag == "carBody")
        {
            spark.GetComponent<ParticleSystem>().Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        spark.GetComponent<ParticleSystem>().Stop();
        // if (col.gameObject.tag == "wall" || col.gameObject.tag == "carBody"){
            
        // }
    }
}
