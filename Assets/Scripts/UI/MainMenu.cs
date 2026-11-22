using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject startButton;
    private GameObject exitButton;
    private GameObject controlsButton;

    private GameObject controlsMenu;


//helper functions

    void hide(GameObject gameobject)
    {
        gameobject.SetActive(false);
    }

    void show (GameObject gameobject)
    {
        gameobject.SetActive(true);
    }
//awake
    void Awake()
    {
        startButton = GameObject.Find("StartButton");
        exitButton = GameObject.Find("ExitButton");
        controlsButton = GameObject.Find("ControlsButton");

        controlsMenu = GameObject.Find("ControlsMenu");
        hide(controlsMenu);
    }
    

//main menu interaction
    public void onStartClicked()
    {
        SceneManager.LoadScene("Main");
    }

    
    public void onExitClicked()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void onReturnClicked()
    {
        hide(controlsMenu);

        show(startButton);
        show(exitButton);
        show(controlsButton);
    }
    public void onControlsClicked()
    {
        hide(startButton);
        hide(exitButton);
        hide(controlsButton);

        show(controlsMenu);
    }
}
