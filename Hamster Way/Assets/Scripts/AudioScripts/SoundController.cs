using UnityEngine;

namespace Audio
{
public class SoundController : MonoBehaviour
{
    public static void PLAY_THIS_SOUND(AudioSource audio)
    {
        if(PlayerPrefs.GetInt("SOUND") == 1)
            audio.Play();
    }
}
}
