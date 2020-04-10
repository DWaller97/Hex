using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;


    void Start()
    {
        cam = Camera.main;
        cam.transform.position = new Vector3(Terrain.GenerateMesh.meshWidth, Terrain.GenerateMesh.meshMaxHeight + 25, Terrain.GenerateMesh.meshLength * 1.5f / 2);
        cam.transform.rotation = Quaternion.Euler(60, 0, 0);
    }

    void Update()
    {
        
    }


}
