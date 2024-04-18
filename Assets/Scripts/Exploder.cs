using System;
using System.Collections.Generic;
using System.Linq;
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

        List<Rigidbody> explodableObjects = Physics.OverlapSphere(transform.position, _explosionRadius)
            .Where(hit => hit.attachedRigidbody != null)
            .Select(hit => hit.attachedRigidbody)
            .ToList();

        foreach (var explodableObject in explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce * multiplier, transform.position, _explosionRadius * multiplier);
    }
}
