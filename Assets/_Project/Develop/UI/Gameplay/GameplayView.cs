using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Factories;
using UnityEngine;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class GameplayView : MonoBehaviour, IView
    {
        [field: SerializeField] public TextView GeneratorView { get; private set; }
        [field: SerializeField] public TextView InputView { get; private set; }
    }
}
