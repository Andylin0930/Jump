using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class SceneControl : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        print("關閉遊戲");

    }
}
