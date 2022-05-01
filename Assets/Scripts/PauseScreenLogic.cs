using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenLogic : MonoBehaviour
{

    bool _isPauseActive;
    bool _isPlaySceneLoaded;
    [SerializeField]GameObject PauseScreenCanvas;

    [Header("")]
    [SerializeField] string NameOfMainMenuScene;

    private void Start() {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("PlayerPrototypeScene")){
            // forces pause menu away. This can only be active during play
            PauseScreenCanvas.SetActive(false);
        }
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)){
            _isPauseActive = !_isPauseActive;
        }

        if(_isPauseActive){
            Time.timeScale = 0f;
            PauseScreenCanvas.SetActive(true);}
        else{
            Time.timeScale = 1f;
            PauseScreenCanvas.SetActive(false);}

        if(_isPauseActive){
            if(Input.GetButtonDown("Press Start")){
            ReturnMainMenu();
        }
            
        }
        
    }


    public void ReturnMainMenu(){
        // on click returns to main button;
        Debug.Log("Trying to access main scene");
        SceneManager.LoadScene(NameOfMainMenuScene); // remember to actually set variable lolololollol
    }


}
