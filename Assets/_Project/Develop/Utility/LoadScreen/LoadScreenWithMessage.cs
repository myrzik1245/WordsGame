using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenWithMessage : MonoBehaviour, ILoadScreen
{
    [SerializeField] private LoadScreenMessages _messages;
    [SerializeField] private Image _animationImage;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private TMP_Text _messageText;

    private IInputService _inputService;

    public void Initialize(IInputService inputService)
    {
        Hide();
        DontDestroyOnLoad(gameObject);

        _inputService = inputService;

        _messageText.text = _messages.GetNextMessage();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float offser = _animationSpeed * Time.deltaTime;

        _animationImage.rectTransform.Rotate(0, 0, offser);
        if (_inputService.NextMessage.Down)
            _messageText.text = _messages.GetNextMessage();
    }
}
