using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject pauseMenu;
    //public GameObject DeathMenu;
    
    //public bool isPaused;
    

    //ENVIRONMENTAL MOVEMENT AND PLAYER CONTROL ARE ACTIVE BY DEFAULT. MENUS ARE DEACTIVATED BY DEFAULT.
    void Start()
    {
        //time.timescale = 1f;
        //pausemenu.setactive(false);
        //deathmenu.setactive(false);
        //getcomponent<rotatebullet>().enabled = true;
    }

    void Update()
    {
       //CHECKS TO SEE IF ESC KEY IS PRESSED, IF SO THEN THE PAUSE MENUS ARE ACTIVATED
       //if(Input.GetKeyDown(KeyCode.Escape))
       // {
       //     if (isPaused)
       //     {
       //         isPaused = false;
       //         pauseMenu.SetActive(false);
       //         Time.timeScale = 1f;
       //         //GetComponent<RotateBullet>().enabled = true;
       //     }
       //     else
       //     {
       //         isPaused = true;
       //         pauseMenu.SetActive(true);
       //         Time.timeScale = 0f;
       //         //GetComponent<RotateBullet>().enabled = false;
       //     }
       // }

        
    }

    //ALLOWS FOR BUTTON TO UNPAUSE GAME
    //public void UnPause()
    //{
    //    isPaused = false;
    //    pauseMenu.SetActive(false);
    //    //GetComponent<RotateBullet>().enabled = false;
    //    Time.timeScale = 1f;
    //    //pauseMenu.SetActive(false);
    //}

    //ALLOWS BUTTON TO CHANGE SCENE
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //ALLOWS BUTTON TO CHANGE SCENE
    //public void ToTestLevel()
    //{
    //    SceneManager.LoadScene("TestLevel");
        
    //}

    //ALLOWS BUTTON TO CHANGE SCENE
    public void ToLevel1()
    {
        SceneManager.LoadScene("SampleScene");
       
    }

    //ALLOWS BUTTON TO CHANGE SCENE
    //public void ToLevel2()
    //{
    //    SceneManager.LoadScene("Level2.1");
        
    //}

    ////ALLOWS BUTTON TO CHANGE SCENE
    //public void ToLevel3()
    //{
    //    SceneManager.LoadScene("Level3");
        
    //}

    ////ALLOWS BUTTON TO CHANGE SCENE
    //public void ToLevel4()
    //{
    //    SceneManager.LoadScene("Level4");

    //}

    ////ALLOWS BUTTON TO CHANGE SCENE
    //public void ToLevel5()
    //{
    //    SceneManager.LoadScene("Level5");

    //}

    ////ALLOWS BUTTON TO CHANGE SCENE
    //public void ToControls()
    //{
    //    SceneManager.LoadScene("Controls");
    //}

    ////ALLOWS BUTTON TO CHANGE SCENE
    //public void ToAimOfGame()
    //{
    //    SceneManager.LoadScene("AimOfGame");
    //}

    //IF THE GAME WAS AN EXECUTABLE THEN THE BUTTON ASSOCCIATED WITH THIS WOULD CAUSE THE WINDOW TO CLOSE
    public void ToQuitGame()
    {
        Application.Quit();
    }
}
