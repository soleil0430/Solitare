using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider))]
public class Card : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Collider collider;

    public LinkedListNode<Card> thisNode;

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
        collider = GetComponent<Collider>();
        thisNode = new LinkedListNode<Card>(this);
    }

    public bool IsFlip(float a)
    {
        return (90f <= a && a <= 270f);
    }


    Vector3 rotation;
    private void Update()
    {
        rotation = transform.rotation.eulerAngles;

        if (IsFlip(rotation.x) || IsFlip(rotation.y))
        {
            spriteRenderer.sprite = backSprite;
        }
        else
        {
            spriteRenderer.sprite = frontSprite;
        }

        transform.rotation = Quaternion.Euler(rotation);
    }
}
