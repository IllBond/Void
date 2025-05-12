using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;

    private async void Start()
    {
        ServicesRegistrator.Registration();
        await Initialize();
        LoadNextScene();
    }

    
    private async Task Initialize()
    {
        await Task.Delay(2000);
        Debug.Log("Initializtion COmplete");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}
