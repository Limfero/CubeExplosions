using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Dividing;
    public event Action<Cube> NotDivided;

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
        else
            NotDivided?.Invoke(this); ;
    }
}
