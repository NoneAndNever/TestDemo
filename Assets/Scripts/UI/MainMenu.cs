using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void UIEnabled()
    {
        GameObject.Find("/MainMenu/Image/UI").SetActive(true);
    }


}
