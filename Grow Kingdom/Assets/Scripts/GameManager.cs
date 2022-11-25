using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OpenWindow(GameObject Window) => Window.SetActive(true);

    public void CloseWindow(GameObject Window) => Window.SetActive(false);

    public void OpenScene(string SceneName) => SceneManager.LoadScene(SceneName);
}