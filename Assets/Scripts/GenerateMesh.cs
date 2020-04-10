using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateMesh : MonoBehaviour
{
    public static int meshWidth = 64, meshLength = 64;
    public static int meshMaxHeight = 10;
    public Shader shader;
    public float heightScale = 30;
    float noiseModifier = 1;
    Mesh mesh;
    Vector3[] verts;
    GameObject[,] objects;
    private void Start() {
        //GenerateHexPlane(128, 128);
        //GenerateHex();
        objects = new GameObject[64, 64];
        for(int i = 0; i < 64; i++){
            for(int j = 0; j < 64; j++){
                objects[i, j] = (GenerateHexPillars(1, 1, new Vector3(i + (1 * i) + (j % 2), Mathf.RoundToInt(Random.Range(0, 3)),(1.5f * j))));
            }
        }
    }

    private void GenerateHexPlane(int width, int length){
        int[] indices = new int[width * length * 12];
        verts = new Vector3[width * length * 6];

        for(int i = 0, indicesCount = 0, vertCount = 0; i < width; i++){
            for(int j = 0; j < length; j++, indicesCount += 12, vertCount += 6){
                noiseModifier = Time.deltaTime;
                verts[vertCount] = new Vector3(1 + (2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, 0.5f + (1.5f * j)); //These aren't needed after the initial hex
                verts[1 + vertCount] = new Vector3(1 + (2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, -0.5f + (1.5f * j)); // ^
                verts[2 + vertCount] = new Vector3((2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, -1 + (1.5f * j));
                verts[3 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, -0.5f + (1.5f * j));
                verts[4 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, 0.5f + (1.5f * j));
                verts[5 + vertCount] = new Vector3((2 * i) + (j % 2), Mathf.PerlinNoise((float)i / width, (float)j / length) * heightScale, 1 + (1.5f * j));

                indices[indicesCount] = 5 + vertCount;
                indices[1 + indicesCount] = vertCount;
                indices[2 + indicesCount] = 1 + vertCount;

                indices[3 + indicesCount] = 4 + vertCount;
                indices[4 + indicesCount] = 5 + vertCount;
                indices[5 + indicesCount] = 1 + vertCount;

                indices[6 + indicesCount] = 4 + vertCount;
                indices[7 + indicesCount] = 1 + vertCount;
                indices[8 + indicesCount] = 2 + vertCount;

                indices[9 + indicesCount] = 2 + vertCount;
                indices[10 + indicesCount] = 3 + vertCount;
                indices[11 + indicesCount] = 4 + vertCount;
            }
        }

        


        mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = new Material(Shader.Find("Hex"));
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        mesh.vertices = verts;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        filter.mesh = mesh;
    }
    private void GenerateHex(){
        const int amount = 1;
        int[] indices = new int[amount * 48];
        verts = new Vector3[amount * 12];
        verts[0] = new Vector3(1, 3, 0.5f);
        verts[1] = new Vector3(1, 0, 0.5f);

        verts[2] = new Vector3(1, 3, -0.5f);
        verts[3] = new Vector3(1, 0, -0.5f);
        
        verts[4] = new Vector3(0, 3, -1);
        verts[5] = new Vector3(0, 0, -1);
        
        verts[6] = new Vector3(-1, 3, -0.5f);
        verts[7] = new Vector3(-1, 0, -0.5f);
        
        verts[8] = new Vector3(-1, 3, 0.5f);
        verts[9] = new Vector3(-1, 0, 0.5f);
        
        verts[10] = new Vector3(0, 3, 1);
        verts[11] = new Vector3(0, 0, 1);

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


        // verts[6] = new Vector3(3, 0, 0.5f);
        // verts[7] = new Vector3(3, 0, -0.5f);
        // verts[8] = new Vector3(2, 0, -1);
        // verts[9] = new Vector3(1, 0, -0.5f);
        // verts[10] = new Vector3(1, 0, 0.5f);
        // verts[11] = new Vector3(2, 0, 1);


        // indices[12] = 11; //5 + 6
        // indices[13] = 6; //0 + 6
        // indices[14] = 7;

        // indices[15] = 10;
        // indices[16] = 11;
        // indices[17] = 7;

        // indices[18] = 10;
        // indices[19] = 7;
        // indices[20] = 8;

        // indices[21] = 8;
        // indices[22] = 9;
        // indices[23] = 10;



        mesh = new Mesh();
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        mesh.vertices = verts;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        filter.mesh = mesh;
    }

    private GameObject GenerateHexPillars(int width, int length, Vector3 pos){
        int[] indices = new int[width * length * 48];
        Vector3[] verts = new Vector3[width * length * 12];
        Vector3[] normals = new Vector3[width * length * 12];
        int height = (int)pos.y;
        for(int i = 0, indicesCount = 0, vertCount = 0, normalCount = 0; i < width; i++){
            for(int j = 0; j < length; j++, indicesCount += 48, vertCount += 12, normalCount += 12){
                verts[vertCount] = new Vector3(1 + (2 * i) + (j % 2), height, 0.5f + (1.5f * j));
                normals[normalCount] = new Vector3(0, 1, 0);
                verts[1 + vertCount] = new Vector3(1 + (2 * i) + (j % 2), 0, 0.5f + (1.5f * j));
                normals[normalCount + 1] = new Vector3(0, -1, 0);

                verts[2 + vertCount] = new Vector3(1 + (2 * i) + (j % 2), height, -0.5f + (1.5f * j));
                normals[normalCount + 2] = new Vector3(0, 1, 0);
                verts[3 + vertCount] = new Vector3(1 + (2 * i) + (j % 2), 0, -0.5f + (1.5f * j));
                normals[normalCount + 3] = new Vector3(0, -1, 0);
                
                verts[4 + vertCount] = new Vector3(0 + (2 * i) + (j % 2), height, -1 + (1.5f * j));
                normals[normalCount + 4] = new Vector3(0, 1, 0);
                verts[5 + vertCount] = new Vector3(0 + (2 * i) + (j % 2), 0, -1 + (1.5f * j));
                normals[normalCount + 5] = new Vector3(0, -1, 0);
                
                verts[6 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), height, -0.5f + (1.5f * j));
                normals[normalCount + 6] = new Vector3(0, 1, 0);
                verts[7 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), 0, -0.5f + (1.5f * j));
                normals[normalCount + 7] = new Vector3(0, -1, 0);
                
                verts[8 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), height, 0.5f + (1.5f * j));
                normals[normalCount + 8] = new Vector3(0, 1, 0);
                verts[9 + vertCount] = new Vector3(-1 + (2 * i) + (j % 2), 0, 0.5f + (1.5f * j));
                normals[normalCount + 9] = new Vector3(0, -1, 0);
                
                verts[10 + vertCount] = new Vector3(0 + (2 * i) + (j % 2), height, 1 + (1.5f * j));
                normals[normalCount + 10] = new Vector3(0, 1, 0);
                verts[11 + vertCount] = new Vector3(0 + (2 * i) + (j % 2), 0, 1 + (1.5f * j));
                normals[normalCount + 11] = new Vector3(0, -1, 0);


                indices[indicesCount] = 10 + vertCount; //5
                indices[1 + indicesCount] = vertCount; //0
                indices[2 + indicesCount] = 2 + vertCount; //1

                indices[3 + indicesCount] = 8 + vertCount; //4
                indices[4 + indicesCount] = 10 + vertCount; //5
                indices[5 + indicesCount] = 2 + vertCount; //1

                indices[6 + indicesCount] = 8 + vertCount; //4
                indices[7 + indicesCount] = 2 + vertCount; //1
                indices[8 + indicesCount] = 4 + vertCount; //2

                indices[9 + indicesCount] = 4 + vertCount; //2
                indices[10 + indicesCount] = 6 + vertCount; //3
                indices[11 + indicesCount] = 8 + vertCount; //4

                //Pillars
                indices[12 + indicesCount] = vertCount; 
                indices[13 + indicesCount] = 1 + vertCount;
                indices[14 + indicesCount] = 2 + vertCount;
                indices[15 + indicesCount] = 2 + vertCount;
                indices[16 + indicesCount] = 1 + vertCount;
                indices[17 + indicesCount] = 3 + vertCount;

                indices[18 + indicesCount] = 2 + vertCount; 
                indices[19 + indicesCount] = 3 + vertCount;
                indices[20 + indicesCount] = 4 + vertCount;
                indices[21 + indicesCount] = 4 + vertCount;
                indices[22 + indicesCount] = 3 + vertCount;
                indices[23 + indicesCount] = 5 + vertCount;

                indices[24 + indicesCount] = 4 + vertCount; 
                indices[25 + indicesCount] = 5 + vertCount;
                indices[26 + indicesCount] = 6 + vertCount;
                indices[27 + indicesCount] = 6 + vertCount;
                indices[28 + indicesCount] = 5 + vertCount;
                indices[29 + indicesCount] = 7 + vertCount;

                indices[30 + indicesCount] = 6 + vertCount; 
                indices[31 + indicesCount] = 7 + vertCount;
                indices[32 + indicesCount] = 8 + vertCount;
                indices[33 + indicesCount] = 8 + vertCount;
                indices[34 + indicesCount] = 7 + vertCount;
                indices[35 + indicesCount] = 9 + vertCount;

                indices[36 + indicesCount] = 8 + vertCount; 
                indices[37 + indicesCount] = 9 + vertCount;
                indices[38 + indicesCount] = 10 + vertCount;
                indices[39 + indicesCount] = 10 + vertCount;
                indices[40 + indicesCount] = 9 + vertCount;
                indices[41 + indicesCount] = 11 + vertCount;

                indices[42 + indicesCount] = 10 + vertCount; 
                indices[43 + indicesCount] = 11 + vertCount;
                indices[44 + indicesCount] = vertCount;
                indices[45 + indicesCount] = vertCount;
                indices[46 + indicesCount] = 11 + vertCount;
                indices[47 + indicesCount] = 1 + vertCount;
            }
        }

        

        GameObject newObj = new GameObject();
        newObj.transform.position = new Vector3(pos.x, 0, pos.z);
        newObj.transform.rotation = Quaternion.identity;


        mesh = new Mesh();
        MeshRenderer renderer = newObj.AddComponent<MeshRenderer>();
        Material mat = new Material(shader);
        mat.SetFloat("_Height", height);
        renderer.sharedMaterial = mat;
        MeshFilter filter = newObj.AddComponent<MeshFilter>();
        
        mesh.vertices = verts;
        mesh.triangles = indices;
        mesh.normals = normals;
        filter.mesh = mesh;
        
        return newObj;
    }

    // void OnDrawGizmos()
    // {
    //     if(verts != null){
    //         foreach(Vector3 vec in verts){
    //             Gizmos.DrawSphere(vec, 0.2f);
    //         }
    //     }
    // }

}
