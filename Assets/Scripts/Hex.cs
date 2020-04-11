using UnityEngine;
namespace Terrain{
    public class Hex : MonoBehaviour
    {
        public int height;
        public Vector2 gridPos;

        public void Initialise(int _height, Vector2 _gridPos){
            height = _height;
            gridPos = _gridPos;
        }

    }
}