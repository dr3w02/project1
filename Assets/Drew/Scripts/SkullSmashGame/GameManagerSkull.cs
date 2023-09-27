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
    
    [SerializeField] private GameObject player1WinText;
    [SerializeField] private GameObject player2WinText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject outOfTimeText;

    [SerializeField] private List<TextMeshProUGUI> ClickText = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> ClickText1 = new List<TextMeshProUGUI>();
   
    
    

    //This determins the amount of time in game change depending on time we want for our minigame
    private float startingTime = 60f;
    
    //this tracks how much time is remaining 
    private float timeRemaining;
    //this tracks the amount of moles
    
    // this controls how were doing in corilation to the moles left
   
    private bool playing = false;
    private HashSet<SkullSmash> currentSkull= new HashSet<SkullSmash>();

    private int clicks = 0;
    private int clicks1 = 0;
    public TMP_Text clickText;
    public TMP_Text clickText1;



    public void StartGame1()
    {
        playButton.SetActive(false);
       
        
        player1WinText.SetActive(false);
        player2WinText.SetActive(false);
        outOfTimeText.SetActive(false);
        gameUI.SetActive(true);

      
        // START WITH ... SECONDS 
        timeRemaining = startingTime;
        //score = 0;
        //scoreText[0].text = "0";
        //scoreText[1].text = "0";
        playing = true;

    }
    public void Click()
    {
        if (playing)
        {


            clicks++;

        }


    }


    public void Click1()
    {
        if (playing)
        {


            clicks1++;
        }



    }


    public void GameOver(int type)
    {
        if (type == 0)
        {
            player1WinText.SetActive(true);

          
        }
        if (type == 2)
        {
            player2WinText.SetActive(true);


        }
        if (type == 3)
        {
            outOfTimeText.SetActive(true);


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
                GameOver(3);
               
            }
            
            if (clicks >= 15)
            {
               
                GameOver(0);
                clicks = 15;
               

            }

            if (clicks1 >= 15)
            {
                clicks1 = 15;
                GameOver(2);
               

            }




        }
        
        clickText.text = "Player One: " + clicks;

        clickText1.text = "Player Two: " + clicks1;

        timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";

    }


 


   








}