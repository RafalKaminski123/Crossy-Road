using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private TextMeshProUGUI scoreText;

    protected Animator animator;
    protected bool isHopping;
    private int score;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        score++;
    }

    private void Update()
    {
        scoreText.text = "Score:" + score;
        if(Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            animator.SetTrigger("Hop");
            isHopping = true;
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }

    }

    protected void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.TerrainsSpawner(false, transform.position);
    }

    public void FinishMove()
    {
        isHopping = false;
    }
}
