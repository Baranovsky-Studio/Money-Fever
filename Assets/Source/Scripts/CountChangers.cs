using System;
using NaughtyAttributes;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using Random = UnityEngine.Random;

public class CountChangers : MonoBehaviour
{
    [BoxGroup("LINKS")] [SerializeField] 
    private CountChanger[] _countChangers;

    private bool _doubleMinus;
    private bool _doublePlus;

    [Button]
    private void RandomiseValues()
    {
        for (var n = 0; n < _countChangers.Length - 1; n += 2)
        {
            int var = Random.Range(0, 5);
            if (var == 0 && n > 4 && !_doublePlus) // double +
            {
                _countChangers[n]._changerType = CountChanger.ChangerType.Plus;
                int count1 = Random.Range(8, 35);
                _countChangers[n]._count = count1;
                
                _countChangers[n + 1]._changerType = CountChanger.ChangerType.Plus;
                int count2 = Random.Range(8, 35);
                _countChangers[n + 1]._count = count2;
                
            }
            else if (var == 1 && n > 6 && !_doubleMinus) // double -
            {
                _countChangers[n]._changerType = CountChanger.ChangerType.Minus;
                int count1 = Random.Range(8, 35);
                _countChangers[n]._count = count1;
                
                _countChangers[n + 1]._changerType = CountChanger.ChangerType.Minus;
                int count2 = Random.Range(8, 35);
                _countChangers[n + 1]._count = count2;
            }
            else if (var == 2) // + and -
            {
                _countChangers[n]._changerType = CountChanger.ChangerType.Plus;
                int count1 = Random.Range(8, 35);
                _countChangers[n]._count = count1;
                
                _countChangers[n + 1]._changerType = CountChanger.ChangerType.Minus;
                int count2 = Random.Range(8, 35);
                _countChangers[n + 1]._count = count2;
            }
            else if (var == 3 && n > 4) // * and /
            {
                _countChangers[n]._changerType = CountChanger.ChangerType.Multiply;
                float count1 = Random.Range(0.7f, 1.5f);
                count1 = (float) Math.Round(count1, 1);
                _countChangers[n]._count = count1;
                
                _countChangers[n + 1]._changerType = CountChanger.ChangerType.Divide;
                int count2 = Random.Range(1, 3);
                _countChangers[n + 1]._count = count2;
            }
            else if (var == 4 && n > 4) // * and /
            {
                _countChangers[n]._changerType = CountChanger.ChangerType.Divide;
                int count1 = Random.Range(1, 3);
                _countChangers[n]._count = count1;
                
                _countChangers[n + 1]._changerType = CountChanger.ChangerType.Multiply;
                float count2 = Random.Range(0.7f, 1.5f);
                count2 = (float) Math.Round(count2, 1);
                _countChangers[n + 1]._count = count2;
            }
            
            #if UNITY_EDITOR
            EditorUtility.SetDirty(_countChangers[n]);
            EditorUtility.SetDirty(_countChangers[n + 1]);
            #endif
        }
        
#if UNITY_EDITOR
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
#endif
    }
}
