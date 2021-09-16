using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 영역의 부모 클래스 입니다.
/// 보유한 카드들은 Solitare 룰 특성상 LinkedList와 유사한 모습을 보여서 선택했습니다.
/// 
/// mappingPoints는 추가된 카드들이 이동할 위치 입니다.
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