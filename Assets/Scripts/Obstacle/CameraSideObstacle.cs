using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraSideObstacle : Obstacle
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _height = 0.5f;

    [SerializeField, Range(0f, 1f)] private float _positionX = 0.5f;
    [SerializeField, Range(0f, 1f)] private float _positionY = 1f;

    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        Vector2 centerPoint = _camera.ViewportToWorldPoint(new Vector2(_positionX, _positionY));
        _collider.transform.position = centerPoint;
        _collider.size = new Vector2(_camera.orthographicSize, _height);
    }
}
