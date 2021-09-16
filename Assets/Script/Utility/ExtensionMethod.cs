using System.Collections.Generic;
using System;


public static class ExtensionMethod
{
    #region LinkedListNode<Card>
    /// <summary>
    /// �� ī�忡 �޷��ִ� ī����� ����
    /// �ڽ��� �������� �ʴ� �Ϳ� ����
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
    /// �ڽ��� �����ؼ� ������ �޷��ִ� ��� ī�� ��ȯ
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
    /// �ش� ī�带 �������� �����ͼ� ���� ������ �߰�
    /// </summary>
    /// <param name="linkedList"></param>
    /// <param name="cardNode"></param>
    /// <returns>�߰��� ī��</returns>
    public static List<Card> AddCardsLast(this LinkedList<Card> linkedList, AreaBase area, LinkedListNode<Card> cardNode)
    {
        //�����Ϸ��� ī�尡 null�̰ų�
        //���� ��� �߰��Ϸ��� �ϸ�
        if (cardNode == null || linkedList == cardNode.List)
            return null;

        //�� ī�忡 ������ �޷��ִ� ī���
        List<Card> tails = cardNode.Tail();

        //������ �Ҽӵ� ������ List
        var previousList = cardNode.List;

        //���� �ٸ� ������ �ҼӵǾ� �ִ� ī����
        if (previousList != null)
            previousList.RemoveCard(cardNode); //���� �������� ���� ����

        //��� ��� ī����� ���� ������ �߰�
        foreach (var add in tails)
        {
            linkedList.AddLast(add.thisNode);
            add.nowArea = area;
        }
        
        //������ ī��� ��ȯ
        return tails;
    }



    /// <summary>
    /// ���� �������� �ش� ī����� �������� ��� ����
    /// </summary>
    /// <param name="linkedList"></param>
    /// <param name="cardNode"></param>
    /// <returns>������ ī���</returns>
    public static List<Card> RemoveCard(this LinkedList<Card> linkedList, LinkedListNode<Card> cardNode)
    {
        //�����Ϸ��� ī�尡 null�̰ų�
        //�����Ϸ��� ī�尡 ���� ������ �������� ���� ī����
        if (cardNode == null || cardNode.List != linkedList)
            return null;

        //������ ���� ������
        List<Card> tails = cardNode.Tail();

        //���� ����Ʈ���� ������ ����
        foreach (var remove in tails)
        {
            linkedList.Remove(remove.thisNode);
            remove.nowArea = null;
        }

        //������ ī��� ���� ��ȯ
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

