using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject grassTilePrefab;
  
    public int gridSizeX = 5;
    public int gridSizeZ = 5;
    public Transform tileParent;
    public Vector2Int originGridOffset = new Vector2Int(2, 2); // Offset from the center of the grid
    public float gapSize = 1.0f; // Size of the gap between tiles
    public GameObject cubePrefab; // Prefab of the cube to scale
    public Vector3 cubeSpawnPosition; // Spawn position of the cube

    private void Start()
    {
        SpawnTiles();
        ScaleCube();
    }

    private void SpawnTiles()
    {
        int halfGridSizeX = gridSizeX / 2;
        int halfGridSizeZ = gridSizeZ / 2;

        float totalGapX = (gridSizeX - 1) * gapSize;
        float totalGapZ = (gridSizeZ - 1) * gapSize;

        float startX = -totalGapX / 2.0f;
        float startZ = -totalGapZ / 2.0f;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                // Calculate the position relative to the origin with gaps
                float offsetX = startX + x * gapSize;
                float offsetZ = startZ + z * gapSize;

                offsetX += (x - halfGridSizeX + originGridOffset.x) * gapSize;
                offsetZ += (z - halfGridSizeZ + originGridOffset.y) * gapSize;

                Vector3 spawnPosition = new Vector3(offsetX, 0, offsetZ);

                // Spawn grass tiles at each grid position with gaps
                GameObject grassTile = Instantiate(grassTilePrefab, spawnPosition, Quaternion.identity, tileParent);
                grassTile.name = "GrassTile (" + x + "," + z + ")";
                Tile tileComponent = grassTile.GetComponent<Tile>();
                if (tileComponent == null)
                {
                    
                    tileComponent = grassTile.AddComponent<Tile>();
                }
               
            }
        }
    }

    private void ScaleCube()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cube prefab is not assigned!");
            return;
        }

        float totalGapX = (gridSizeX - 1) * gapSize;
        float totalGapZ = (gridSizeZ - 1) * gapSize;

        float cubeSizeX = gridSizeX * gapSize + totalGapX + 1.0f; // Additional offset of 1 unit
        float cubeSizeZ = gridSizeZ * gapSize + totalGapZ + 1.0f; // Additional offset of 1 unit

        Vector3 scale = new Vector3(cubeSizeX, cubePrefab.transform.localScale.y, cubeSizeZ);
        GameObject cube = Instantiate(cubePrefab, cubeSpawnPosition, Quaternion.identity);
        cube.transform.localScale = scale;
    }

}
