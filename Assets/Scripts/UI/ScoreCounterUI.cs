using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounterUI : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.Changed += SetValue;
        SetValue(_counter.Value);
    }

    private void OnDisable()
    {
        _counter.Changed -= SetValue;
    }

    private void SetValue(int value)
    {
        _text.text = value.ToString();
    }
}
