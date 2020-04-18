using UnityEngine;
using System.Collections.Generic;
namespace Terrain{
    public class Hex : MonoBehaviour
    {
        public int height;
        public Vector2 gridPos;
        HexSettings settings;
        public void Initialise(int _height, Vector2 _gridPos){
            height = _height;
            gridPos = _gridPos;
        }

        public void ChangeHeight(int heightDifference){
            if(heightDifference + height >= 3 || heightDifference + height < 0)
                return;
            if(settings == null)
                settings = HexSettings.GetHexSettings();

            List<Vector3> verts = new List<Vector3>();
            height += heightDifference;
            MeshFilter filter = GetComponent<MeshFilter>();
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            
            filter.mesh.GetVertices(verts);
            verts[0] = new Vector3(1, height, 0.5f);
            verts[1] = new Vector3(1, 0, 0.5f);
            verts[2] = new Vector3(1, height, -0.5f);
            verts[3] = new Vector3(1, 0, -0.5f);
            verts[4] = new Vector3(0, height, -1);
            verts[5] = new Vector3(0, 0, -1);
            verts[6] = new Vector3(-1, height, -0.5f);
            verts[7] = new Vector3(-1, 0, -0.5f);
            verts[8] = new Vector3(-1, height, 0.5f);
            verts[9] = new Vector3(-1, 0, 0.5f);
            verts[10] = new Vector3(0, height, 1);
            verts[11] = new Vector3(0, 0, 1);
            filter.mesh.vertices = verts.ToArray();
            if(height == 0){
                renderer.material = settings.heightMat0;
            }else if(height == 1){
                renderer.material = settings.heightMat1;
            }else if(height == 2){
                renderer.material = settings.heightMat2;
            }
            
        }

    }
}