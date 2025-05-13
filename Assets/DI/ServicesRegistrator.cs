using UnityEngine;

namespace FinisOmnibus.Core
{
    public class ServicesRegistrator : MonoBehaviour
    {
        [SerializeField] private LogoLoaderService _logoLoaderService;

        public void StartRegistration()
        {
            ServiceLocator.Registration(_logoLoaderService);
        }
    }
}