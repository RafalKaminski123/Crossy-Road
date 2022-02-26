using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private int mindistanceFromPlayer; 
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

   [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            TerrainsSpawner(true, new Vector3(0, 0, 0));
        }
    }
 
    public void TerrainsSpawner(bool isStart, Vector3 playerPos ) //Method for spawing components
    {
        if((currentPosition.z - playerPos.z < mindistanceFromPlayer) || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terraininSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccesion);
            for (int i = 0; i < terraininSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.z++;
            }
        }
   
    }
}
