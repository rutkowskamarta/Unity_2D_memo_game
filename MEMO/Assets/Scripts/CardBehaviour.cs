using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardBehaviour : MonoBehaviour {

    [SerializeField] private Sprite[] textures;
    [SerializeField] private Sprite reverse;

    private CardExposureScript boardControlExposure;

    public int cardId { get; set; }
    private bool isRevealed = false;

    private void Start()
    {
        boardControlExposure = transform.GetComponentInParent<CardExposureScript>();
    }

    public void SetProperTexture()
    {
        if (!isRevealed && !boardControlExposure.AreBothRevealed)
        {
            gameObject.GetComponent<Image>().sprite = textures[cardId - 1];
            isRevealed = true;
            ExecuteEvents.Execute<IBoardEventHandler>(boardControlExposure.gameObject, null, (x, y) => x.CardRevealed(gameObject));
        }

    }

    public void HideCard()
    {
        gameObject.GetComponent<Image>().sprite = reverse;
        isRevealed = false;

    }

   
}
