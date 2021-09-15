using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class CardList
{
    public LinkedList<Card> linkedlist = new LinkedList<Card>();
#if UNITY_EDITOR
    public List<Card> list = new List<Card>(); //에디터 노출용
#endif


    public void AddCard(Card card)
    {
        if (card == null)
            return;

        //이전 LinkedList에서 제거 후 추가
        var previousList = card.thisNode?.List;
        if (previousList != null)
            previousList.Remove(card.thisNode);

        //현재 LinkedList에 추가
        linkedlist.AddLast(card.thisNode);

#if UNITY_EDITOR
        list = new List<Card>(linkedlist); //에디터 노출용
#endif
    }

    

}