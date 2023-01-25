using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    //PlayerController playerControlerScript;
    bool isNextLevelActive;
    void Start()
    {
        GameObject nextLvlButton =  GameObject.FindGameObjectWithTag("NextLvl");
        isNextLevelActive =  Scoring.Result == Result.Win;
        nextLvlButton.SetActive(isNextLevelActive);
        //playerControlerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(3);
    }
}
