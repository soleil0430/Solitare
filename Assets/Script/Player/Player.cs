using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private Card selectCard;


    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        //Raycast를 이용하여 카드 선택
    //        selectCard = CardSelectUsingRay();
            
    //        //선택한 카드가 있다면 이동할 수 있는 영역 탐색
    //        AreaBase targetArea = AreaSearch(selectCard);

    //        //탐색한 영역으로 이동
    //        MoveCard(selectCard, targetArea);

    //        ////선택한 카드 초기화
    //        selectCard = null;
    //    }
    //}

    //Card CardSelectUsingRay()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue))
    //        return hitInfo.collider.gameObject.GetComponent<Card>();

    //    return null;
    //}

    //AreaBase AreaSearch(Card _card)
    //{
    //    if (selectCard == null)
    //        return null;

    //    List<ClearArea> clearAreas = GameManager.Instance.clearAreas;
    //    foreach (ClearArea clearArea in clearAreas)
    //    {
    //        if (clearArea.CanPushCard(_card))
    //            return clearArea;
    //    }

    //    List<LineArea> lineAreas = GameManager.Instance.lineAreas;
    //    foreach (LineArea lineArea in lineAreas)
    //    {
    //        if (lineArea.CanPushCard(_card))
    //            return lineArea;
    //    }

    //    return null;
    //}

    //void MoveCard(Card _card, AreaBase _area)
    //{
    //    if (_card == null || _area == null)
    //        return;

    //    _area.PushCard(_card);
    //}

}
