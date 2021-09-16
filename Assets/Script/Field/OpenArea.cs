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
        //null�� ���Դٸ�?
        if (pushCard == null)
        {
            //���� ���� Deck Area�� �־��ش�
            
            deckArea.GetCardByOpenArea(cardList.First?.Value);
        }
        else
        {
            //Deck���� �� ī�尡 ���Դ�
            cardList.AddCardsLast(this, pushCard.thisNode);
        }
        
        Sorting();

        return true;
    }

    public void Sorting()
    {
        int count = 0;
        Vector3 point;
        //���� ī�� �̵�
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
