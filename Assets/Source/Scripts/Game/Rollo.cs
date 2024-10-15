using NaughtyAttributes;
using UnityEngine;

public class Rollo : MonoBehaviour
{
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _count;

    private bool _used;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cylinder"))
        {
            if (_used) return;
            var scaling = other.gameObject.GetComponent<PlayerScaling>();
            if (scaling == null) return;

            scaling.Dollars += _count;
            _used = true;
            
            gameObject.SetActive(false);
        }
    }
}
