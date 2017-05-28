using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool move;
    private Vector3 targetPosition;

    public int health = 100;
    private int current_time = 0;
    public int hit_time = 4;
    public int force = 25;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //1
            //var currentMouseClickWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(currentMouseClickWorldSpace);
            // currentMouseClickWorldSpace.z = 0;
            //transform.position = currentMouseClickWorldSpace;
            //---------------------
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
            if (move == false)
                move = true;

        }
        if (Input.GetKeyDown("r"))
        {
            if (speed == 1)
            {
                speed = 0.5f;
            }
            else
            {
                speed = 1;
            }
        }
        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (transform.position == targetPosition)
        {
            move = false;
        }
        if (move && speed == 2)
        {

        }



    }
    void locatePosition()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(targetPosition);

        }

    }
}
