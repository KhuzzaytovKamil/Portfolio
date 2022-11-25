using UnityEngine;
using System.Collections;

namespace Main
{
    public class TakingAttentionController : MonoBehaviour
    {
        [SerializeField]
        private float SecondsBeforeStartTakingAttentionController;
        [SerializeField]
        private float TimeAmplitudeInSecondsBetweenSwitchSize;
        [SerializeField]
        private SizeType CurrentSizeType;
        [SerializeField]
        private int NumberPiecesUpSize;
        private int CurrentNumberPiecesUpSize;
        [SerializeField]
        private int DelayBetweenSwitchSize;
        private int SizeSwitchedAfterLastDelay;
        private bool SwitchSize = true;

        private enum SizeType { Small, Big }

        private void Start()
        {
            TimeAmplitudeInSecondsBetweenSwitchSize = TimeAmplitudeInSecondsBetweenSwitchSize / NumberPiecesUpSize;
            CurrentNumberPiecesUpSize = NumberPiecesUpSize;
            StartCoroutine(TakingAttention(SecondsBeforeStartTakingAttentionController));
        }

        private IEnumerator TakingAttention(float SecondsBeforeStart)
        {
            yield return new WaitForSeconds(SecondsBeforeStart);
            if (CurrentNumberPiecesUpSize > 0)
            {
                if (SwitchSize)
                {
                    if (CurrentSizeType == SizeType.Small)
                        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.01f, gameObject.transform.localScale.y + 0.01f, gameObject.transform.localScale.z + 0.01f);
                    else
                        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.01f, gameObject.transform.localScale.y - 0.01f, gameObject.transform.localScale.z - 0.01f);
                    CurrentNumberPiecesUpSize--;
                }
            }
            else
            {
                CurrentNumberPiecesUpSize = NumberPiecesUpSize;
                if (CurrentSizeType == SizeType.Small)
                {
                    CurrentSizeType = SizeType.Big;
                    SizeSwitchedAfterLastDelay++;
                } 
                else
                {
                    CurrentSizeType = SizeType.Small;
                    SizeSwitchedAfterLastDelay++;
                }
                if (SizeSwitchedAfterLastDelay == 2)
                    SwitchSize = false;

                StartCoroutine(CompleteDelayBetweenSwitchSize());
            }
            StartCoroutine(TakingAttention(TimeAmplitudeInSecondsBetweenSwitchSize));
        }

        private IEnumerator CompleteDelayBetweenSwitchSize()
        {
            yield return new WaitForSeconds(DelayBetweenSwitchSize);
            SwitchSize = true;
            SizeSwitchedAfterLastDelay = 0;
        }
    }
}
