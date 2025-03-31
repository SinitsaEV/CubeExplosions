using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
            List<Cube> cubes = _cubeSpawner.SpawnCubes(cube);
            _exploder.ExplodeCubes(cubes, cube.transform.position);
        }
    }
}
