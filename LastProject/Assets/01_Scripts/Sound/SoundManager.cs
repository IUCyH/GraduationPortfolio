using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Audio
{
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
                Debug.Log("Count : " + sfxPlayCounts.Count);
                for (int i = 0; i < sfxPlayCounts.Count; i++)
                {
                    if (lengthsOfSfx[i] / (float)sfxPlayCounts[i] <= timer)
                    {
                        lengthsOfSfx[i] -= timer;
                        sfxPlayCounts[i]--;
                        Debug.Log("Curr : " + sfxPlayCounts[i]);
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

    public void PlaySFX(SFX sfx)
    {
        Debug.Log(sfxPlayCounts[(int)sfx]);
        if (sfxPlayCounts[(int)sfx] > MaxPlayCount) return;

        var source = audioSources[(int)Audio.SFX];
        var clip = sfxClips[(int)sfx];

        source.PlayOneShot(clip);
        sfxPlayCounts[(int)sfx]++;
        lengthsOfSfx[(int)sfx] += clip.length;

        checkIsSFXIsPlaying = true;
        Debug.Log(sfxPlayCounts[(int)sfx]);
        //TODO : 현재 재생중인 오디오 클립들의 끝나는 시간을 확인해 sfxPlayCount를 1씩 감소시키는 로직
    }
}
