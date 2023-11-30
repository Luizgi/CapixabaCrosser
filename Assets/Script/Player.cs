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
    public Slider slider;
    
    private void Start(){
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        score++;
    }
    private void Update(){
   
        scoreText.text = "Score: " + score;

        float sliderValue = slider.value;
    }

    public void Front(){    
        if( !isHopping){
            float zDifference = 0;
              if(transform.position.z % 1 != 0){
               zDifference = Mathf.RoundToInt(transform.position.z) - transform.position.z ;
            }

            MoveCharacter(new Vector3(1, 0, zDifference));
        }

    }
    public void Left()
    {
        if (!isHopping)
        {
            float sliderValue = slider.value; 
            MoveCharacter(new Vector3(0, 0, sliderValue));
        }
    }

    public void Right()
    {
        if (!isHopping)
        {
            float sliderValue = slider.value; 
            MoveCharacter(new Vector3(0, 0, -sliderValue));
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
