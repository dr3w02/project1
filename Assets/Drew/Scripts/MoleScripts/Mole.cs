using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using static System.TimeZoneInfo;

public class Mole : MonoBehaviour
{
    [Header("Graphics")] // this is grabbing all the spites(images)
    [SerializeField] private Sprite angel;
    [SerializeField] private Sprite angelWings;
    [SerializeField] private Sprite angelWingsHit;
    [SerializeField] private Sprite angelHit;
    [SerializeField] private Sprite moleHatHit;
    [SerializeField] private Sprite bomb;
    [SerializeField] private Sprite bombExplode;

    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;
    // this is grabbing my other script called game manager


    //Sprite Position//
    private Vector2 startPostion = new Vector2(0f, -2.26f );
    private Vector2 endPostion = Vector2.zero;

    // How Long it takes to do the show/hide animation//
    private float showDuration = 0.5f;
    //How long the mole is on screen for//
    private float duration = 1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D boxCollider2D; // this controls the size of the box when down and when hit 
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    //Mole Parameters being able to click on mole
    private bool hittable = true;
   
   

    //for hard hat mole
    public enum MoleType { Standard, HardHat, Bomb };
    private MoleType moleType;
    private float hardRate = 0.25f;
    private float bombRate = 1f;
    private int lives;
    //^^^^^^ this is to give the hard hat guys two lives harder to get rid of
    private int moleIndex = 0;

   
    // use the Game Manager script to quickly identify the moles
    public void SetIndex(int index)
    {
        moleIndex = index;
    }

    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        // Makes sure you're starting from the start//
        transform.localPosition = start;


        //Show the mole and amke the animation of up and down repeat 
        float elapsed = 0f;
        while (elapsed < showDuration)

        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            //Update Max framerate//
            elapsed += Time.deltaTime;
            yield return null;

        }

        //makes sure its at the end of its cycle
        transform.localPosition = end;
        boxCollider2D.offset = boxOffset;
        boxCollider2D.size = boxSize;

        //wait for duration to pass//
        yield return new WaitForSeconds(duration);

        //hide the mole
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);
            //Update Max Frame Rate//
            elapsed += Time.deltaTime;
            yield return null;

        }

        //Makes sure were exactly at the start 
        transform.localPosition = start;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;

    }


    //remove this this is just to see it in action// 

    public void Activate(int level)
    {
        SetLevel(level);
        CreateNext();
        StartCoroutine(ShowHide(startPostion, endPostion));
    }
    //remove this this is just to see it in action// 


    //This is to make the box colliders not overlap 
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        //work out colliders size
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPostion.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);

    }


    public void HitMole(int player)
    {
        if (hittable )
        {
            switch (moleType)
            {
                case MoleType.Standard:
                    spriteRenderer.sprite = angelHit;
                    gameManager.AddScore(moleIndex, player);
                    //stop the animation of the normal mole as its been hit and now dead
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());


                    // Turn off hittable so that we cant keep tapping for score.

                    hittable = false;
                 

                    break;

                case MoleType.HardHat:
                    //if lives == 2 reduce the life and change the sprite to the one with the broken hat
                    if (lives == 2)
                    {
                        spriteRenderer.sprite = angelWingsHit;
                        lives--;
                    }

                    else
                    {
                        spriteRenderer.sprite = moleHatHit;
                        gameManager.AddScore(moleIndex, player);
                        //stop the animation
                        StopAllCoroutines();
                        StartCoroutine(QuickHide());
                        //turn of the hittable now so the player cant just keep clicking for a higher score
                        hittable = false;
                   
                    }
                    break;

                
                
                case MoleType.Bomb: // this completely ends the game when the bomb is clicked

                    spriteRenderer.sprite = bomb;

                    if (Input.GetKeyDown(KeyCode.UpArrow))
                        gameManager.GameOver(5);
                    spriteRenderer.sprite = bombExplode;
                        hittable = false;


                    if(Input.GetKeyDown(KeyCode.UpArrow))
                        gameManager.GameOver(5);
                        spriteRenderer.sprite = bombExplode;
                        hittable = false;
                    break;
                default:
                    break;
            }

        }
    }




    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        //whilst waiting to be spawned again the mole might re appear check that hasnt happened before hiding it this stops the sprite flickering
        if (!hittable)
        {
            Hide();
        }
    }

    public void Hide()
    {
        //set the appropiate mold parameters to hide it
        transform.localPosition = startPostion;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }


    // this is for the hard hat mole//

    private void CreateNext()
    {
        //decides between a bomb and a mole
        float random = Random.Range(0f, 1f);
        if (random < bombRate)
        {
            //Make A Bomb
            
            moleType = MoleType.Bomb;
            hittable = true;
          
            
            

        }
        else
        {
            animator.enabled = false;
            random = Random.Range(0f, 1f);
            if (random < hardRate)
            {
                //this is saying if the mole spirte is the hard hate mole to set that sprites lives to two.(two click kill)
                moleType = MoleType.HardHat;
                spriteRenderer.sprite = angelWings;
                lives = 2;
            }
            else
            {
                // this one says if not that mole its the ordinary mole and is set to one life. (one click kill)
                moleType = MoleType.Standard;
                spriteRenderer.sprite = angel;
                lives = 1;
            }

            // this is to ensure were able to click on the mole 
       
            hittable = true;
        }
    }

    //as the game progesses it gets harder

    private void SetLevel(int level)
    {
        // this is sayin that when the level increases the bombs appear 25% more often 
        bombRate = Mathf.Min(level * 0.025f, 0.25f);

        // Increase the amount of harzard hat moles all the way up to 100% at level 40

        hardRate = Mathf.Min(level * 0.025f, 1f);

        //The duration bounds get quicker as we progress this is howq long the mole stays clickable 

        float durationMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
        float durationMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);
        duration = Random.Range(durationMin, durationMax);
    }


   

    public void StopGame()
    {
        
        hittable = false;
        StopAllCoroutines();
    }
}
