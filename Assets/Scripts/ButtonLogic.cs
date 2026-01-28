using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
   public void NextScene()
    {
        SceneHandler.instance.ChangeScene();
    }
       public void QuitGame()
    {
        SceneHandler.instance.Quit();
    }
}
