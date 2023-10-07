using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audio
{
    Total = -1,
    SFX,
    BGM
}

public enum SFX
{
    StartButton,
    Talk,
    Max
}

public enum BGM
{
    Title,
    Game,
    Max
}

public class SoundManager : Singleton_DontDestroy<SoundManager>
{
    const int MaxPlayCount = 3;

    AudioSource[] audioSources;
    [SerializeField]
    AudioClip[] bgmClips;
    [SerializeField]
    AudioClip[] sfxClips;
    List<int> sfxPlayCounts;
    List<float> lengthsOfSfx;

    bool checkIsSFXIsPlaying;

    protected override void OnAwake()
    {
        audioSources = GetComponents<AudioSource>();
        sfxPlayCounts = new List<int>(new int[(int)SFX.Max]);
        lengthsOfSfx = new List<float>(new float[(int)SFX.Max]);

        var sfxSource = audioSources[(int)Audio.SFX];
        sfxSource.playOnAwake = false;
        sfxSource.loop = false;

        var bgmSource = audioSources[(int)Audio.BGM];
        bgmSource.playOnAwake = false;
        bgmSource.loop = true;

        StartCoroutine(Coroutine_Update());
    }

    IEnumerator Coroutine_Update()
    {
        float timer = 0f;
        
        while (true)
        {
            if (checkIsSFXIsPlaying)
            {
                int playFinishedSfxCount = 0;
                timer += Time.deltaTime;

                for (int i = 0; i < sfxPlayCounts.Count; i++)
                {
                    if (lengthsOfSfx[i] / sfxPlayCounts[i] <= timer)
                    {
                        lengthsOfSfx[i] -= timer;
                        sfxPlayCounts[i]--;
                    }

                    if (sfxPlayCounts[i] <= 0)
                    {
                        lengthsOfSfx[i] = 0f;
                        playFinishedSfxCount++;

                        if (playFinishedSfxCount >= sfxPlayCounts.Count)
                        {
                            timer = 0f;
                            checkIsSFXIsPlaying = false;
                            break;
                        }
                    }
                }
            }
            
            yield return null;
        }
    }

    public void PlayBGM(BGM bgm)
    {
        var source = audioSources[(int)Audio.BGM];

        source.clip = bgmClips[(int)bgm];
        source.Play();
    }

    public void StopBGM()
    {
        var source = audioSources[(int)Audio.BGM];
        
        source.Stop();
    }

    public void PlaySFX(SFX sfx)
    {
        if (sfxPlayCounts[(int)sfx] > MaxPlayCount) return;

        var source = audioSources[(int)Audio.SFX];
        var clip = sfxClips[(int)sfx];

        source.PlayOneShot(clip);
        sfxPlayCounts[(int)sfx]++;
        lengthsOfSfx[(int)sfx] += clip.length;

        checkIsSFXIsPlaying = true;
    }

    public void ChangeTotalVolume(float value)
    {
        AudioListener.volume = value;
    }
    
    public void ChangeVolume(Audio audio, float value)
    {
        audioSources[(int)audio].volume = value;
    }
}
