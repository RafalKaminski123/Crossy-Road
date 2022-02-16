using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    [SerializeField] private List<GameObject> areas = new List<GameObject>();
   



    private void Start()
    {
        AreaSpawner();
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
        Instantiate(areas[Random.Range(0, areas.Count)], currentPosition, Quaternion.identity);
        currentPosition.y++;
    }
}
