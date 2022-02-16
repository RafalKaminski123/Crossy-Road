using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> areas = new List<GameObject>();
    [SerializeField] private int maxTerrainCount;

    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            AreaSpawner();
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AreaSpawner(); 
        }
    }

    private void AreaSpawner()
    {
        GameObject terrain = Instantiate(areas[Random.Range(0, areas.Count)], currentPosition, Quaternion.identity);
        currentTerrains.Add(terrain);
        if(currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
        currentPosition.x++;
    }
}
