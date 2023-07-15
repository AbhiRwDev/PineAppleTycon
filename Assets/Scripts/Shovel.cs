using UnityEngine;

public class Shovel : MonoBehaviour
{
    public LayerMask tileLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, tileLayer))
            {
                // Check if the hit object is a grass tile
                Tile tile = hit.collider.gameObject.GetComponentInParent<Tile>();
                /*print(hit.collider.gameObject.transform.parent.name);*/
                if (tile != null && tile.tileType == CurrentState.Grass)
                {

                    // Remove grass tile and replace it with soil
                    tile.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    tile.tileType = CurrentState.Soil;
                    tile.gameObject.transform.GetChild(1).gameObject.SetActive(true);                    
                }
                else if(tile != null && tile.tileType == CurrentState.Soil)
                {
                    tile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    tile.tileType = CurrentState.ploughedSoil;
                    tile.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if (tile != null && tile.tileType == CurrentState.ploughedSoil)
                {
                    tile.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    tile.tileType = CurrentState.wateredPloughedSoil;
                    tile.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                }
                
            }
        }
    }
}
