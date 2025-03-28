using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Cube _cube;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Exploder _exploder;

    private int _maxSpawnValue = 6;
    private int _minSpawnValue = 2;
    private float _maxSpawnChance = 100;
    private float _minSpawnChance = 0;
   
    private void OnEnable()
    {
        foreach(Cube cube in _cubes)
            cube.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked -= OnClicked;
    }

    private void OnClicked(Cube cube)
    {
        if(Random.Range(_minSpawnChance,_maxSpawnChance) <= cube.SpawnChanсe)
        {
            int randomCubeCount = Random.Range(_minSpawnValue, _maxSpawnValue + 1);

            List<Cube> newCubes = new List<Cube>();

            for(int i = 0; i < randomCubeCount; i++)
            {
                newCubes.Add(CreateCube(cube));
            }

            _exploder.ExplodeCubes(newCubes, cube.transform.position);
        }

        cube.Clicked -= OnClicked;
        _cubes.Remove(cube);
    }

    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(_cube, cube.transform.position, cube.transform.rotation);
        newCube.transform.localScale = cube.transform.localScale / 2;
        newCube.ReduceСhance(cube.SpawnChanсe);
        newCube.Renderer.material.color = _colorChanger.GetRandomColor();
        newCube.Clicked += OnClicked;
        _cubes.Add(newCube);

        return newCube;
    }
}
