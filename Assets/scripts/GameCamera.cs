using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    private void Start()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothness * Time.deltaTime);
    }

   
}
