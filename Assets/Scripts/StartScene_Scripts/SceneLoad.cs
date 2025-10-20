using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [Tooltip("Make sure this scene is in Build Settings.")]
    public string sceneName = "MainLevel";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
