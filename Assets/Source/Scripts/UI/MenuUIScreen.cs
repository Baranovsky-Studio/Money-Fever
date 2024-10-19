using Kuhpik;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _play;
    [BoxGroup("LINKS")] [SerializeField] 
    private Counter _counter;

    public override void Subscribe()
    {
        _play.onClick.AddListener(OnButtonPlayClick);
        base.Subscribe();
    }

    public override void Open()
    {
        _counter.SetValue(Bootstrap.Instance.PlayerData.GameId);
        base.Open();
    }

    private void OnButtonPlayClick()
    {
        Bootstrap.Instance.ChangeGameState(GameStateID.Game);
    }
}
