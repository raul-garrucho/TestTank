using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class LeaderBoard : ScriptableObject
{
    public List<float> ranking = new List<float>();
    public void Addscore(float score)
    {
        int maxText = 5;
        if(ranking.Count <= maxText)
        {
            ranking.Add(score);
            ranking.Sort();
            return;
        }
        if(score < ranking[maxText])
        {
            ranking.Add(score);
            ranking.Sort();
            ranking.RemoveAt(maxText + 1);
        }
    }
}
