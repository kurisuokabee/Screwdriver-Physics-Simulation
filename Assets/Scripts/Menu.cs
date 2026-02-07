using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    void Awake()
    {
        Time.timeScale = 0;
    }
    
    public void GoToSimulationScene()
    {
        SceneManager.LoadScene(1);
    }
}
