using BaranovskyStudio;
using Kuhpik;
using NaughtyAttributes;
using Pocket_Snake;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class WinUIScreen : UIScreen
{
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _next;
    [BoxGroup("LINKS")] [SerializeField] 
    private Counter _counter;
    [BoxGroup("LINKS")] [SerializeField] 
    private Button _claimX2;

    public override void Subscribe()
    {
        _next.onClick.AddListener(OnButtonNextClick);
        _claimX2.onClick.AddListener(OnButtonClaimX2Click);
        YandexGame.RewardVideoEvent += OnRewardedAdShown;
    }

    public override void Open()
    {
        Bootstrap.Instance.PlayerData.GameId++;
        Bootstrap.Instance.PlayerData.LevelId++;
        Bootstrap.Instance.GetSystem<ResourcesSystem>().AddResourceCount(ResourcesSystem.ResourceType.Banknotes, (int) Bootstrap.Instance.GameData.Gold);
        
        if (Bootstrap.Instance.PlayerData.LevelId > SceneManager.sceneCountInBuildSettings - 1)
        {
            Bootstrap.Instance.PlayerData.LevelId = 5;
        }
        Bootstrap.Instance.SaveGame();
        
        _counter.SetValue((int) Bootstrap.Instance.GameData.Gold);
        _claimX2.gameObject.SetActive(true);
        
        base.Open();
    }

    private void OnButtonNextClick()
    {
        Bootstrap.Instance.ChangeGameState(GameStateID.Menu);
        Bootstrap.Instance.GetSystem<LoadLevelSystem>().LoadLevel();
        YandexGame.FullscreenShow();
    }

    private void OnButtonClaimX2Click()
    {
        YandexGame.RewVideoShow(99);
    }
    
    private void OnRewardedAdShown(int id)
    {
        if (id == 99)
        {
            Bootstrap.Instance.GetSystem<ResourcesSystem>().AddResourceCount(ResourcesSystem.ResourceType.Banknotes, (int) Bootstrap.Instance.GameData.Gold);
            
            _claimX2.gameObject.SetActive(false);
            _counter.SetValue((int) Bootstrap.Instance.GameData.Gold * 2);
        }
    }
}
