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
    Talk,
    MAX
}

public class SoundManager : Singleton_DontDestroy<SoundManager>
{
    const int MaxPlayCount = 3;
    
    AudioSource[] audioSources;
    AudioClip[] sfxClips;
    List<int> sfxPlayCounts;

    public void PlaySFX(SFX sfx)
    {
        if (sfxPlayCounts[(int)sfx] > MaxPlayCount) return;
        
        var source = audioSources[(int)Audio.SFX];
        
        source.PlayOneShot(sfxClips[(int)sfx]);
        sfxPlayCounts[(int)sfx]++;
        //TODO : 현재 재생중인 오디오 클립들의 끝나는 시간을 확인해 sfxPlayCount를 1씩 감소시키는 로직
    }
}
