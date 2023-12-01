using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{   
    [SerializeField] private Player pm;
    [SerializeField] private GameObject Died;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject Score;
    public int ActualPhase;

    public void Update(){
        if(pm == null){
            Die();
        }
    }

    public void PassPhase(int numberPhase)
    {
        int pPhase = numberPhase + 1;
        if (SceneManager.GetSceneByBuildIndex(pPhase) != null)
        {
            SceneManager.LoadScene(pPhase);
        }
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
    }
    public void GamePlay()
    {
        Died.SetActive(false);
        SceneManager.LoadScene(ActualPhase);

    }
    private const string MenuScene = "menu";

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);  // Descarrega a cena atual
        SceneManager.LoadScene(MenuScene);
    }
    public void Die(){
        Died.SetActive(true);
        DisableAll();
    }

    private void DisableAll(){
        Game.SetActive(false);
        Score.SetActive(false);
    }
  private void EnableAll(){
    Game.SetActive(true);
    Score.SetActive(true);
}



}
