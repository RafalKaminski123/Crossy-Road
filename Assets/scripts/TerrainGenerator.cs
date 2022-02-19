using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private Transform terrainHolder;

   [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);
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
    }

    private void TerrainsSpawner(bool isStart) //Method for spawing components
    {

        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int terraininSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);
        for (int i = 0; i < terraininSuccession; i++)
        {
            GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
            currentTerrains.Add(terrain);
            if (!isStart)
            {
                if (currentTerrains.Count > maxTerrainCount)
                {
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            currentPosition.x++;
        }
    }
}
