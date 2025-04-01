using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private ColorChanger _colorChanger;

    private int _maxSpawnValue = 6;
    private int _minSpawnValue = 2;
    private float _maxSpawnChance = 100;
    private float _minSpawnChance = 0;

    public bool TrySpawnCubes(Cube cube, out List<Cube> newCubes)
    {
        newCubes = new List<Cube>();
        bool canSpawnCubes = Random.Range(_minSpawnChance, _maxSpawnChance) <= cube.SpawnChanсe;

        if (canSpawnCubes)
        {
            int randomCubeCount = Random.Range(_minSpawnValue, _maxSpawnValue + 1);
            
            for(int i = 0; i < randomCubeCount; i++)
            {
                newCubes.Add(CreateCube(cube));
            }
        }

        return canSpawnCubes;
    }

    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(_cube, cube.transform.position, cube.transform.rotation);
        newCube.transform.localScale = cube.transform.localScale / 2;
        newCube.ReduceСhance(cube.SpawnChanсe);
        newCube.Renderer.material.color = _colorChanger.GetRandomColor();  
        
        return newCube;
    }
}
