using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _cube.NotDivided += Explode;
    }

    private void OnDisable()
    {
        _cube.NotDivided -= Explode;
    }

    private void Explode(Cube cube)
    {
        Instantiate(_effect, transform.position, transform.rotation);
        float multiplier = cube.transform.localScale.x > 1 ? 1 / cube.transform.localScale.x : -(float)Math.Log(cube.transform.localScale.x) + 1;

        foreach (var explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce * multiplier, transform.position, _explosionRadius * multiplier);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> objects = new();

        foreach (var hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}
