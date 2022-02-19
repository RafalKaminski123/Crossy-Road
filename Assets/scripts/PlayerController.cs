using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] TerrainGenerator terrainGenerator;

    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            animator.SetTrigger("Hop");
            isHopping = true;
            float zDifference = 0;
            if(transform.position.x % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
                
            }
            MoveCharacter(new Vector3(1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
        }

    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Hop");
        isHopping = true;
        transform.position = (transform.position + difference);
    }

    public void FinishMove()
    {
        isHopping = false;
    }
}
