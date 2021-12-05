using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float panSpeed = 150f;
    public float panBorder = 10f;
    public Vector2 cameraLimit;

    public float scrollVel = 150f;
    public float minY = 120f;
    public float maxY = 400f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder){
            pos.z+= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder){
            pos.z-= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder){
            pos.x+= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder){
            pos.x-= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollVel * 100f * Time.deltaTime;
        
        pos.x = Mathf.Clamp(pos.x, -cameraLimit.x, cameraLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -cameraLimit.y, cameraLimit.y);

        transform.position = pos;
    }
}
