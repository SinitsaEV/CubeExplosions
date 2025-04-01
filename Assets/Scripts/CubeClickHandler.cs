using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private ClickHandler _clickHandler;

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    private void OnEnable()
    {
        _clickHandler.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickHandler.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask) && hit.collider.TryGetComponent(out Cube cube))
        {
            if (_cubeSpawner.TrySpawnCubes(cube, out List<Cube> cubes))
            {
                _exploder.ExplodeCubes(cubes, cube.transform.position);
            }
            else
            {
                _exploder.ExplodeCubes(cube);
            }

            Destroy(cube.gameObject);
        }
    }
}