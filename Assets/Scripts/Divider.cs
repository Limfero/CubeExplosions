using System;
using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private List<Color> _colors;

    public event Action<List<Cube>> CubeDivided;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private float _scaleMultiplier = 2f;

    private void OnEnable()
    {
        _cubePrefab.CubeDividing += Divide;
    }

    private void OnDisable()
    {
        _cubePrefab.CubeDividing -= Divide;
    }
    private void Divide()
    {
        List<Cube> newCubes = new();
        int countCube = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount);
        Color colorCube = _colors[UnityEngine.Random.Range(0, _colors.Count)];

        _cubePrefab.GetComponent<Renderer>().material.color = colorCube;
        _cubePrefab.transform.localScale /= _scaleMultiplier;

        for (int i = 0; i < countCube; i++)
            newCubes.Add(Instantiate(_cubePrefab, transform.position, Quaternion.identity));

        CubeDivided?.Invoke(newCubes);
    }
}

