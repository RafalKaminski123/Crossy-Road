using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramSpawner : MonoBehaviour
{
    [SerializeField] private GameObject vehicles;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float maxSeperationTime;
    [SerializeField] private float minSeperationTime;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());

    }
    private IEnumerator SpawnVehicle()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeperationTime, maxSeperationTime));
            Instantiate(vehicles, spawnPos.position, Quaternion.identity);
        }
        
    }


}
