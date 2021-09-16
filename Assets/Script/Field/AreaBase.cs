using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ������ �θ� Ŭ���� �Դϴ�.
/// ������ ī����� Solitare �� Ư���� LinkedList�� ������ ����� ������ �����߽��ϴ�.
/// 
/// mappingPoints�� �߰��� ī����� �̵��� ��ġ �Դϴ�.
/// </summary>
public abstract class AreaBase : MonoBehaviour
{
    public LinkedList<Card> cardList = new LinkedList<Card>();
    public List<Transform> mappingPoints = new List<Transform>();


    #region ON_GAME
    public virtual bool CanPushCard(Card pushCard)
    {
        return false;
    }

    public virtual bool PushCard(Card pushCard)
    {
        return false;
    }
    #endregion

    public Card lastCard => cardList.Count == 0 ? null : cardList.Last.Value;
}