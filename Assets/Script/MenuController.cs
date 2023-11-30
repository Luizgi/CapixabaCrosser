using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{   
    [SerializeField] private Player pm;
    [SerializeField] private GameObject Died;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject Game;
    public int ActualPhase;

    public void Update(){
        if(pm == null){
            Die();
        }
    }

    public void PassPhase(int numberPhase){
        int pPhase = numberPhase + 1;
        SceneManager.LoadScene(pPhase);
    }

    public void Exit(){
        Application.Quit();
    }

    public void PauseState(){
        Time.timeScale = 0f;
        Pause.SetActive(true);
        DisableAll();
    }

    public void ReturnGame(){
        Time.timeScale = 1f;
        Pause.SetActive(false);
        EnableAll();
        Died.SetActive(false);
    }

    public void ToMenu(){
        Died.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Die(){
        Died.SetActive(true);
        DisableAll();
    }

    private void DisableAll(){
        Game.SetActive(false);
    }
    private void EnableAll(){
        Game.SetActive(true);  
    }

}
