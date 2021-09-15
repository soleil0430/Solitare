using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 영역의 부모 클래스 입니다.
/// LinkedList를 Wrapping한 CardList를 필드로 보유합니다.
/// Solitare 룰 특성상 LinkedList와 유사한 모습을 보여서 선택했습니다.
/// 
/// mappingPoints는 추가된 카드들이 이동할 위치 입니다.
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