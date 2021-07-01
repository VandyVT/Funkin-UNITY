using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject[] countDowns;
    public MusicConduct conduct;
    public AudioSource audioSource;
    public AudioClip[] clips;

    private void Start()
    {
        conduct.started = false;
        audioSource.clip = clips[0];
        audioSource.Play();
        countDowns[0].LeanMoveLocalY(-242f, 0.4f).setEase(LeanTweenType.easeInSine).setDelay(0.2f).setOnComplete(() => {
            countDowns[0].LeanAlpha(0f, 0.5f).setDelay(0.35f);
            audioSource.clip = clips[1];
            audioSource.Play();
            countDowns[1].LeanMoveLocalY(0f, 0.4f).setEase(LeanTweenType.easeInSine).setDelay(0.2f).setOnComplete(() => {
                countDowns[1].LeanAlpha(0f, 0.5f).setDelay(0.35f);
                audioSource.clip = clips[2];
                audioSource.Play();
                countDowns[2].LeanMoveLocalY(214f, 0.4f).setEase(LeanTweenType.easeInSine).setDelay(0.2f).setOnComplete(() => {
                    countDowns[2].LeanAlpha(0f, 0.5f).setDelay(0.35f);
                    conduct.started = true;
                    audioSource.clip = clips[3];
                    audioSource.Play();
                });
            });
        });
    }
}