using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
