using UnityEngine;

public class ServicesRegistrator
{
    [SerializeField] private LogoLoaderService _logoLoaderService;

    public void StartRegistration() 
    {
        ServiceLocator.Registration(_logoLoaderService);
    }
}
