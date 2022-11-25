using UnityEngine;
using System;
using Audio;

namespace Finish.LoseSystem
{
    public class LoseManager : MonoBehaviour
    {
        public static event Action Lose;
        [SerializeField]
        GameObject LoseWindow;
        [SerializeField]
        AudioSource LoseAudio;
        void Start() => Lose += CreateLoseWindow;

        void OnDisable() => Lose -= CreateLoseWindow;

        void OnDestroy() => Lose -= CreateLoseWindow;

        void OnEnable() => Lose += CreateLoseWindow;

        public void LoseGame() => Lose.Invoke();

        void CreateLoseWindow()
        {
            LoseWindow.SetActive(true);
            SoundController.PLAY_THIS_SOUND(LoseAudio);
        }
    }
}