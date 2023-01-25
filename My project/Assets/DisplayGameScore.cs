using TMPro;
using UnityEngine;

public class DisplayGameScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI mText = gameObject.GetComponent<TextMeshProUGUI>();
        switch (Scoring.Result)
        {
            case Result.Draw:
                mText.text = $"You both lose :( ";
                break;
            case Result.Win:
                mText.text = $"You get to the next level!";
                break;
            default:
                mText.text = $"The winner is {Scoring.Winner}!";
                break;
          
        }
        mText.text += $"{System.Environment.NewLine}{System.Environment.NewLine}Score Player1: {Scoring.Player1Score}{System.Environment.NewLine}Score Player2: {Scoring.Player2Score}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
