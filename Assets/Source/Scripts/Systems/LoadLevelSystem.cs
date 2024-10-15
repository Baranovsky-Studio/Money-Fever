using Kuhpik;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pocket_Snake
{
    public class LoadLevelSystem : GameSystem
    {
        [BoxGroup("TEST MODE")] [SerializeField] 
        private int _testLevelId;
        
        public override void OnInit()
        {
            LoadLevel();
            base.OnInit();
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(_testLevelId != 0 ? _testLevelId : player.LevelId);
        }
    }
}
