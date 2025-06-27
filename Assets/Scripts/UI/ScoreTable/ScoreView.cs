using System.Collections;
using TMPro;
using UnityEngine;

namespace ScoreTable
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _counter;
        [SerializeField] private float _showDelay;

        private TextMeshProUGUI _text;
        private WaitForSeconds _wait;

        private void Awake()
        {
            _wait = new WaitForSeconds(_showDelay);
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            Show();
        }

        public void Show()
        {
            StartCoroutine(Showing());
        }

        private IEnumerator Showing()
        {
            for (var i = 0; i <= _counter.Value; i++) 
            {
                yield return _wait;
                _text.text = i.ToString();
            }
        }
    }
}
