using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;

    Vector3 input = Vector3.zero;
    void Start()
    {
        cam = Camera.main;
        transform.position = cam.transform.position;
        transform.rotation = cam.transform.rotation;
        cam.transform.position = new Vector3(Terrain.GenerateMesh.meshWidth, Terrain.GenerateMesh.meshMaxHeight + 25, Terrain.GenerateMesh.meshLength * 1.5f / 2);
        cam.transform.rotation = Quaternion.Euler(60, 0, 0);
        
    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Forwards"), Input.GetAxis("Vertical"));
        cam.transform.position = new Vector3(cam.transform.position.x + input.x, cam.transform.position.y + input.y, cam.transform.position.z + input.z);
    }


}
