using UnityEngine;

[CreateAssetMenu(menuName = "SoundManager/AddSounds",fileName ="SoundCollection")]
public class SoundCollection : ScriptableObject
{
    public AudioClip[] rating1;
    public AudioClip[] rating2;
    public AudioClip[] rating3;
    public AudioClip[] rating4;
    public AudioClip[] rating5;
    public AudioClip[] askingForPaneerTikka,askingForSamosa,askingForTea,askingForPakori;



}
