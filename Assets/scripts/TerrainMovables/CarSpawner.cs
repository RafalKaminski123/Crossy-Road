using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    // [SerializeField] private List<GameObject> vehicles = new List<GameObject>();
    [SerializeField] private ScriptableObject vehicles;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float maxSeperationTime;
    [SerializeField] private float minSeperationTime;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());

    }
    private IEnumerator SpawnVehicle()
    {
        //int whichCars = Random.Range(0, vehicles.Count);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeperationTime, maxSeperationTime));
            Instantiate(vehicles, spawnPos.position, Quaternion.identity);
        }

    }


}

