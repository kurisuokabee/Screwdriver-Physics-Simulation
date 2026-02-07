using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject startButton;
    

    public void StartExperiment()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }

    public void RestartExperiment()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(1);
    }
}
