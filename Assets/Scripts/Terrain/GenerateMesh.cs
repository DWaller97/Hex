using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Terrain{
    public class GenerateMesh : MonoBehaviour
    {
        HexSettings settings;
        public static int meshWidth = 64, meshLength = 64;
        public static int meshMaxHeight = 3;
        public bool heightModeRandom;
        Dictionary<Vector2, Hex> hexes;

        public enum HeightMode{
            RandomRange,
            Set
        };

        HeightMode mode = HeightMode.RandomRange;

        private void Start() {
            settings = HexSettings.GetHexSettings();
            hexes = new Dictionary<Vector2, Hex>();
            if(heightModeRandom)
                mode = HeightMode.RandomRange;
            else
                mode = HeightMode.Set;
            GeneratePillars(meshWidth, meshLength, Vector3.zero, mode);
        }

        private void GeneratePillars(int width, int length, Vector3 pos, HeightMode heightMode){
            
            int height = 0;
            if(heightMode == HeightMode.Set)
                height = (int)pos.y;

            for(int i = 0; i < width; i++){
                for(int j = 0; j < length; j++){
                    if (heightMode == HeightMode.RandomRange)
                        height = Mathf.RoundToInt(Random.Range(0, 3));
                    int[] indices = new int[48];
                    Vector3[] verts = new Vector3[12];
                    Vector3[] normals = new Vector3[12];
                    
                    verts[0] = new Vector3(1, height, 0.5f);
                    normals[0] = new Vector3(0, 1, 0);
                    verts[1] = new Vector3(1, 0, 0.5f);
                    normals[1] = new Vector3(0, -1, 0);

                    verts[2] = new Vector3(1, height, -0.5f);
                    normals[2] = new Vector3(0, 1, 0);
                    verts[3] = new Vector3(1, 0, -0.5f);
                    normals[3] = new Vector3(0, -1, 0);
                    
                    verts[4] = new Vector3(0, height, -1);
                    normals[4] = new Vector3(0, 1, 0);
                    verts[5] = new Vector3(0, 0, -1);
                    normals[5] = new Vector3(0, -1, 0);
                    
                    verts[6] = new Vector3(-1, height, -0.5f);
                    normals[6] = new Vector3(0, 1, 0);
                    verts[7] = new Vector3(-1, 0, -0.5f);
                    normals[7] = new Vector3(0, -1, 0);
                    
                    verts[8] = new Vector3(-1, height, 0.5f);
                    normals[8] = new Vector3(0, 1, 0);
                    verts[9] = new Vector3(-1, 0, 0.5f);
                    normals[9] = new Vector3(0, -1, 0);
                    
                    verts[10] = new Vector3(0, height, 1);
                    normals[10] = new Vector3(0, 1, 0);
                    verts[11] = new Vector3(0, 0, 1);
                    normals[11] = new Vector3(0, -1, 0);


                    indices[0] = 10; //5
                    indices[1] = 0; //0
                    indices[2] = 2; //1

                    indices[3] = 8; //4
                    indices[4] = 10; //5
                    indices[5] = 2; //1

                    indices[6] = 8; //4
                    indices[7] = 2; //1
                    indices[8] = 4; //2

                    indices[9] = 4; //2
                    indices[10] = 6; //3
                    indices[11] = 8; //4

                    //Pillars
                    indices[12] = 0; 
                    indices[13] = 1;
                    indices[14] = 2;
                    indices[15] = 2;
                    indices[16] = 1;
                    indices[17] = 3;

                    indices[18] = 2; 
                    indices[19] = 3;
                    indices[20] = 4;
                    indices[21] = 4;
                    indices[22] = 3;
                    indices[23] = 5;

                    indices[24] = 4; 
                    indices[25] = 5;
                    indices[26] = 6;
                    indices[27] = 6;
                    indices[28] = 5;
                    indices[29] = 7;

                    indices[30] = 6; 
                    indices[31] = 7;
                    indices[32] = 8;
                    indices[33] = 8;
                    indices[34] = 7;
                    indices[35] = 9;

                    indices[36] = 8; 
                    indices[37] = 9;
                    indices[38] = 10;
                    indices[39] = 10;
                    indices[40] = 9;
                    indices[41] = 11;

                    indices[42] = 10; 
                    indices[43] = 11;
                    indices[44] = 0;
                    indices[45] = 0;
                    indices[46] = 11;
                    indices[47] = 1;

                    

                    GameObject newObj = new GameObject();
                    newObj.transform.position = new Vector3(pos.x + (i * 2) + (j % 2), 0, pos.z + (j * 1.5f));
                    newObj.transform.rotation = Quaternion.identity;


                    Mesh mesh = new Mesh();
                    MeshRenderer renderer = newObj.AddComponent<MeshRenderer>();
                    Material mat;
                    if(height == 0){
                        mat = settings.heightMat0;
                    }else if(height == 1){
                        mat = settings.heightMat1;
                    }else if(height == 2){
                        mat = settings.heightMat2;
                    }else{
                        mat = settings.heightMat0;
                    }
                    renderer.sharedMaterial = mat;
                    MeshFilter filter = newObj.AddComponent<MeshFilter>();
                    mesh.vertices = verts;
                    mesh.triangles = indices;
                    mesh.normals = normals;
                    filter.mesh = mesh;
                    MeshCollider col = newObj.AddComponent<MeshCollider>();

                    Hex newHex = newObj.AddComponent<Hex>();
                    Vector2 gridPos = new Vector2(i, j);
                    newHex.Initialise(height, gridPos);
                    hexes.Add(gridPos, newHex);
                }
            }
        }
    }
}