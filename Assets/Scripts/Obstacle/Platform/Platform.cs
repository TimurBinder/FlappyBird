using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platform : Obstacle
{
    private Renderer _renderer;

    public Vector3 MaxBounds => _renderer.bounds.max;
    public Vector3 Size => _renderer.bounds.size;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}
