using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class GameManagerSkull : MonoBehaviour
{
    [Header("UI objects")]
    [SerializeField] private List<SkullSmash> skulls;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject player1WinText;
    [SerializeField] private GameObject player2WinText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject outOfTimeText;

    
    [SerializeField] private List<TextMeshProUGUI> scoreText = new List<TextMeshProUGUI>();
    
    

    private HashSet<SkullClicker> currentClicks = new HashSet<SkullClicker>();

    ScoreManager scoreManager;
    
    private int score;
    private bool playing = false;
    public int skullsIndex;
    public SkullClicker currentClicks;


    //This determins the amount of time in game change depending on time we want for our minigame
    private float startingTime = 60f;

    //this tracks how much time is remaining 
    private float timeRemaining;
    //this tracks the amount of moles

    // this controls how were doing in corilation to the moles left

   
   





    public void StartGame1()
    {
        playButton.SetActive(false);
        player1WinText.SetActive(false);
        player2WinText.SetActive(false);
        outOfTimeText.SetActive(false);
        gameUI.SetActive(true);
        nextButton.SetActive(false);

        //START WITH ... SECONDS 
        timeRemaining = startingTime;
        score = 0;
        scoreText[0].text = "0";
        scoreText[1].text = "0";
        playing = true;
        currentClicks.Clear();


    }






    public void GameOver(int type)
    {
        if (type == 0)
        {
            player1WinText.SetActive(true);
            nextButton.SetActive(true);


        }
        if (type == 2)
        {
            player2WinText.SetActive(true);
            nextButton.SetActive(true);

        }
        if (type == 3)
        {
            outOfTimeText.SetActive(true);
            nextButton.SetActive(true);

        }

        playing = false;

    }
    //ending the game no more moles left to click


        void Update()
        {
            if (playing)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    GameOver(0);
                    nextButton.SetActive(true);
                }

                if score[0] <= score[1]
                {

                    GameOver(2);




                }

                if score[1] <= score[0]
                {

                    GameOver(3);


                }


                timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";

                //15 min in video he explains this part, this is bascially saying once 10 moles have been hit the level diffculty will increase
                //once 10 moles are hit odwn more molews will apprear
                if (currentClicks.Count)
                {
                    //chose a random mole
                    int index = Random.Range(0, skulls.Count);

                    if (!currentClicks.Contains(skulls[index]))
                    {
                        currentClicks.Add(skulls[index]);
                        
                    }

                }
            }

        }
        public void AddScore(int moleIndex, int playerIndex) //for when we've sucessfully clicked the mole
        {
            //add and update score
            score += 1;
            scoreText[playerIndex].text = $"{score}";


            currentClicks.Remove(skulls[moleIndex]);

        }



    }


}