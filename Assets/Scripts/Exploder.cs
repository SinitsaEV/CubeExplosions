using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 5f;
    [SerializeField] private float _baseExplosionRadius = 2f;
    [SerializeField] private float _upwardModifier = 1f;

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
}
