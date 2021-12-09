using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkCheck : MonoBehaviour
{
    public GameObject spark;

    public GameObject oof1;
    public GameObject oof2;
    public GameObject oof3;
    public GameObject oof4;
    public GameObject oof5;

    int oofCheck;

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
            oofCheck = Random.Range(1, 5);

            if (oofCheck == 1){
                oof1.GetComponent<ParticleSystem>().Play();
            } else if (oofCheck == 2){
                oof2.GetComponent<ParticleSystem>().Play();
            } else if (oofCheck == 3){
                oof3.GetComponent<ParticleSystem>().Play();
            } else if (oofCheck == 4){
                oof4.GetComponent<ParticleSystem>().Play();
            } else if (oofCheck == 5){
                oof5.GetComponent<ParticleSystem>().Play();
            } 
        }
    }

    void OnTriggerExit(Collider col)
    {
        spark.GetComponent<ParticleSystem>().Stop();
        oof1.GetComponent<ParticleSystem>().Stop();
        oof2.GetComponent<ParticleSystem>().Stop();
        oof3.GetComponent<ParticleSystem>().Stop();
        oof4.GetComponent<ParticleSystem>().Stop();
        oof5.GetComponent<ParticleSystem>().Stop();
        // if (col.gameObject.tag == "wall" || col.gameObject.tag == "carBody"){
            
        // }
    }
}
