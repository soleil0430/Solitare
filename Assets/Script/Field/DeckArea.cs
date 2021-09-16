using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeckArea : AreaBase
{
    [SerializeField] UserSettingSO userSettingSO;
    public Card nullCard;

    public void InitPushCard(Card initPushCard)
    {
        initPushCard.nowArea = this;

        Vector3 point = mappingPoints[cardList.Count].position;
        point.z = -cardList.Count;

        cardList.AddLast(initPushCard.thisNode);


        initPushCard.transform.DOKill(true);
        initPushCard.transform.DOMove(point, 0.1f);
    }

    public void GetCardByOpenArea(Card openFirstCard)
    {
        if (openFirstCard == null)
            return;

        cardList.AddCardsLast(this, openFirstCard.thisNode);

        Sorting();
    }


    public void Sorting()
    {
        int count = 0;
        Vector3 point;
        //들어온 카드 이동
        for (var current = cardList.First; current != null; current = current.Next)
        {
            point = mappingPoints[count].position;
            point.z = -count;

            current.Value.transform.DOKill(true);
            Sequence sequence = DOTween.Sequence()
                                       .Append(current.Value.transform.DOMove(point, userSettingSO.cardMoveDuration))
                                       .Join(current.Value.transform.DORotate(new Vector3(0, 180, 0), userSettingSO.cardMoveDuration));

            count++;
        }
    }

    
}
