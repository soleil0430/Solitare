using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


//�ν����� ������ ���ؼ�..
[Serializable]
public class CardList
{
#if UNITY_EDITOR
    public List<Card> list = new List<Card>(); //������ �����
#endif



}


/*
//    /// <summary>
//    /// ���� �߰�
//    /// ���� �������� �ڵ����� Ż���Ŵ
//    /// </summary>
//    /// <param name="linkedList"></param>
//    /// <param name="cardNode"></param>
//    /// <returns>true : ����, false : ����</returns>
//    public bool AddCardLast(LinkedListNode<Card> cardNode)
//    {
//        if (cardNode == null)
//            return false;

//        //ī�尡 ������ �پ��ִٸ�
//        if (cardNode.TailCount() > 0)
//            return false;

//        //�پ��ִ� List
//        var previousList = cardNode.List;

//        //���� �ٸ� ������ �ҼӵǾ� �ִ� ī����
//        if (previousList != null)
//            previousList.Remove(cardNode); //����

//        //���� ������ �߰�
//        linkedList.AddLast(cardNode);


//#if UNITY_EDITOR
//        list = new List<Card>(linkedList); //������ �����
//#endif
//        return true;
//    }

//    /// <summary>
//    /// ���� �߰�
//    /// ���� �������� �ڵ����� Ż���Ŵ
//    /// </summary>
//    /// <param name="linkedList"></param>
//    /// <param name="card"></param>
//    /// <returns>true : ����, false : ����</returns>
//    public bool AddCardLast(Card card)
//    {
//        if (card == null)
//            return false;

//        return AddCardLast(card.thisNode);
//    }*/