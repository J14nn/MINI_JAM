using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void onRetry()
    {
        //as this is not a separate scene, all it does is reset the Main scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onMainMenu()
    {
        //change if you change the name of the scene with the main menu.
        SceneManager.LoadScene("Thea");
    }

    public void onExit()
    {
        Application.Quit();
    }

}
