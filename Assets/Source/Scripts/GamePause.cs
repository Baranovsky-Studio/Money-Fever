using Kuhpik;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private void OnApplicationFocus(bool hasFocus)
    {
        if (Advertisement.Instance.IsPlaying) return;

        Time.timeScale = hasFocus ? 1f : 0f;
        
        if(Bootstrap.Instance.PlayerData == null) return;
        if (Bootstrap.Instance.PlayerData.Sounds)
        {
            AudioListener.volume = hasFocus ? 1f : 0f;
        }
    }
}
