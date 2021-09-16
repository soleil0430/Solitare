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
        //null�� �ƴ� ī�尡 ���� ��쿡�� ����
        if (pushCard != null)
        {
            //ī�� ���常 ����
            if (pushCard.thisNode.TailCount() == 0)
            {
                //�� Ŭ���� ������ ���� ����̶��
                if (pushCard.cardShape == cardShape)
                {
                    //���� ī�尡 ���ٸ�
                    if (cardList.Last == null)
                    {
                        //�������� ī�尡 Ace(1)�̶��
                        if (pushCard.cardNumber == ECardNumber.Ace)
                        {
                            //����
                            return true;
                        }
                    }
                    //���� ī�尡 ������
                    //�� ������ ������ ī�� ���� + 1�� ī�尡 ���Դٸ�
                    else if (cardList.Last.Value.cardNumber + 1 == pushCard.cardNumber)
                    {
                        return true;
                    }
                }
            }
        }

        //�������� �Ұ���
        return false;
    }


    public override bool PushCard(Card pushCard)
    {
        if (CanPushCard(pushCard) == false)
            return false;

        //ī�� �߰�
        cardList.AddCardsLast(this, pushCard.thisNode);

        //����
        Sorting();

        return true;
    }

    public void Sorting()
    {
        int count = 0;
        Vector3 point;
        //���� ī�� �̵�
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
