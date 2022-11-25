using UnityEngine;
using System.Collections;

namespace Platforms
{
    public class MovePlatformController : MonoBehaviour
    {
        [SerializeField]
        Vector3 TheFirstMoveVector;
        [SerializeField]
        Vector3 TheSecondMoveVector;
        Vector3 CurrentMoveVector;
        [SerializeField]
        float MoveSpeed;
        float TimeBetweenSkipType;
        MoveVector PlatformsType = MoveVector.TheFirstMoveVector;
        enum MoveVector { TheFirstMoveVector, TheSecondMoveVector }
        void Start()
        {
            CurrentMoveVector = TheFirstMoveVector;
            TimeBetweenSkipType = 10.5f / MoveSpeed;
            StartCoroutine(ChangePlatformsType(TimeBetweenSkipType));
        }

        void Update() => transform.position += Time.deltaTime * CurrentMoveVector * MoveSpeed;
     
        void OnCollisionEnter(Collision CollisionObject) => CollisionObject.gameObject.transform.SetParent(gameObject.transform);
        
        void OnCollisionExit(Collision CollisionObject) => CollisionObject.gameObject.transform.SetParent(null);

        IEnumerator ChangePlatformsType(float TimeBetweenSkipType)
        {
            yield return new WaitForSeconds(TimeBetweenSkipType);
            if (PlatformsType == MoveVector.TheFirstMoveVector)
            {
                PlatformsType = MoveVector.TheSecondMoveVector;
                CurrentMoveVector = TheSecondMoveVector;
            }
            else
            {
                PlatformsType = MoveVector.TheFirstMoveVector;
                CurrentMoveVector = TheFirstMoveVector;
            }
            StartCoroutine(ChangePlatformsType(TimeBetweenSkipType));
        }
    }
}
