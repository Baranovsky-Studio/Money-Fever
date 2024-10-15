using NaughtyAttributes;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private MeshRenderer _material;
    [BoxGroup("LINKS")] [SerializeField] 
    private ParticleSystem _particle;

    [BoxGroup("SETTINGS")] [SerializeField]
    private Material _reachedColor;
    [BoxGroup("SETTINGS")]
    public int Score;

    public void OnReached()
    {
        _material.material = _reachedColor;
        _particle.Play();
    }
}
