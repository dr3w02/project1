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
    [SerializeField] private List<SkullSmash> smash;

    [Header("UI objects")]

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private GameObject playerOneText;
    [SerializeField] private GameObject playerTwoText;
    [SerializeField] private List<TextMeshProUGUI> scoreText = new List<TextMeshProUGUI>();



    private HashSet<SkullSmash> currentClicks = new HashSet<SkullSmash>();

    ScoreManager scoreManager;

    private int score;
    private int player1Score;
    private int player2Score;

    private bool playing = false;
    public int skullIndex;
    public SkullClicker currentSkull;


    //This determins the amount of time in game change depending on time we want for our minigame
    private float startingTime = 60f;

    //this tracks how much time is remaining 
    private float timeRemaining;
    //this tracks the amount of moles

    // this controls how were doing in corilation to the moles left
    private bool Hittable = true;

    public GameManagerSkull(bool hittable)
    {
        Hittable = hittable;
    }

    public void StartGame()
    {
        playButton.SetActive(false);
        outOfTimeText.SetActive(false);
        gameUI.SetActive(true);
        nextButton.SetActive(false);
        Hittable = true;

        for (int i = 0; i < smash.Count; i++)
        {

            smash[i].SetIndex(i);
        }

        currentClicks.Clear();

        //START WITH ... SECONDS 
        timeRemaining = startingTime;
        score = 0;
        scoreText[0].text = "0";
        scoreText[1].text = "0";
        playing = true;



    }


    public void GameOver(int type)
    {
        if (type == 0)
        {
            outOfTimeText.SetActive(true);
            playerOneText.SetActive(true);
            nextButton.SetActive(true);


        }
        if (type == 2)
        {
            outOfTimeText.SetActive(true);
            playerTwoText.SetActive(true);
            nextButton.SetActive(true);

        }



        playing = false;
        Hittable = false;
    }



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
                Hittable = false;
            }

            timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";

        }
    }


    public void AddScore(int clickIndex, int skullIndex) //for when we've sucessfully clicked the mole
    {
        //add and update score
        score += 1;
        scoreText[skullIndex].text = $"{score}";


        currentClicks.Remove(smash[clickIndex]);

    }

 
}