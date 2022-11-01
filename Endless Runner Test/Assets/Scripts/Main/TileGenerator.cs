using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();

    private float spawnPos = 0;
    private float tileLenght = 100;

    [SerializeField] private int startTileCount = 8;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(1);

        for (int i = 0; i < startTileCount; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTiles = Instantiate(tilePrefabs[tileIndex], 
            transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTiles);

        spawnPos += tileLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z  - 50 > spawnPos - (startTileCount * tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
}
