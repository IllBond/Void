using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    private ServicesRegistrator _servicesRegistrator;
    private LogoLoaderService _logoLoaderService;
    private async void Start()
    {
        ServicesRegistrator _servicesRegistrator = new ServicesRegistrator();
        _servicesRegistrator.StartRegistration();

        _logoLoaderService = ServiceLocator.Get<LogoLoaderService>();
        _logoLoaderService.RunStartLogo();
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
