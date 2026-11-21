using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onStartClicked()
    {
        SceneManager.LoadScene("Main");
    }
    public void onExitClicked()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
