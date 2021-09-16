using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EGameState
{
    SetCard,
    OnGame,
    GameClear,
}


public class GameManager : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    [SerializeField] private UserSettingSO userSettingSO;

    public EGameState gameState;

    public DeckArea deckArea;
    public OpenArea openArea;
    public List<ClearArea> clearAreas;
    public List<LineArea> lineAreas;

    public List<AreaBase> allAreas;


    public int moveCount = 0;

    [Header("UI")]
    public Text moveCountUI;
    public GameObject clearUI;


    [Header("Debugging")]
    public static bool isDebugging = true;
    public List<Card> debugPool;

    private void Start()
    {
        gameState = EGameState.SetCard;
        cardManager.InitPool();

        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        List<Card> pool = new List<Card>();

        if (isDebugging)
            pool = debugPool;
        else
        {
            //CardManager�� Pool�� �ջ��Ű�� �ʱ� ���� ���� ����
            pool = cardManager.pool.ConvertAll(o => o);
            pool.Shuffle(new System.Random());
        }


        //Line Area �ʱ�ȭ
        for (int i = 0; i < lineAreas.Count; ++i)
        {
            //�������
            LineArea lineArea = lineAreas[i];

            //Line�� Number��ŭ ī�� �߰�
            //ex) Line 1 �̸� ī�� 1��, 6�̸� 6��
            for (int j = 0; j <= i; ++j)
            {
                lineArea.InitPushCard(pool[pool.Count - 1]);
                pool.RemoveAt(pool.Count - 1);

                yield return new WaitForSeconds(userSettingSO.lineInitInterval);
            }

            //������ ī�� ������
            lineArea.EndInit();
            yield return new WaitForSeconds(userSettingSO.lineInitInterval);
        }


        //Line�� ī�带 �� �־����� pool���� ���� ī����� ����
        //���� Deck�� �����ڱ�
        foreach (var item in pool)
        {
            //Deck�� �ֱ�
            deckArea.InitPushCard(item);
            yield return new WaitForSeconds(userSettingSO.deckInitInterval);
        }

        //Deck �� ���� �ִ� ī�� ������
        openArea.PushCard(deckArea.lastCard);
        gameState = EGameState.OnGame;
        yield return null;
    }


    public Card selectCard;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameState == EGameState.OnGame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue))
            {
                selectCard = hitInfo.collider.gameObject.GetComponent<Card>();
            }

            //������ ī�尡 �ִٸ�
            if (selectCard)
            {
                //�̵� ������ ���� Ž��
                AreaBase moveArea = SearchMoveableArea();
                //������ ������ �ִٸ�
                if (moveArea)
                {
                    AreaBase beforeArea = selectCard.nowArea;
                    
                    //�� ������ ī�� �ֱ�
                    moveArea.PushCard(selectCard);
                    moveCount++;
                    moveCountUI.text = "Move Count : " + moveCount;


                    //�̵��Ǳ� �� ����
                    if (beforeArea)
                    {
                        //Line�̾��ٸ�
                        if (beforeArea.GetType() == typeof(LineArea))
                        {
                            LineArea line = beforeArea as LineArea;
                            line.OpenLastCard(); //�ش� Line�� �� ������ ī�� Open
                        }
                        //Open�̾��ٸ�
                        else if (beforeArea.GetType() == typeof(OpenArea))
                        {
                            OpenArea open = beforeArea as OpenArea;
                            openArea.Sorting(); //������
                        }
                    }
                }
            }

            bool clearFlag = true;
            foreach (var clearArea in clearAreas)
            {
                if (clearArea.IsFull == false)
                    clearFlag = false;
            }

            if (clearFlag)
            {
                gameState = EGameState.GameClear;
                clearUI.SetActive(true);
            }
            
        }
    }


    AreaBase SearchMoveableArea()
    {
        //������ ī�尡 DeckArea�� �ִ� ī����
        if (selectCard.nowArea == deckArea)
        {
            //�� ī�尡 nullī����
            if (selectCard == deckArea.nullCard)
                openArea.PushCard(null); //OpenArea �ٽ� Deck����
            //�Ϲ� ī���̸� Deck�� �� ���� ī����
            else if (selectCard == deckArea.lastCard)
            {
                openArea.PushCard(deckArea.lastCard); //Deck ������ ī�� Open
            }
            
        }
        //�� �� �ٸ� �����̶��
        else
        {
            foreach (var area in allAreas)
            {
                //���� �ִ� �����̶��
                if (selectCard.nowArea == area)
                    continue; //����
                
                if (area.CanPushCard(selectCard))
                {
                    return area;
                }
            }
        }

        return null;
    }


}
