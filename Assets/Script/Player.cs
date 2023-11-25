using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    private Animator animator;
    private bool isHopping;
    private int score;
    
    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        score++;
    }
    private void Update(){
        scoreText.text = "Score: " + score;
        if(Input.GetKeyDown(KeyCode.W) && !isHopping){


        }
        else if(Input.GetKeyDown(KeyCode.A)&& !isHopping){
            
        }
        else if(Input.GetKeyDown(KeyCode.D) && !isHopping){

        }

    }

    public void Front()
    {
        if (!isHopping)
        {
            float zDifference = 0;

            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.RoundToInt(transform.position.z) - transform.position.z;
            }

            MoveCharacter(new Vector3(1, 0, zDifference));
        }
    }
    public void Left()
    {
        if (!isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
    }

    public void Right()
    {
        if(!isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.collider.GetComponent<MovingObject>().isLog){
            transform.parent = collision.collider.transform;

        }
        else{
            transform.parent = null;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>().isLog) 
        {
            transform.parent = null;
        }
    }
    private void MoveCharacter(Vector3 difference){
            animator.SetTrigger("hop");
            isHopping = true;
            transform.position = (transform.position + difference);
            terrainGenerator.SpawnTerrain(false, transform.position);
    }

    public void FinishHop(){
        isHopping = false;
    }
}
