using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider))]
public class Card : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public LinkedListNode<Card> thisNode;
    public AreaBase nowArea;

    public ECardShape cardShape;
    public ECardNumber cardNumber;
    public ECardColor cardColor
    {
        get
        {
            if (cardShape == ECardShape.Spade || cardShape == ECardShape.Clover)
                return ECardColor.Black;
            else
                return ECardColor.Red;
        }
    }

    public Sprite frontSprite;
    public Sprite backSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisNode = new LinkedListNode<Card>(this);
    }

    public bool IsFlip(float a)
    {
        return (90f <= a && a <= 270f);
    }
    public bool IsReverse => (IsFlip(rotation.x) || IsFlip(rotation.y));

    Vector3 rotation;
    private void Update()
    {
        rotation = transform.rotation.eulerAngles;

        if (IsReverse)
        {
            spriteRenderer.sprite = backSprite;
        }
        else
        {
            spriteRenderer.sprite = frontSprite;
        }
    }
}
