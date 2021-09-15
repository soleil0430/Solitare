using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class CardList
{
    public LinkedList<Card> linkedlist = new LinkedList<Card>();
#if UNITY_EDITOR
    public List<Card> list = new List<Card>(); //������ �����
#endif


    public void AddCard(Card card)
    {
        if (card == null)
            return;

        //���� LinkedList���� ���� �� �߰�
        var previousList = card.thisNode?.List;
        if (previousList != null)
            previousList.Remove(card.thisNode);

        //���� LinkedList�� �߰�
        linkedlist.AddLast(card.thisNode);

#if UNITY_EDITOR
        list = new List<Card>(linkedlist); //������ �����
#endif
    }

    

}