using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of the target (player)
        Vector3 targetPosition = target.transform.position;

        // Set the camera's position to match the target's X and Y positions
        transform.position = new Vector3(targetPosition.x, targetPosition.y, -10);
    }
}
