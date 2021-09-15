using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ������ �θ� Ŭ���� �Դϴ�.
/// LinkedList�� Wrapping�� CardList�� �ʵ�� �����մϴ�.
/// Solitare �� Ư���� LinkedList�� ������ ����� ������ �����߽��ϴ�.
/// 
/// mappingPoints�� �߰��� ī����� �̵��� ��ġ �Դϴ�.
/// </summary>
public abstract class AreaBase : MonoBehaviour
{
    public CardList cardList = new CardList();
    public List<Transform> mappingPoints = new List<Transform>();


    #region ON_GAME
    public virtual void CanPushCard(Card pushCard)
    {
        
    }

    public virtual void PushCard(Card pushCard)
    {

    }

    public virtual void Sorting()
    {
        
    }

    protected virtual void SortingZOrder()
    {

    }
    #endregion


    #region ON_INIT
    public virtual void InitPushCard(Card initPushCard)
    {

    }
    #endregion
}