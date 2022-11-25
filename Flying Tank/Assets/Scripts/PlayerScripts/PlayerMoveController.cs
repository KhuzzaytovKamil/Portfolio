using UnityEngine;
using Audio;
using Finish.LoseSystem;

namespace Player
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField]
        GameObject AllLvlPlatforms;
        bool MoveForward = false;
        bool MoveBack = false;
        bool TouchNow = false;
        bool Jump = false;
        GameObject LastSavePoint;
        Vector3 JumpVector = new Vector3(0, 1, 0);
        Vector3 ForwardVector = new Vector3(1, 0, 0);
        Vector3 BackVector = new Vector3(-1, 0, 0);
        float CurrentRemainingJumpTime;
        [SerializeField]
        float FallPenaltyInSeconds;
        [SerializeField]
        float Speed;
        [Header("Scripts:")]
        [SerializeField]
        LoseManager LoseManager;
        [SerializeField]
        TimerController TimerController;
        [Header("Jump:")]
        [SerializeField]
        AudioSource JumpSound;
        [SerializeField]
        float JumpHeight;
        [SerializeField]
        float JumpTime;
        void Start() => CurrentRemainingJumpTime = JumpTime;
        void Update()
        {
            if (MoveForward)
                AllLvlPlatforms.transform.position -= Time.deltaTime * ForwardVector * Speed;
            if (MoveBack)
                AllLvlPlatforms.transform.position -= Time.deltaTime * BackVector * Speed;
            if (Jump)
            {
                if (CurrentRemainingJumpTime == 0 || CurrentRemainingJumpTime < 0)
                {
                    CurrentRemainingJumpTime = JumpTime;
                    Jump = false;
                }
                else
                {
                    CurrentRemainingJumpTime -= Time.deltaTime;
                    transform.position += Time.deltaTime * JumpVector * (JumpHeight / JumpTime);
                }
            }



            if (Input.GetKeyDown("space") && TouchNow)
                Jump = true;
            if (Input.GetKeyDown(KeyCode.S))
                MoveBack = true;
            if (Input.GetKeyUp(KeyCode.S))
                MoveBack = false;
            if (Input.GetKeyDown(KeyCode.W))
                MoveForward = true;
            if (Input.GetKeyUp(KeyCode.W))
                MoveForward = false;
        }


        public void KEY_DOWN_FORWARD() => MoveForward = true;
        
        public void KEY_UP_FORWARD() => MoveForward = false;

        public void KEY_DOWN_BACK() => MoveBack = true;


        public void KEY_UP_BACK() => MoveBack = false;


        void OnCollisionEnter(Collision other)
        {
            SoundController.PLAY_THIS_SOUND(JumpSound);
            TouchNow = true;
            if (other.gameObject.name == "StandardPlatform(Clone)")
                LastSavePoint = other.gameObject;
        }

        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.name != "Block" && other.gameObject.name != "FallController")
                TouchNow = false;
        }

        public void JUMP()
        {
            if(TouchNow)
            {
                Jump = true;
            }
        }
        public void SavePoint()
        {
            if (TimerController.TimeBeforeLose > FallPenaltyInSeconds)
            {
                TimerController.TimeBeforeLose = TimerController.TimeBeforeLose - FallPenaltyInSeconds;
                gameObject.transform.position = new Vector3(LastSavePoint.transform.position.x, LastSavePoint.transform.position.y + JumpHeight / 2, LastSavePoint.transform.position.z);
            }
            else
                LoseManager.LoseGame();
        }
    }
}