using UnityEngine;

namespace ScoreTable
{
    public class ScoreTable : MonoBehaviour
    {
        [SerializeField] private Medal _medal;
        [SerializeField] private ScoreView _scoreCounter;
        [SerializeField] private ScoreView _maxScoreCounter;

        private void OnEnable()
        {
            _medal.Initialization();
            _maxScoreCounter.Show();
        }
    }
}
