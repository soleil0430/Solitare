using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearArea : AreaBase
{
    [SerializeField] UserSettingSO userSettingSO;
    public ECardShape cardShape;

    public bool IsFull => cardList.Count == 13;

    public override bool CanPushCard(Card pushCard)
    {
        //null이 아닌 카드가 들어온 경우에만 가능
        if (pushCard != null)
        {
            //카드 한장만 가능
            if (pushCard.thisNode.TailCount() == 0)
            {
                //이 클리어 영역과 같은 모양이라면
                if (pushCard.cardShape == cardShape)
                {
                    //현재 카드가 없다면
                    if (cardList.Last == null)
                    {
                        //들어오려는 카드가 Ace(1)이라면
                        if (pushCard.cardNumber == ECardNumber.Ace)
                        {
                            //가능
                            return true;
                        }
                    }
                    //현재 카드가 있으며
                    //이 영역의 마지막 카드 숫자 + 1인 카드가 들어왔다면
                    else if (cardList.Last.Value.cardNumber + 1 == pushCard.cardNumber)
                    {
                        return true;
                    }
                }
            }
        }

        //나머지는 불가능
        return false;
    }


    public override bool PushCard(Card pushCard)
    {
        if (CanPushCard(pushCard) == false)
            return false;

        //카드 추가
        cardList.AddCardsLast(this, pushCard.thisNode);

        //정렬
        Sorting();

        return true;
    }

    public void Sorting()
    {
        int count = 0;
        Vector3 point;
        //들어온 카드 이동
        for (var current = cardList.First; current != null; current = current.Next)
        {
            point = mappingPoints[0].position;
            point.z = -count;

            current.Value.transform.DOKill(true);
            Sequence sequence = DOTween.Sequence()
                                       .Append(current.Value.transform.DOMove(point, userSettingSO.cardMoveDuration))
                                       .Join(current.Value.transform.DORotate(Vector3.zero, userSettingSO.cardMoveDuration));

            count++;
        }
    }


}
