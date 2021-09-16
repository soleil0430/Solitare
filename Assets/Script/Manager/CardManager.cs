using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CardManager : MonoBehaviour
{

    [Header("Front Sprites")]
    [SerializeField] private List<Sprite> spadeSprites;
    [SerializeField] private List<Sprite> diamondSprites;
    [SerializeField] private List<Sprite> heartSprites;
    [SerializeField] private List<Sprite> cloverSprites;

    [Header("Pooling Object")]
    [SerializeField] private List<Card> spades;
    [SerializeField] private List<Card> diamonds;
    [SerializeField] private List<Card> hearts;
    [SerializeField] private List<Card> clovers;

    [Header("Back Sprites")]
    [SerializeField] private Sprite back;

    [Header("Card Start Point")]
    [SerializeField] private Transform mappingPoint;

    [Header("Pooling Cards")]
    public List<Card> pool = new List<Card>();


    private Dictionary<ECardShape, List<Sprite>> cardSpriteDictionary = new Dictionary<ECardShape, List<Sprite>>();
    private Dictionary<ECardShape, List<Card>> cardDictionary = new Dictionary<ECardShape, List<Card>>();


    public void InitPool()
    {
        #region Init List To Dictionary
        cardSpriteDictionary.Add(ECardShape.Spade, spadeSprites);
        cardSpriteDictionary.Add(ECardShape.Diamond, diamondSprites);
        cardSpriteDictionary.Add(ECardShape.Heart, heartSprites);
        cardSpriteDictionary.Add(ECardShape.Clover, cloverSprites);

        cardDictionary.Add(ECardShape.Spade, spades);
        cardDictionary.Add(ECardShape.Diamond, diamonds);
        cardDictionary.Add(ECardShape.Heart, hearts);
        cardDictionary.Add(ECardShape.Clover, clovers);
        #endregion

        
        foreach (ECardShape shape in Enum.GetValues(typeof(ECardShape)))
        {
            cardDictionary.TryGetValue(shape, out List<Card> cards);
            cardSpriteDictionary.TryGetValue(shape, out List<Sprite> frontSprite);

            foreach (ECardNumber number in Enum.GetValues(typeof(ECardNumber)))
            {
                Card card = cards[(int)number - 1];

                card.transform.position = mappingPoint.position;
                card.transform.rotation = Quaternion.Euler(0, 180, 0);

                card.cardShape = shape;
                card.cardNumber = number;

                card.frontSprite = frontSprite[(int)number - 1];
                card.backSprite = back;        
            }
        }
    }
}


