using System.Collections.Generic;
using System;


public static class ExtensionMethod
{
    #region LinkedListNode<Card>
    /// <summary>
    /// 이 카드에 달려있는 카드들의 개수
    /// 자신을 포함하지 않는 것에 주의
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static int TailCount(this LinkedListNode<Card> node)
    {
        int count = 0;
        for (var current = node.Next; current != null; current = current.Next)
            count++;

        return count;
    }

    /// <summary>
    /// 자신을 포함해서 끝까지 달려있는 모든 카드 반환
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static List<Card> Tail(this LinkedListNode<Card> node)
    {
        List<Card> tails = new List<Card>();
        for (var current = node; current != null; current = current.Next)
            tails.Add(current.Value);

        return tails;
    }
    #endregion

    #region LinkedList<Card>
    /// <summary>
    /// 해당 카드를 꼬리까지 가져와서 현재 영역에 추가
    /// </summary>
    /// <param name="linkedList"></param>
    /// <param name="cardNode"></param>
    /// <returns>추가한 카드</returns>
    public static List<Card> AddCardsLast(this LinkedList<Card> linkedList, AreaBase area, LinkedListNode<Card> cardNode)
    {
        //삭제하려는 카드가 null이거나
        //같은 대상에 추가하려고 하면
        if (cardNode == null || linkedList == cardNode.List)
            return null;

        //이 카드에 줄줄이 달려있는 카드들
        List<Card> tails = cardNode.Tail();

        //이전에 소속된 영역의 List
        var previousList = cardNode.List;

        //만약 다른 영역에 소속되어 있던 카드라면
        if (previousList != null)
            previousList.RemoveCard(cardNode); //이전 영역에서 전부 삭제

        //떼어낸 모든 카드들을 현재 영역에 추가
        foreach (var add in tails)
        {
            linkedList.AddLast(add.thisNode);
            add.nowArea = area;
        }
        
        //수정된 카드들 반환
        return tails;
    }



    /// <summary>
    /// 현재 영역에서 해당 카드부터 꼬리까지 모두 제거
    /// </summary>
    /// <param name="linkedList"></param>
    /// <param name="cardNode"></param>
    /// <returns>삭제된 카드들</returns>
    public static List<Card> RemoveCard(this LinkedList<Card> linkedList, LinkedListNode<Card> cardNode)
    {
        //삭제하려는 카드가 null이거나
        //삭제하려는 카드가 현재 영역에 속해있지 않은 카드라면
        if (cardNode == null || cardNode.List != linkedList)
            return null;

        //꼬리들 전부 가져옴
        List<Card> tails = cardNode.Tail();

        //현재 리스트에서 모조리 제거
        foreach (var remove in tails)
        {
            linkedList.Remove(remove.thisNode);
            remove.nowArea = null;
        }

        //삭제된 카드들 전부 반환
        return tails;
    }
    #endregion

    #region List<T>
    public static void Shuffle<T>(this IList<T> list, Random rnd)
    {
        for (var i = list.Count; i > 0; i--)
            list.Swap(0, rnd.Next(0, i));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }


    #endregion

}

