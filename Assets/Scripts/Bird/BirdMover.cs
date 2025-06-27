using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isPlaying;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _isPlaying = true;
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (_isPlaying == false)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.linearVelocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
    }

    public void Play()
    {
        _isPlaying = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.linearVelocity = new Vector2(_speed, 0);
    }

    public void Pause()
    {
        _isPlaying = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }
}
