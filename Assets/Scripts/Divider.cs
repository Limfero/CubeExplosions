using System;
using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private List<Color> _colors;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private int _chanceReductionMultiplier = 2;
    private float _scaleMultiplier = 2f;
    private float _explosionForce = 300f;
    private float _explosionRadius = 30f;

    private void OnEnable()
    {
        _cube.Dividing += Divide;
    }

    private void OnDisable()
    {
        _cube.Dividing -= Divide;
    }
    private void Divide(Cube cube)
    {
        int countCube = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount);

        for (int i = 0; i < countCube; i++)
        {
            Cube newCube = Instantiate(cube, transform.position, Quaternion.identity);
            Color colorCube = _colors[UnityEngine.Random.Range(0, _colors.Count)];

            newCube.transform.localScale /= _scaleMultiplier;
            newCube.SetColor(colorCube);
            newCube.ReducingChanceDivide(_chanceReductionMultiplier);
            newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}

