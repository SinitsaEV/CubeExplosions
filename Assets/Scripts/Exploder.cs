using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;
    public void ExplodeCubes(List<Cube> cubes, Vector3 centerPosition)
    {
        foreach(Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, centerPosition, _explosionRadius, _upwardModifier, ForceMode.Impulse);
        }
    }
}
