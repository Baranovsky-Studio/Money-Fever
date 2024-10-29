using System;
using Kuhpik;
using NaughtyAttributes;
using PocketSnake;
using UnityEngine;

public class PlayerFinishing : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private PlayerMovement _movement;
    [BoxGroup("LINKS")] [SerializeField] 
    private PlayerScaling _scaling;

    private FinishPlatform _platform;
    private float _dollars;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _dollars = _scaling.Dollars;
            
            var finish = other.GetComponent<Finish>();
            _platform = finish.GetFinishPlatform(_scaling.Dollars);
            var movingFrames = _movement.GetFramesToFinishCount(_platform.transform);
            
            _movement.StartFinishing();
            _scaling.StartFinishing(movingFrames);
        }

        if (other.CompareTag("Finish Platform"))
        {
            var platform = other.gameObject.GetComponent<FinishPlatform>();
            if (platform.Equals(_platform))
            {
                _scaling.OnFinish();
                Bootstrap.Instance.GameData.Gold = _dollars;
                Bootstrap.Instance.ChangeGameState(GameStateID.Win);
                platform.OnReached();
            }
            else
            {
                platform.OnReached();
            }
        }
    }
}
