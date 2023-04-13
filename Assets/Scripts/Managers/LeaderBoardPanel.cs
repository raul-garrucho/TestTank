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
        public List<Text> rankingTextList = new List<Text>();

        public void Initialize(float score)
        {
            leaderBoard.Addscore(score);
            gameObject.SetActive(true);
            RefreshUi(score);
            //foreach (Transform position in rankingSpot)
           // {
           //     rankingTextList.Add(position.GetComponent<Text>());
           // }
        }
        private void RefreshUi(float score)
        {
            finalScore.text = string.Format("Your Score: " + "{0:00}:{1:00}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
            for (int i = 0; i < leaderBoard.ranking.Count; i++)
            {
                rankingTextList[i].text = string.Format((i + 1).ToString() + " - " + "{0:00}:{1:00}", Mathf.FloorToInt(leaderBoard.ranking[i] / 60), Mathf.FloorToInt(leaderBoard.ranking[i] % 60));
            }
        }
        public void LeadboardAction(string action)
        {
            gameObject.SetActive(false);
            switch (action)
            {
                case "Retry":
                    FindObjectOfType<Gameplay>().OnePlayerGame();
                    break;
                case "ReturnToMenu":
                    SceneManager.LoadScene("MainMenu");
                    break;
            }
        }
    }

}
