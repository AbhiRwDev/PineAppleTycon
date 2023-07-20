using UnityEngine;

public enum CurrentTool
{
    Hand,
    Hoes,
    Shovel,
    Pickaxe,
    Bucket
}

public class Tool : MonoBehaviour
{
    #region Singleton

    public static Tool instance;
    
    void Awake()
    {
        instance = this;
    }

    #endregion


    public LayerMask tileLayer;
    public CurrentTool toolType;
    
    public Item currentItem;
    private void Start()
    {
        toolType = CurrentTool.Hand;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, tileLayer))
            {

                // Check if the hit object is a grass tile
                Tile tile = hit.collider.gameObject.GetComponentInParent<Tile>();
                

                if (tile != null && tile.tileType == CurrentState.Grass)
                {
                    
                    if (toolType == CurrentTool.Hoes)
                    {
                        if (currentItem.durability > 0)
                        {
                            currentItem.durability--;
                            // Remove grass tile and replace it with soil
                            tile.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                            tile.tileType = CurrentState.Soil;
                            tile.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                            
                            if (currentItem.count - 1 > 0 && currentItem.durability == 0)
                            {
                                currentItem.count--;
                                currentItem.durability = 5;

                            }
                            else if(currentItem.count - 1 == 0)
                            {
                                currentItem.RemoveFromInventory();

                            }
                        }
                        
                        
                        
                    }
                                
                }
                else if(tile != null && tile.tileType == CurrentState.Soil)
                {
                    if (toolType == CurrentTool.Pickaxe)
                    {
                        
                        if (currentItem.durability > 0)
                        {
                            currentItem.durability--;
                            // Remove soil tile and replace it with ploughed soil
                            tile.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                            tile.tileType = CurrentState.ploughedSoil;
                            tile.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            if (currentItem.count - 1 > 0 && currentItem.durability == 0)
                            {
                                currentItem.count--;
                                currentItem.durability = 5;

                            }
                            else if (currentItem.count - 1 == 0)
                            {
                                currentItem.RemoveFromInventory();

                            }
                        }
                       
                    }
                        
                }
                else if (tile != null && tile.tileType == CurrentState.ploughedSoil)
                {
                    if (toolType == CurrentTool.Bucket)
                    {
                        
                        if (currentItem.durability > 0)
                        {
                            currentItem.durability--;
                            tile.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                            tile.tileType = CurrentState.wateredPloughedSoil;
                            tile.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                            if (currentItem.count - 1 > 0 && currentItem.durability == 0)
                            {
                                currentItem.count--;
                                currentItem.durability = 5;

                            }
                            else if (currentItem.count - 1 == 0)
                            {
                                currentItem.RemoveFromInventory();

                            }
                        }
                        
                    }
                        
                }
                
            }
        }
    }
    
}
