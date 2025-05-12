using UnityEngine;

public class ServicesRegistrator
{
    [SerializeField] private LogoLoaderService _logoLoaderService;

    public void Registration() 
    {
        ServiceLocator.Register(_logoLoaderService);
    }
}
