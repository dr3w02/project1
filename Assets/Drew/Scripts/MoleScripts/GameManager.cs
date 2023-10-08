    using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEditor.SearchService;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Mole> moles;

    [Header("UI objects")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private GameObject bombTextP1;
    [SerializeField] private GameObject bombTextP2;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject playerOneText;
    [SerializeField] private GameObject playerTwoText;
    [SerializeField] private GameObject tieText;
    [SerializeField] private List<TextMeshProUGUI> scoreText = new List<TextMeshProUGUI>();


    //This determins the amount of time in game change depending on time we want for our minigame
    private float startingTime = 60f;

    //this tracks how much time is remaining 
    private float timeRemaining;
    //this tracks the amount of moles
    private HashSet<Mole> currentMoles = new HashSet<Mole>();
    // this controls how were doing in corilation to the moles left
    private int score;
    private int player1Score;
    private int player2Score;
    private bool playing = false;
    public int playerIndex;
    public Mole currentMole;
    private int bomb;


    //this is how the game starts setting everything up 

    public void StartGame()
    {
        playButton.SetActive(false);
        outOfTimeText.SetActive(false);
        bombTextP1.SetActive(false);
        bombTextP2.SetActive(false);
        gameUI.SetActive(true);
        nextButton.SetActive(false);
        tieText.SetActive(false);
       
        
        //hide all the visable moles
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Hide();
            moles[i].SetIndex(i);
        }

        //remove any old game stats 
        currentMoles.Clear();
        // START WITH 30 SECONDS 
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
            nextButton.SetActive(true);
        }
        if (type == 1)
        {
            playerOneText.SetActive(true);
            nextButton.SetActive(true);
        }
        if (type == 2)
        {
            playerTwoText.SetActive(true);
            nextButton.SetActive(true);
        }
        if (type == 3)
        {
            tieText.SetActive(true);
            nextButton.SetActive(true);
        }
        if (type == 4)
        {
            bombTextP1.SetActive(true);
            nextButton.SetActive(true);
        }
        if (type == 5)
        {
            bombTextP2.SetActive(true);
            nextButton.SetActive(true);
        }


        //Hide all the moles 
        foreach (Mole mole in moles)
        {
            mole.StopGame();

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


                if (player1Score > player2Score)
                {
                    GameOver(2);
                }

                if (player1Score < player2Score)
                {
                    GameOver(1);

                }


            }


            timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";

            //15 min in video he explains this part, this is bascially saying once 10 moles have been hit the level diffculty will increase
            //once 10 moles are hit odwn more molews will apprear
            if (currentMoles.Count <= (player1Score / 10))
            {
                //chose a random mole
                int index = Random.Range(0, moles.Count);

                if (!currentMoles.Contains(moles[index]))
                {
                    currentMoles.Add(moles[index]);
                    moles[index].Activate(score / 10);
                }

            }
            if (currentMoles.Count <= (player2Score / 10))
            {
                //chose a random mole
                int index = Random.Range(0, moles.Count);

                if (!currentMoles.Contains(moles[index]))
                {
                    currentMoles.Add(moles[index]);
                    moles[index].Activate(score / 10);
                }

            }
        }

    }
    public void AddScore(int moleIndex, int playerIndex) //for when we've sucessfully clicked the mole
    {
        //add and update score
        if (playerIndex == 1)
        {
            player1Score += 1;
            scoreText[playerIndex].text = $"{player1Score}";
        }
        else
        {
            player2Score += 1;
            scoreText[playerIndex].text = $"{player2Score}";
        }
        
       


        currentMoles.Remove(moles[moleIndex]);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (player1Score == bomb)
        {
            GameOver(4);
        }
        
        if (player1Score == bomb)
        {
            GameOver(5);
        }

        else
        {
            GameOver(3);
        }
        
    }

    


}

