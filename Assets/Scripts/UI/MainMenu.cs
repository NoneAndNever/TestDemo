using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SaveList saveList;
    public Save save;
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
    public void NewAndLoad()
    {
        GameObject.Find("/MainMenu/Image/SaveList").SetActive(true);
        GameObject.Find("/MainMenu/Image/UI").SetActive(false);
        saveList.savelist.Add(save);
    }

}
