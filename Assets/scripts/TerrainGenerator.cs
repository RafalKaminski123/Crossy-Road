using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private Transform terrainHolder;

    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            TerrainsSpawner(true);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TerrainsSpawner(false); 
        }
        maxTerrainCount += currentTerrains.Count;
    }

    private void TerrainsSpawner(bool isStart)
    {
        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int terraininSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);
        for (int i = 0; i < terraininSuccession; i++)
        {
            GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity);
            terrain.transform.SetParent(terrainHolder);
            currentTerrains.Add(terrain);
            if (!isStart)
            {
                if (currentTerrains.Count > maxTerrainCount)
                {
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            else
            {

            }
            currentPosition.x++;
        }
    }
}
