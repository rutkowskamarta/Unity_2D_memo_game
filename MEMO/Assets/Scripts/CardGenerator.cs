using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour {
    //2x2 losuje 2 tekstury
    //4x2 losuje 4 tekstury
    //4x4 bierze 8 tekstur

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Vector2 spaceBetweenCards;

    private CardBehaviour[,] cards;

    private Vector2 initalSpawn;
    private Vector2 spawnCoordinate;

    private int elementsInHeight;
    private int elementsInWidth;

	void Start () {

        elementsInHeight = BoardParamsScript.Height;
        elementsInWidth = BoardParamsScript.Width;

        cards = new CardBehaviour[elementsInWidth, elementsInHeight];
        FillBoardWithCards();
	}
	
    private void FillBoardWithCards()
    {

        Vector2 cardSize = cardPrefab.GetComponent<RectTransform>().sizeDelta;
        Debug.Log(cardSize);

        initalSpawn = new Vector2(-elementsInWidth/2*(cardSize.x+spaceBetweenCards.x)-0.5f*spaceBetweenCards.x,
           -elementsInHeight/2*(cardSize.y + spaceBetweenCards.y) - 0.5f * spaceBetweenCards.y);
        spawnCoordinate = initalSpawn;
        for (int i = 0; i < elementsInHeight; i++)
        {
            if (i != 0)
            {
                spawnCoordinate.x = initalSpawn.x;
                spawnCoordinate.y += (cardSize.y + spaceBetweenCards.y);
            }
            for (int j = 0; j < elementsInWidth; j++)
            {
                Debug.Log("spawn");

                GameObject gameObject = Instantiate(cardPrefab, transform) as GameObject;
                gameObject.transform.localPosition = spawnCoordinate;
                spawnCoordinate.x += cardSize.x + spaceBetweenCards.x;
            }
        }
    }

	void Update () {
		
	}
}
