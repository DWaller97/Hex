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

        void Start()
        {
            mainCam = Camera.main;
        }

        void Update()
        {
            cursorRay = mainCam.ScreenPointToRay(Input.mousePosition);
            SelectHex();
            EditHexHeight();
        }

        GameObject currHex = null, prevHex = null;
        void EditHexHeight(){
            bool leftClick = Input.GetMouseButtonDown(0);
            bool rightClick = Input.GetMouseButtonDown(1);
            if(leftClick || rightClick){
                RaycastHit hit;
                Hex selectedHex;
                if(Physics.Raycast(cursorRay, out hit)){
                    if((selectedHex = hit.transform.GetComponent<Hex>()) != null){
                        if(leftClick)
                            selectedHex.ChangeHeight(1);
                        else 
                            selectedHex.ChangeHeight(-1);
                    }
                }
            }
        }
        void SelectHex(){
            Hex selectedHexData;
            RaycastHit hit;
            if(Physics.Raycast(cursorRay, out hit)){
                if((selectedHexData = hit.transform.GetComponent<Hex>()) != null){
                            textTileCoords.text = $"Coordinates: {selectedHexData.gridPos.x}, {selectedHexData.gridPos.y} ";
                            textTileHeight.text = $"Height: {selectedHexData.height}";
                        if(currHex == null){
                            currHex = hit.transform.gameObject; 
                        }
                        if(hit.transform.gameObject != currHex){
                            prevHex = currHex;
                            currHex = hit.transform.gameObject;
                        }
                    }
                }
        }
    }
}