using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain{
    public class HexSelection : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI textTileCoords, textTileHeight;
        public Material selectionMaterial;
        private Material oldMaterial;
        Ray cursorRay;
        Camera mainCam;
        GameObject currHex, prevHex;
        Hex selectedHexData;
        void Start()
        {
            mainCam = Camera.main;
        }

        void Update()
        {
            cursorRay = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(cursorRay, out hit)){
                if((selectedHexData = hit.transform.GetComponent<Hex>()) != null){
                        textTileCoords.text = $"Coordinates: {selectedHexData.gridPos.x}, {selectedHexData.gridPos.y} ";
                        textTileHeight.text = $"Height: {selectedHexData.height}";
                    if(currHex == null){
                        currHex = hit.transform.gameObject; 
                        MeshRenderer renderer = currHex.GetComponent<MeshRenderer>();
                        oldMaterial = renderer.material;
                        renderer.material = selectionMaterial;
                    }
                    if(hit.transform.gameObject != currHex){
                        
                        prevHex = currHex;
                        prevHex.GetComponent<MeshRenderer>().material = oldMaterial;
                        
                        currHex = hit.transform.gameObject;
                        Renderer renderer = currHex.GetComponent<MeshRenderer>();
                        oldMaterial = renderer.material;
                        renderer.material = selectionMaterial;
                    }
                }
            }
        }

    }
}