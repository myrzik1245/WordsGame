using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficultiesSelector : MonoBehaviour, IDifficultiesSelector
{
    [SerializeField] private TMP_Text _difficultyText;

    [SerializeField] private Button _easy;
    [SerializeField] private Button _normal;
    [SerializeField] private Button _hard;

    public Difficulties Selected {  get; private set; } = Difficulties.Normal;

    private void Awake()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        _easy.onClick.AddListener(OnEasyButtonClicked);
        _normal.onClick.AddListener(OnNormalButtonClicked);
        _hard.onClick.AddListener(OnHardButtonClicked);
    }

    private void OnDisable()
    {
        _easy.onClick.RemoveListener(OnEasyButtonClicked);
        _normal.onClick.RemoveListener(OnNormalButtonClicked);
        _hard.onClick.RemoveListener(OnHardButtonClicked);
    }

    private void UpdateText()
    {
        _difficultyText.text = Selected.ToString();
    }

    private void OnEasyButtonClicked()
    {
        Selected = Difficulties.Easy;
        UpdateText();
    }

    private void OnNormalButtonClicked()
    {
        Selected = Difficulties.Normal;
        UpdateText();
    }

    private void OnHardButtonClicked()
    {
        Selected = Difficulties.Hard;
        UpdateText();
    }
}
