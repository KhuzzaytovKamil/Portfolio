using UnityEngine;
using System.Collections;

namespace Platforms
{
    public class MajorMatchingPlatformController : MonoBehaviour
    {
        [SerializeField]
        float TimeBetweenSkipType;
        [SerializeField]
        float DividingFactorForTheSecretStatus;
        [SerializeField]
        GameObject MajorMatchingPlatforms;
        MajorMatchingPlatformsType PlatformsType = MajorMatchingPlatformsType.Active;
        enum MajorMatchingPlatformsType { Active, Secret }
        void Start() => StartCoroutine(ChangePlatformsType(TimeBetweenSkipType));

        IEnumerator ChangePlatformsType(float TimeInSeconds)
        {
            yield return new WaitForSeconds(TimeInSeconds);
            if (PlatformsType == MajorMatchingPlatformsType.Active)
            {
                PlatformsType = MajorMatchingPlatformsType.Secret;
                MajorMatchingPlatforms.SetActive(false);
            }
            else
            {
                PlatformsType = MajorMatchingPlatformsType.Active;
                MajorMatchingPlatforms.SetActive(true);
            }
            if (PlatformsType == MajorMatchingPlatformsType.Secret)
                StartCoroutine(ChangePlatformsType(TimeBetweenSkipType / DividingFactorForTheSecretStatus));
            else
                StartCoroutine(ChangePlatformsType(TimeBetweenSkipType));
        }
    }
}