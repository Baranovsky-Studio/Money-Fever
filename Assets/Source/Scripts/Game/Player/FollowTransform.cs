using NaughtyAttributes;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Transform _transform;
    
    [BoxGroup("SETTINGS")] [SerializeField] 
    private Vector3 _offset;
    [BoxGroup("SETTINGS")] [SerializeField]
    private float _speed;

    private void FixedUpdate()
    {
        var position = new Vector3(_transform.position.x, _transform.position.y + _transform.localScale.x, _transform.position.z) + _offset;
        transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.fixedDeltaTime);
    }
}
