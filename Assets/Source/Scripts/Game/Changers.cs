using UnityEngine;

public class Changers : MonoBehaviour
{
    [SerializeField] 
    private CountChanger _changer1;
    [SerializeField]
    private CountChanger _changer2;

    private void Start()
    {
        _changer1.OnUsed += () =>
        {
            _changer2.Used = true;
        };
        
        _changer2.OnUsed += () =>
        {
            _changer2.Used = true;
        };
    }
}
