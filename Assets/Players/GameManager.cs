using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        //singleton pattern so you can call GameManager.Instance from anywhere
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ResetLevel()
    {
        //reloads the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
