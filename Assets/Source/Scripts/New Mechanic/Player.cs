using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class Player : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Animator _animator;
    
    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _speed;
    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _sidesSpeed;
    [BoxGroup("MOVEMENT")] [SerializeField]
    private float _sidePos;

    private void Start()
    {
        _animator.SetBool("Is Running", true);
    }
    
    private void Update()
    {
       //if (Bootstrap.Instance.GetCurrentGamestateID() != GameStateID.Game) return;
            
        if (Input.GetMouseButton(0))
        {
            var clampedPos = Mathf.Clamp(transform.position.z + -Input.GetAxis("Mouse X") * _sidesSpeed * _speed, -_sidePos, _sidePos);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, clampedPos), 1f);
        }
            
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
