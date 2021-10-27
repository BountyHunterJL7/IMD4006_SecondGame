using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowMouse : MonoBehaviour
{

    private PlaceTrack placeObjectOnGrid;
    public bool onGrid;
    // Start is called before the first frame update
    void Start()
    {
        placeObjectOnGrid = FindObjectOfType<PlaceTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onGrid)
        {
            transform.position = placeObjectOnGrid.smoothMousePos + new Vector3(0, 0.5f, 0);
        }
    }
}
