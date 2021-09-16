using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineArea : AreaBase
{
    [SerializeField] UserSettingSO userSettingSO;

    public override bool CanPushCard(Card pushCard)
    {
        //�������� ī�尡 null�� �ƴ϶��
        if (pushCard != null)
        {
            //���� ī�尡 ���� ���¶��
            if (lastCard == null)
            {
                //�������� ī�尡 K���
                if (pushCard.cardNumber == ECardNumber.King)
                {
                    return true; //����
                }
            }
            //ī�尡 �ִ� ���¶��
            else
            {
                //������ ī��� ���� �ٸ���
                //-1������ ī����
                if (lastCard.cardColor != pushCard.cardColor &&
                    lastCard.cardNumber - 1 == pushCard.cardNumber)
                {
                    return true;
                }
            }
        }


        return false;
    }

    public override bool PushCard(Card pushCard)
    {
        if (CanPushCard(pushCard) == false)
            return false;

        cardList.AddCardsLast(this, pushCard.thisNode);

        Sorting();

        return true;
    }

    void Sorting()
    {
        int count = 0;
        Vector3 point;
        //���� ī�� �̵�
        for (var current = cardList.First; current != null; current = current.Next)
        {
            point = mappingPoints[count].position;
            point.z = -count;

            current.Value.transform.DOKill(true);
            Sequence sequence = DOTween.Sequence()
                                       .Append(current.Value.transform.DOMove(point, userSettingSO.cardMoveDuration));
                                       
            count++;
        }
    }

    public void OpenLastCard()
    {
        if (lastCard)
            lastCard.transform.DORotate(Vector3.zero, userSettingSO.cardMoveDuration);
    }

    public void InitPushCard(Card initPushCard)
    {
        initPushCard.nowArea = this;

        Vector3 point = mappingPoints[cardList.Count].position;
        point.z = -cardList.Count;

        cardList.AddLast(initPushCard.thisNode);

        initPushCard.transform.DOKill(true);
        initPushCard.transform.DOMove(point, userSettingSO.cardMoveDuration);
    }

    public void EndInit()
    {
        var card = cardList.Last.Value;

        card.transform.DOKill(true);
        card.transform.DORotate(Vector3.zero, userSettingSO.cardMoveDuration);
    }
}
