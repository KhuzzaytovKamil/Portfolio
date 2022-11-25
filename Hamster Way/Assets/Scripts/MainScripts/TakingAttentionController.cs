using UnityEngine;
using System.Collections;

namespace Main
{
    public class TakingAttentionController : MonoBehaviour
    {
        [SerializeField]
        float SecondsBeforeStartTakingAttentionController;
        [SerializeField]
        float TimeAmplitudeInSecondsBetweenSwitchSize;
        [SerializeField]
        SizeType CurrentSizeType;
        [SerializeField]
        int NumberPiecesUpSize;
        int CurrentNumberPiecesUpSize;

        enum SizeType { Small, Big }

        void Start()
        {
            TimeAmplitudeInSecondsBetweenSwitchSize = TimeAmplitudeInSecondsBetweenSwitchSize / NumberPiecesUpSize;
            CurrentNumberPiecesUpSize = NumberPiecesUpSize;
            StartCoroutine(TakingAttention(SecondsBeforeStartTakingAttentionController));
        } 

        IEnumerator TakingAttention(float SecondsBeforeStart)
        {
            yield return new WaitForSeconds(SecondsBeforeStart);
            if (CurrentNumberPiecesUpSize > 0)
            {
                if (CurrentSizeType == SizeType.Small)
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.1f, gameObject.transform.localScale.y + 0.1f, gameObject.transform.localScale.z + 0.1f);
                else
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y - 0.1f, gameObject.transform.localScale.z - 0.1f);
                CurrentNumberPiecesUpSize--;
            }
            else
            {
                CurrentNumberPiecesUpSize = NumberPiecesUpSize;
                if (CurrentSizeType == SizeType.Small)
                    CurrentSizeType = SizeType.Big;
                else
                    CurrentSizeType = SizeType.Small;
            }
            StartCoroutine(TakingAttention(TimeAmplitudeInSecondsBetweenSwitchSize));
        }
    }
}
