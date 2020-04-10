using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;


    void Start()
    {
        cam = Camera.main;
        cam.transform.position = new Vector3(GenerateMesh.meshWidth / 2, GenerateMesh.meshMaxHeight + 10, GenerateMesh.meshLength / 2);
        cam.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        
    }


}
