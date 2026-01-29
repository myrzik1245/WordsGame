using UnityEngine;

namespace Assets._Project.Develop.UI.Root
{
    public class UIRoot : MonoBehaviour
    {
        [field: SerializeField] public Transform Hud { get; private set; }
        [field: SerializeField] public Transform UnderPopups { get; private set; }
        [field: SerializeField] public Transform Popups { get; private set; }
        [field: SerializeField] public Transform OverPopups { get; private set; }
    }
}