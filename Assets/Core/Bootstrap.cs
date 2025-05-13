using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FinisOmnibus.Core
{
    public class Bootstrap : MonoBehaviour, IDisposable
    {
        [SerializeField] private string _nextSceneName;
        [SerializeField] private ServicesRegistrator _servicesRegistrator;
        private LogoLoaderService _logoLoaderService;
        private void Start()
        {
            _servicesRegistrator.StartRegistration();

            _logoLoaderService = ServiceLocator.Get<LogoLoaderService>();
            _logoLoaderService.RunStartLogo();
            _logoLoaderService.OnAllVideosFinished += LoadNextScene;

            _ = Initialize();
        }


        private async Task Initialize()
        {
            await Task.Delay(2000);
            Debug.Log("Initializtion Complete");
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(_nextSceneName);
        }

        public void Dispose() =>
            _logoLoaderService.OnAllVideosFinished -= LoadNextScene;
    }
}