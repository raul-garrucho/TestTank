using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tankprototipe
{
    public class LeaderBoardPanel : MonoBehaviour
    {
        [SerializeField] private LeaderBoard leaderBoard;
        [SerializeField] private Text finalScore;
        [SerializeField] private Transform rankingSpot;
        [SerializeField] private List<Text> rankingTextList = new List<Text>();

        public void Initialize(float score)
        {
            leaderBoard.Addscore(score);
            RefreshUi(score);
            gameObject.SetActive(true);
        }
        private void RefreshUi(float score)
        {
            finalScore.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
            for (int i = 0; i < leaderBoard.ranking.Count; i++)
            {
                rankingTextList[i].text = string.Format((i + 1).ToString() + " - " + "{0:00}:{1:00}", Mathf.FloorToInt(leaderBoard.ranking[i] / 60), Mathf.FloorToInt(leaderBoard.ranking[i] % 60));
            }
        }
    }

}
