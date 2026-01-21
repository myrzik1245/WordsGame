using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.ResourceLoader;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class MainMenuRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.Register(CreateDifficultiesSelector);

            container.CreateNonLaziesRegistrations();
        }

        private static IDifficultiesSelector CreateDifficultiesSelector(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();
            ButtonDifficultiesSelector winScreenPrefab = 
                resourceLoader.Load<ButtonDifficultiesSelector>("MainMenu/ButtonDifficultiesSelector");

            return GameObject.Instantiate(winScreenPrefab);
        }
    }
}
