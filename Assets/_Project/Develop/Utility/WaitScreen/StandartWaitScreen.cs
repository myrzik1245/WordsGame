using Assets._Project.Develop.Utility.InputService;
using Assets._Project.Develop.Utility.LoadScreen;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Utility.WaitScreen
{
    public class StandartWaitScreen : MonoBehaviour, IWaitScreen
    {
        private IInputService _inputService;
        private ILoadScreen _loadScreen;

        private void Awake()
        {
            Hide();
            DontDestroyOnLoad(this);
        }

        public void Initialize(IInputService inputService, ILoadScreen loadScreen)
        {
            _inputService = inputService;
            _loadScreen = loadScreen;
        }

        public IEnumerator Wait()
        {
            Show();

            yield return new WaitWhile(() => _inputService.AnyKey == false);

            Hide();
        }

        private void Show()
        {
            gameObject.SetActive(true);
            _loadScreen.Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}