using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSpawn : MonoBehaviour
{
    public Tilemap tilemap;
    public RuleTile ruleTile;
    public int width = 10;
    public int height = 10;
    public float platformProbability = 0.5f;
    public int platformWidth = 5;
    public int platformHeight = 1;
    public Transform gameObjToTrack; // The game object to track for position

    public GameObject Score;
    private float lastTileSpawnY; // The last Y position where tiles were spawned

    void Start()
    {

        lastTileSpawnY = gameObjToTrack.position.y; // Initialize lastTileSpawnY

        // Register to track the position of the game object
        gameObjToTrack.GetComponent<PositionTracker>().OnPositionUpdate += CheckTileSpawn;

        // Spawn initial tiles
        SpawnTiles();
    }

    private void CheckTileSpawn(Vector3 position)
    {
        // Calculate the next tile spawn position by rounding up to the next 100 unit interval
        float nextTileSpawnY = Mathf.Ceil(position.y / 100f) * 100f;

        float Y = Mathf.Ceil(position.y / 100f) * 100f;
        // Check if the next tile spawn position is greater than the last tile spawn position
        if (nextTileSpawnY > lastTileSpawnY)
        {
            Instantiate(Score, new Vector3(50, Y, 0), Quaternion.identity);
            // Calculate the number of tile rows to spawn based on the difference between the next and last tile spawn positions
            int tileRowsToSpawn = Mathf.FloorToInt((nextTileSpawnY - lastTileSpawnY) / platformHeight);

            // Delete tiles below the specified game object
            DeleteTilesBelowObject(gameObjToTrack.position.y - 10);

            // Update lastTileSpawnY with the next tile spawn position
            lastTileSpawnY = nextTileSpawnY;

            // Spawn new tiles
            for (int x = 0; x < width; x += platformWidth)
            {
                for (int y = 0; y < tileRowsToSpawn * platformHeight; y += platformHeight)
                {
                    if (Random.value < platformProbability)
                    {
                        for (int i = 0; i < platformWidth; i++)
                        {
                            for (int j = 0; j < platformHeight; j++)
                            {
                                Vector3Int tilePos = new Vector3Int(x + i, y + j + Mathf.FloorToInt(lastTileSpawnY), 0);
                                tilemap.SetTile(tilePos, ruleTile);
                            }
                        }
                    }
                }
            }
        }
    }

    private void DeleteTilesBelowObject(float yPosition)
    {
        Vector3Int tilemapSize = tilemap.size;
        for (int x = 0; x < tilemapSize.x; x++)
        {
            for (int y = 0; y < tilemapSize.y; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                Vector3 tileWorldPos = tilemap.CellToWorld(tilePos);
                if (tileWorldPos.y < yPosition)
                {
                    tilemap.SetTile(tilePos, null);
                }
            }
        }
    }

    private void SpawnTiles()
    {
        for (int x = 0; x < width; x += platformWidth)
        {
            for (int y = 0; y < height; y += platformHeight)
            {
                if (Random.value < platformProbability)
                {
                    for (int i = 0; i < platformWidth; i++)
                    {
                        for (int j = 0; j < platformHeight; j++)
                        {
                            Vector3Int tilePos = new Vector3Int(x + i, y + j, 0);
                            tilemap.SetTile(tilePos, ruleTile);
                        }
                    }
                }
            }
        }
    }
}
