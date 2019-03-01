using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public interface IScoreEventHandler : IEventSystemHandler
{
    void Score(bool hasScored);
}

public class PlayerScoreController : MonoBehaviour, IScoreEventHandler {

    [SerializeField] private GameObject textField;
    [SerializeField] private int hitScore = 10;
    [SerializeField] private int missScore = -2;
    [SerializeField] private int loosingCondition = -10;

    private int currentScore = 0;
    private int numberOfPairs;

    private void Start()
    {
        numberOfPairs = BoardParamsScript.Height * BoardParamsScript.Width / 2;
        textField.GetComponent<TextMeshProUGUI>().text = "Score: " + currentScore;
    }


    public void Score(bool hasScored)
    {
        if (hasScored)
        {
            currentScore += hitScore;
            numberOfPairs--;
        }
        else
            currentScore += missScore;

        textField.GetComponent<TextMeshProUGUI>().text = "Score: "+currentScore;
    }

    private void Update()
    {
        FinishWhenConditionFullfilled();
    }

    public void FinishWhenConditionFullfilled()
    {
        if (currentScore <= loosingCondition)
        {
            SceneManager.LoadScene("LostScene");
        }
        else if(numberOfPairs==0)
        {
            SceneManager.LoadScene("WonScene");
        }
    }
}
