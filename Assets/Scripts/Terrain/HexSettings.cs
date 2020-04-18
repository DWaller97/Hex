using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSettings : MonoBehaviour
{
    static HexSettings instance;
    public Material heightMat0, heightMat1, heightMat2;
    void Awake()
    {
        instance = this;
    }
    public static HexSettings GetHexSettings(){
        return instance;
    }
}
