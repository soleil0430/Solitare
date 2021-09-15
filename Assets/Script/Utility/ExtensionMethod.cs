using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{
    #region LinkedListNode<Card>
    /// <summary>
    /// �� ī�忡 �޷��ִ� ī����� ����
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static int TailCount(this LinkedListNode<Card> node)
    {
        int count = 0;
        for (var current = node; current != null; current = current.Next)
            count++;

        return count;
    }
    #endregion
}

