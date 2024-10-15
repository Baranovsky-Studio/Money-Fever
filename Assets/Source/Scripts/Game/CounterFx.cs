using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class CounterFx : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private TextMeshPro _count;
    [BoxGroup("LINKS")] [SerializeField] 
    private Animator _animator;
    [BoxGroup("LINKS")] [SerializeField] 
    private ParticleSystem _stonksUp;
    [BoxGroup("LINKS")] [SerializeField]
    private ParticleSystem _stonksDown;

    public void ShowCounterFx(bool stonksUp, float count)
    {
        _count.text = $"${Math.Round(count, 2, MidpointRounding.AwayFromZero)}";
        _count.color = stonksUp ? Color.green : Color.red;
        _animator.SetTrigger("Show");
        
        if (stonksUp)
        {
            _stonksUp.Play();
        }
        else
        {
            _stonksDown.Play();
        }
    }
}
