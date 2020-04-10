using UnityEngine;
namespace Terrain{
    public class Hex
    {
        public int height;
        public Vector2 gridPos;

        public Hex(int _height, Vector2 _gridPos){
            height = _height;
            gridPos = _gridPos;
        }
    }
}