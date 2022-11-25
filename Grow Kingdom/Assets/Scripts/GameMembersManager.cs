using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMembersManager : MonoBehaviour
{
    [SerializeField]
    private WinManager WinManager;
    [SerializeField]
    private Color[] MembersColor;
    [SerializeField]
    private GameObject PlayersActionBlock;
    [SerializeField]
    private Image ActiveMemberNameBG;
    [SerializeField]
    private Text ActiveMemberNameText;
    [SerializeField]
    private BotController[] Bots;
    [SerializeField]
    private PlayerController Player;
    [SerializeField]
    private int CurrentActiveMemberNumber;

    private void Start()
    {
        ActiveMemberNameBG.color = MembersColor[0];
        ActiveMemberNameText.text = "Ваш ход...";
    }

    public void StartNextMembersAction()
    {
        if (CurrentActiveMemberNumber == 0)
        {
            WinManager.CheckProgress();
            PlayersActionBlock.SetActive(true);
            ActiveMemberNameBG.color = MembersColor[1];
            ActiveMemberNameText.text = Bots[0].BotsName + "...";
        }
        else
            StartCoroutine(DelayFinished());
    }

    public void StartCoroutineDelayFinished() => StartCoroutine(DelayFinished());

    public IEnumerator DelayFinished()
    {
        yield return new WaitForSeconds(Random.Range(1.4f, 2.75f));
        if (CurrentActiveMemberNumber < 3)
        {
            CurrentActiveMemberNumber++;
            Bots[CurrentActiveMemberNumber - 1].FindTheMostPriorityAction();
        }
        else
        {
            PlayersActionBlock.SetActive(false);
            CurrentActiveMemberNumber = 0;
        }
        ActiveMemberNameBG.color = MembersColor[CurrentActiveMemberNumber];
        if (CurrentActiveMemberNumber != 0)
            ActiveMemberNameText.text = Bots[CurrentActiveMemberNumber - 1].BotsName + "...";
        else
            ActiveMemberNameText.text = "Ваш ход...";
    }
}
