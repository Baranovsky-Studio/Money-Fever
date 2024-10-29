using NaughtyAttributes;
using UnityEngine;

namespace Source.Scripts.New_Mechanic
{
    public class Gold : MonoBehaviour
    {
        [BoxGroup("LINKS")] [SerializeField]
        private Rigidbody _rigidbody;

        public void Throw()
        {
            transform.parent = null;
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
        }
    }
}