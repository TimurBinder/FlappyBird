using UnityEngine;
using UnityEngine.UI;

namespace ScoreTable
{
    public class Medal : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private ScoreCounter _counter;

        [Header("Prize values")]
        [SerializeField] private float _silverValue;
        [SerializeField] private float _goldValue;

        [Header("Prize images")]
        [SerializeField] private Sprite _bronzeSprite;
        [SerializeField] private Sprite _silverSprite;
        [SerializeField] private Sprite _goldSprite;

        public void Initialization()
        {
            if (_counter.Value >= _goldValue)
                _image.sprite = _goldSprite;
            else if (_counter.Value >= _silverValue)
                _image.sprite = _silverSprite;
            else
                _image.sprite = _bronzeSprite;
        }
    }
}
