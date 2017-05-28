using UnityEngine;
public class CameraController : MonoBehaviour
{

    public float panSpeed = 20f;
    public float panBorderFickness = 10f;
    public float cameraYMax;
    public float cameraYMin;
    public float cameraXMax;
    public float cameraXMin;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderFickness)
        {

            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderFickness)
        {

            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x >= Screen.height - panBorderFickness)
        {

            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x <= panBorderFickness)
        {

            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, cameraXMin, cameraXMax);
        pos.y = Mathf.Clamp(pos.y, cameraYMin, cameraYMax);
        transform.position = pos;

    }
}