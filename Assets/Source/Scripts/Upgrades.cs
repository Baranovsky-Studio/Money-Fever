using UnityEngine;

namespace Source.Scripts
{
    [CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades", order = 0)]
    public class Upgrades : ScriptableObject
    {
        public float[] StartDollars;
        public float[] Speed;
    }
}