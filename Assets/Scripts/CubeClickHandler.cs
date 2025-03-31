using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private ClickHandler _clickHandler;

    private void OnEnable()
    {
        _clickHandler.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickHandler.Clicked -= OnClicked;
    }

    private void OnClicked(RaycastHit raycastHit)
    {
        if (raycastHit.collider.TryGetComponent(out Cube cube))
        {
            Destroy(cube.gameObject);
            _cubeSpawner.SpawnCubes(cube);
            _exploder.ExplodeCubes(cube);
        }
    }
}
