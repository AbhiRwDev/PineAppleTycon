using UnityEngine;

public enum CurrentState
{
    Grass,
    Soil,
    ploughedSoil,
    wateredPloughedSoil
}

public class Tile : MonoBehaviour
{
    public CurrentState tileType;
    


    // Properties
    public float currentMoisture;
    public float currentFertility;
    public string favouredPineappleType;
    public float moistureRetentionQuality;
    public float fertilityRetentionQuality;
    public bool isPlanted;

    
    
}
