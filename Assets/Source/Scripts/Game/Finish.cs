using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private FinishPlatform[] _platfoms;

    public FinishPlatform GetFinishPlatform(float dollars)
    {
        for (var n = 0; n < _platfoms.Length - 1; n++) 
        {
            if (dollars >= _platfoms[n].Score  && dollars < _platfoms[n + 1].Score)
            {
                return _platfoms[n];
            }
        }

        return null;
    }
}
