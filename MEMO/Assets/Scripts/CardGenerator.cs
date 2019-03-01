using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardGenerator : MonoBehaviour {
    //2x2 losuje 2 tekstury
    //4x2 losuje 4 tekstury
    //4x4 bierze 8 tekstur

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Vector2 spaceBetweenCards;


    private List<int> cardNumbers;

    private Vector2 initalSpawn;
    private Vector2 spawnCoordinate;

    private int elementsInHeight;
    private int elementsInWidth;

	void Start () {

        elementsInHeight = BoardParamsScript.Height;
        elementsInWidth = BoardParamsScript.Width;

        FillNumberList();
        cardNumbers = cardNumbers.OrderBy(a => Random.value).ToList();
        FillBoardWithCards();
	}
	
    private void FillBoardWithCards()
    {

        Vector2 cardSize = cardPrefab.GetComponent<RectTransform>().sizeDelta;

        initalSpawn = new Vector2(-elementsInWidth/2*(cardSize.x+spaceBetweenCards.x)-0.5f*spaceBetweenCards.x,
           -elementsInHeight/2*(cardSize.y + spaceBetweenCards.y) - 0.5f * spaceBetweenCards.y);
        spawnCoordinate = initalSpawn;

        int counter=0;

        for (int i = 0; i < elementsInHeight; i++)
        {
            if (i != 0)
            {
                spawnCoordinate.x = initalSpawn.x;
                spawnCoordinate.y += (cardSize.y + spaceBetweenCards.y);
            }
            for (int j = 0; j < elementsInWidth; j++)
            {

                GameObject newCard = Instantiate(cardPrefab, transform) as GameObject;
                newCard.transform.localPosition = spawnCoordinate;
                newCard.GetComponent<CardBehaviour>().cardId = cardNumbers[counter];
                spawnCoordinate.x += cardSize.x + spaceBetweenCards.x;

                counter++;
            }
        }
    }

    private void SetCardsFaces()
    {
        

    }

    private void FillNumberList()
    {
        cardNumbers = new List<int>(elementsInHeight * elementsInWidth);
        int currentCardNumber = 0;

        for (int i = 0; i < elementsInHeight * elementsInWidth; i++)
        {
            if(i%2 == 0)
            {
                currentCardNumber++;
            }
            cardNumbers.Add(currentCardNumber);
        }

       
    }

	void Update () {
		
	}
}
