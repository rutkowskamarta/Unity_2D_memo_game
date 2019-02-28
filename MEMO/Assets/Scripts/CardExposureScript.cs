using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IBoardEventHandler : IEventSystemHandler
{
    void CardRevealed(GameObject card);
}

public class CardExposureScript : MonoBehaviour, IBoardEventHandler{

    [SerializeField] private float revealTime = 1f;

    private GameObject firstCardRevealed  = null;
    private GameObject secondCardRevealed  = null;
    public bool AreBothRevealed  = false;


    public void CardRevealed(GameObject card)
    {
        if(firstCardRevealed == null)
        {
            firstCardRevealed = card;
        }
        else
        {
            secondCardRevealed = card;
            AreBothRevealed = true;
            StartCoroutine(HideCards());
        }
    }
    private IEnumerator HideCards()
    {
        yield return new WaitForSeconds(revealTime);

        if(firstCardRevealed.GetComponent<CardBehaviour>().cardId == secondCardRevealed.GetComponent<CardBehaviour>().cardId)
        {
            HideSameCards();
        }
        else
        {
            HideDifferentCards();
        }

        firstCardRevealed = null;
        secondCardRevealed = null;
        AreBothRevealed = false;
    }

    private void HideDifferentCards()
    {
        firstCardRevealed.GetComponent<CardBehaviour>().HideCard();
        secondCardRevealed.GetComponent<CardBehaviour>().HideCard();

    }

    private void HideSameCards()
    {
        Destroy(firstCardRevealed);
        Destroy(secondCardRevealed);
    }

}
