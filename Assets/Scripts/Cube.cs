using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public event Action<Cube> Dividing;

    private float _chanceDividing = 1f;

    private void OnMouseUpAsButton()
    {
        TryDivide();
        Destroy(gameObject);
    }

    public void ReducingChanceDivide(int chanceReductionMultiplier)
    {
        _chanceDividing /= chanceReductionMultiplier;
    }

    public void SetColor(Color color) 
    {
        GetComponent<Renderer>().material.color = color;
    }

    private void TryDivide()
    {
        float minFloat = 0f;
        float maxFloat = 1f;

        if (UnityEngine.Random.Range(minFloat, maxFloat) < _chanceDividing)
            Dividing?.Invoke(this);

        Instantiate(_effect, transform.position, transform.rotation);
    }
}
