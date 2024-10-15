using System;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class CountChanger : MonoBehaviour
{
    private enum ChangerType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
    }

    [BoxGroup("LINKS")] [SerializeField] 
    private TextMeshPro _text;
    [BoxGroup("LINKS")] [SerializeField] 
    private MeshRenderer _meshRenderer;
    
    [BoxGroup("SETTINGS")] [SerializeField]
    private ChangerType _changerType;
    [BoxGroup("SETTINGS")] [SerializeField]
    private Material _red;
    [BoxGroup("SETTINGS")] [SerializeField]
    private Material _blue;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _count;

    public Action OnUsed;
    public bool Used { get; set; }

    private void Start()
    {
        switch (_changerType)
        {
            case ChangerType.Plus:
                _text.text = $"+${_count}";
                _meshRenderer.material = _blue;
                break;
            case ChangerType.Minus:
                _text.text = $"-${_count}";
                _meshRenderer.material = _red;
                break;
            case ChangerType.Multiply:
                _text.text = $"x${_count}";
                _meshRenderer.material = _blue;
                break;
            case ChangerType.Divide:
                _text.text = $"÷${_count}";
                _meshRenderer.material = _red;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cylinder"))
        {
            if (Used) return;
            var scaling = other.gameObject.GetComponent<PlayerScaling>();
            if (scaling == null) return;
            
            switch (_changerType)
            {
                case ChangerType.Plus:
                    scaling.Dollars += _count;
                    break;
                case ChangerType.Minus:
                    scaling.Dollars -= _count;
                    break;
                case ChangerType.Multiply:
                    scaling.Dollars *= _count;
                    break;
                case ChangerType.Divide:
                    scaling.Dollars /= _count;
                    break;
            }

            Used = true;
        }
    }
}
