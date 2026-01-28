using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
   public void NextScene()
   {
        SceneHandler.Instance.ChangeScene();
   }
   public void QuitGame()
   {
        SceneHandler.Instance.Quit();
   }
}
