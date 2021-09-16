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
            //CardManager의 Pool을 손상시키지 않기 위해 깊은 복사
            pool = cardManager.pool.ConvertAll(o => o);
            pool.Shuffle(new System.Random());
        }


        //Line Area 초기화
        for (int i = 0; i < lineAreas.Count; ++i)
        {
            //순서대로
            LineArea lineArea = lineAreas[i];

            //Line의 Number만큼 카드 추가
            //ex) Line 1 이면 카드 1장, 6이면 6장
            for (int j = 0; j <= i; ++j)
            {
                lineArea.InitPushCard(pool[pool.Count - 1]);
                pool.RemoveAt(pool.Count - 1);

                yield return new WaitForSeconds(userSettingSO.lineInitInterval);
            }

            //마지막 카드 뒤집기
            lineArea.EndInit();
            yield return new WaitForSeconds(userSettingSO.lineInitInterval);
        }


        //Line에 카드를 다 넣었으니 pool에는 남은 카드들이 존재
        //전부 Deck에 때려박기
        foreach (var item in pool)
        {
            //Deck에 넣기
            deckArea.InitPushCard(item);
            yield return new WaitForSeconds(userSettingSO.deckInitInterval);
        }

        //Deck 맨 위에 있는 카드 뒤집기
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

            //선택한 카드가 있다면
            if (selectCard)
            {
                //이동 가능한 영역 탐색
                AreaBase moveArea = SearchMoveableArea();
                //가능한 영역이 있다면
                if (moveArea)
                {
                    AreaBase beforeArea = selectCard.nowArea;
                    
                    //그 영역에 카드 넣기
                    moveArea.PushCard(selectCard);
                    moveCount++;
                    moveCountUI.text = "Move Count : " + moveCount;


                    //이동되기 전 영역
                    if (beforeArea)
                    {
                        //Line이었다면
                        if (beforeArea.GetType() == typeof(LineArea))
                        {
                            LineArea line = beforeArea as LineArea;
                            line.OpenLastCard(); //해당 Line의 맨 마지막 카드 Open
                        }
                        //Open이었다면
                        else if (beforeArea.GetType() == typeof(OpenArea))
                        {
                            OpenArea open = beforeArea as OpenArea;
                            openArea.Sorting(); //재정렬
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
        //선택한 카드가 DeckArea에 있는 카드라면
        if (selectCard.nowArea == deckArea)
        {
            //그 카드가 null카드라면
            if (selectCard == deckArea.nullCard)
                openArea.PushCard(null); //OpenArea 다시 Deck으로
            //일반 카드이며 Deck의 맨 윗장 카드라면
            else if (selectCard == deckArea.lastCard)
            {
                openArea.PushCard(deckArea.lastCard); //Deck 맨위에 카드 Open
            }
            
        }
        //그 외 다른 영역이라면
        else
        {
            foreach (var area in allAreas)
            {
                //원래 있던 영역이라면
                if (selectCard.nowArea == area)
                    continue; //무시
                
                if (area.CanPushCard(selectCard))
                {
                    return area;
                }
            }
        }

        return null;
    }


}
