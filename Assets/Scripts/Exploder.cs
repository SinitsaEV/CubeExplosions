using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 50f;
    [SerializeField] private float _baseExplosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 2f;

    public void ExplodeCubes(Cube cube)
    {
        float cubeScale = cube.transform.lossyScale.x;
        float radius = _baseExplosionRadius / cubeScale;
        float explosionForse = _baseExplosionForce / cubeScale;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody) && cube.Rigidbody != rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForse, cube.transform.position, radius, _upwardModifier, ForceMode.Impulse);
            }
        }
    }

    public void ExplodeCubes(List<Cube> cubes, Vector3 centerPosition)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_baseExplosionForce, centerPosition, _baseExplosionRadius, _upwardModifier, ForceMode.Impulse);
        }
    }
}
