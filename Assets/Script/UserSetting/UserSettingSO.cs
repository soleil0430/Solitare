using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "UserSettingSO", menuName = "Codenoob/UserSetting")]
public class UserSettingSO : ScriptableObject
{
    [Header("Init Speed")]
    public float lineInitInterval;
    public float deckInitInterval;
    public float cardMoveDuration;

}
