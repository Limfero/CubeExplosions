using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private static float s_chanceDividingInProcent = 100;

    public event Action CubeDividing;

    private void OnMouseUpAsButton()
    {
        TryDividing();
        Destroy(gameObject);
    }

    private void TryDividing()
    {
        int decreasing—hanceInProcent = 20;
        int maxProcent = 100;
        float minFloat = 0f;
        float maxFloat = 1f;

        if (UnityEngine.Random.Range(minFloat, maxFloat) < s_chanceDividingInProcent / maxProcent)
            CubeDividing?.Invoke();

        Instantiate(_effect, transform.position, transform.rotation);
        s_chanceDividingInProcent -= s_chanceDividingInProcent * decreasing—hanceInProcent / maxProcent;
    }
}
