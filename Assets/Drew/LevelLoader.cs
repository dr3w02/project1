using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame



    //MAKE SURE TO SET ALPHA BACK TO 1 ONCE YOU'RE DONEEEEEEEEE ITS IN THE PREFAB ON THE IMAGE
    //



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {

        //("get") that part means whatever the build mananger numbering is it would go to the next number if u want to just havbe it as scene name remove all in the "" AND MAKE IT THE SCENE NAME
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}