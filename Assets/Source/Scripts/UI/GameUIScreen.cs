using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class GameUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Counter _counter;

    public override void Open()
    {
        _counter.SetValue(Bootstrap.Instance.PlayerData.GameId);
        base.Open();
    }
}
