using NaughtyAttributes;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FinishPlatformNew : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private ParticleSystem _particle;
    [BoxGroup("LINKS")] [SerializeField] 
    private TextMeshPro _text;
    [BoxGroup("LINKS")] [SerializeField] 
    private MeshRenderer _mesh;
    [BoxGroup("LINKS")] [SerializeField] 
    private AudioSource _audioSource;

    [BoxGroup("COLORS")] [SerializeField]
    private Material[] _colors;
    
    [BoxGroup("SETTINGS")]
    public int GoldCount;
    
    private void Start()
    {
        _text.text = GoldCount.ToString();
    }

    public void OnReached()
    {
        _mesh.material = _colors[Random.Range(0, _colors.Length)];
        _particle.Play();
        _audioSource.Play();
    }
}
