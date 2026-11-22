using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject startButton;
    private GameObject exitButton;
    private GameObject controlsButton;

    private GameObject mainMenuPanel;

    private GameObject controlsMenu;


//helper functions

    void Hide(GameObject gameobject)
    {
        gameobject.SetActive(false);
    }

    void Show (GameObject gameobject)
    {
        gameobject.SetActive(true);
    }
//awake
    void Awake()
    {
        mainMenuPanel = GameObject.Find("MainMenuPanel");

        controlsMenu = GameObject.Find("ControlsMenu");
        Hide(controlsMenu);
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
        Hide(controlsMenu);

        Show(mainMenuPanel);
    }
    public void onControlsClicked()
    {
        Hide(mainMenuPanel);

        Show(controlsMenu);
    }
}
