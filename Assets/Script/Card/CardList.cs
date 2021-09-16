using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


//인스펙터 노출을 위해서..
[Serializable]
public class CardList
{
#if UNITY_EDITOR
    public List<Card> list = new List<Card>(); //에디터 노출용
#endif



}


/*
//    /// <summary>
//    /// 낱장 추가
//    /// 이전 영역에서 자동으로 탈퇴시킴
//    /// </summary>
//    /// <param name="linkedList"></param>
//    /// <param name="cardNode"></param>
//    /// <returns>true : 성공, false : 실패</returns>
//    public bool AddCardLast(LinkedListNode<Card> cardNode)
//    {
//        if (cardNode == null)
//            return false;

//        //카드가 여러장 붙어있다면
//        if (cardNode.TailCount() > 0)
//            return false;

//        //붙어있던 List
//        var previousList = cardNode.List;

//        //만약 다른 영역에 소속되어 있던 카드라면
//        if (previousList != null)
//            previousList.Remove(cardNode); //제거

//        //현재 영역에 추가
//        linkedList.AddLast(cardNode);


//#if UNITY_EDITOR
//        list = new List<Card>(linkedList); //에디터 노출용
//#endif
//        return true;
//    }

//    /// <summary>
//    /// 낱장 추가
//    /// 이전 영역에서 자동으로 탈퇴시킴
//    /// </summary>
//    /// <param name="linkedList"></param>
//    /// <param name="card"></param>
//    /// <returns>true : 성공, false : 실패</returns>
//    public bool AddCardLast(Card card)
//    {
//        if (card == null)
//            return false;

//        return AddCardLast(card.thisNode);
//    }*/