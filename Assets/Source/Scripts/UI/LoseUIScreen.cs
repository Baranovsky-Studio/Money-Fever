using Kuhpik;
using NaughtyAttributes;
using Pocket_Snake;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LoseUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _tryAgain;
    [BoxGroup("LINKS")] [SerializeField]
    private AudioSource _audioSource;

    public override void Subscribe()
    {
        _tryAgain.onClick.AddListener(OnButtonTryAgainClick);
        base.Subscribe();
    }

    public override void Open()
    {
        base.Open();
        _audioSource.Play();
    }

    private void OnButtonTryAgainClick()
    {
        Bootstrap.Instance.ChangeGameState(GameStateID.Menu);
        Bootstrap.Instance.GetSystem<LoadLevelSystem>().LoadLevel();
       
        YandexGame.FullscreenShow();
    }
}
