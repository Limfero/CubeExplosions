using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Divider _divider;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        _divider.CubeDivided += Explode;
    }

    private void OnDisable()
    {
        _divider.CubeDivided -= Explode;
    }

    private void Explode(List<Cube> cubes)
    {
        foreach (var cube in cubes)
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
