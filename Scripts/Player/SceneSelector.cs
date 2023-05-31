using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    private Rigidbody2D rb;
    bool home = false;
    bool playAgain = false;
    bool nextLevel = false;


    bool testLevel = false;

    bool level1 = false;
    bool level2 = false;
    bool level3 = false;
    bool level4 = false;
    bool level5 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(testLevel == true) {
            SceneManager.LoadScene("Base");
            }

            else if(nextLevel == true){
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            }

            else if(playAgain == true){
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }

            else if (home == true){
                SceneManager.LoadScene("HomeScreen");
            }


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("TestLevel"))
        {
            testLevel = true;
        }  

        if(collision.CompareTag("NextLevel")){
            nextLevel = true;
        }

        if(collision.CompareTag("PlayAgain")){
            playAgain = true;
        }

        if(collision.CompareTag("Home")){
            home = true;
        }


        if (collision.CompareTag("Level1"))
        {
            level1 = true;
        }  



        if (collision.CompareTag("Level2"))
        {
            level2 = true;
        }  



        if (collision.CompareTag("Level3"))
        {
            level3 = true;
        }  


    }

    private void OnTriggerExit2D(Collider2D collision){

        testLevel = false;
        home = false;

        nextLevel = false;
        playAgain = false;

        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
    }


}
