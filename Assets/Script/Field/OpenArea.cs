using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class OpenArea : AreaBase
{
    [SerializeField] UserSettingSO userSettingSO;
    public DeckArea deckArea;


    
    public override bool PushCard(Card pushCard)
    {
        //null이 들어왔다면?
        if (pushCard == null)
        {
            //전부 도로 Deck Area에 넣어준다
            
            deckArea.GetCardByOpenArea(cardList.First?.Value);
        }
        else
        {
            //Deck에서 새 카드가 들어왔다
            cardList.AddCardsLast(this, pushCard.thisNode);
        }
        
        Sorting();

        return true;
    }

    public void Sorting()
    {
        int count = 0;
        Vector3 point;
        //들어온 카드 이동
        for (var current = cardList.Last; current != null; current = current.Previous)
        {
            point = mappingPoints[count].position;
            point.z = -cardList.Count + count;

            current.Value.transform.DOKill(true);
            Sequence sequence = DOTween.Sequence()
                                       .Append(current.Value.transform.DOMove(point, userSettingSO.cardMoveDuration))
                                       .Join(current.Value.transform.DORotate(Vector3.zero, userSettingSO.cardMoveDuration));

            count++;
        }
    }

}
