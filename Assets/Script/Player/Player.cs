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
    //        //Raycast�� �̿��Ͽ� ī�� ����
    //        selectCard = CardSelectUsingRay();
            
    //        //������ ī�尡 �ִٸ� �̵��� �� �ִ� ���� Ž��
    //        AreaBase targetArea = AreaSearch(selectCard);

    //        //Ž���� �������� �̵�
    //        MoveCard(selectCard, targetArea);

    //        ////������ ī�� �ʱ�ȭ
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
