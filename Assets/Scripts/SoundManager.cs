using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio sources")]
    [SerializeField] private AudioSource musicIntroSource;
    [SerializeField] private AudioSource musicLoopSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music")]
    [SerializeField] private AudioClip themeFull;
    [SerializeField] private AudioClip themeLoop;
    [SerializeField] private bool playMusicOnStart = true;
    [SerializeField] private bool persistAcrossScenes = true;
    [SerializeField] private float delayAfterIntroSeconds = 0f;
    [SerializeField] private float scheduledMusicLeadSeconds = 0.05f;

    [Header("SFX clips — assign here, call the matching method from gameplay")]
    [SerializeField] private AudioClip rubberFrogCoiling;
    [SerializeField] private AudioClip rubberFrogSpringing;
    [SerializeField] private AudioClip rubberFrogLanding;
    [SerializeField] private AudioClip spellbookFlap;
    [SerializeField] private AudioClip spellbookLanding;
    [SerializeField] private AudioClip inventoryAddGulp;
    [SerializeField] private AudioClip inventoryRemoveHairball;
    [SerializeField] private AudioClip legEquipSquish;
    [SerializeField] private AudioClip legUnequipDetach;
    [SerializeField] private AudioClip pickupKey;
    [SerializeField] private AudioClip chestUnlock;
    [SerializeField] private AudioClip chestOpen;
    [SerializeField] private AudioClip pickupGem;
    [SerializeField] private AudioClip pickupBone;
    [SerializeField] private AudioClip pickupFlower;
    [SerializeField] private AudioClip catMeow1;
    [SerializeField] private AudioClip catMeow2;
    [SerializeField] private AudioClip catMeow3;
    [SerializeField] private AudioClip catMeow4;
    [SerializeField] private AudioClip catGup;
    [SerializeField] private AudioClip finalSpell;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        if (persistAcrossScenes)
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (playMusicOnStart)
            PlayMainTheme();
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    // full track once, then loop
    public void PlayMainTheme()
    {
        if (musicIntroSource == null || musicLoopSource == null)
            return;

        musicLoopSource.Stop();
        musicIntroSource.Stop();

        if (themeFull == null || themeLoop == null)
            return;

        themeFull.LoadAudioData();
        themeLoop.LoadAudioData();

        musicIntroSource.clip = themeFull;
        musicIntroSource.loop = false;
        musicLoopSource.clip = themeLoop;
        musicLoopSource.loop = true;

        double lead = Mathf.Max(0f, scheduledMusicLeadSeconds);
        double tIntro = AudioSettings.dspTime + lead;
        double introDuration = GetClipDurationSeconds(themeFull);
        double tLoop = tIntro + introDuration + delayAfterIntroSeconds;

        musicIntroSource.PlayScheduled(tIntro);
        musicLoopSource.PlayScheduled(tLoop);
    }

    public void StopMainTheme()
    {
        if (musicIntroSource != null)
            musicIntroSource.Stop();
        if (musicLoopSource != null)
            musicLoopSource.Stop();
    }

    // clip length in seconds for scheduling — samples/Hz
    private static double GetClipDurationSeconds(AudioClip clip)
    {
        if (clip == null || clip.frequency <= 0)
            return 0d;
        return (double)clip.samples / clip.frequency;
    }


    public void PlayOneShotClip(AudioClip clip, float volumeScale = 1f)
    {
        if (clip == null || sfxSource == null)
            return;
        sfxSource.PlayOneShot(clip, Mathf.Clamp01(volumeScale));
    }

    public void PlayRubberFrogCoiling() => PlayOneShotClip(rubberFrogCoiling);
    public void PlayRubberFrogSpringing() => PlayOneShotClip(rubberFrogSpringing);
    public void PlayRubberFrogLanding() => PlayOneShotClip(rubberFrogLanding);
    public void PlaySpellbookFlap() => PlayOneShotClip(spellbookFlap);
    public void PlaySpellbookLanding() => PlayOneShotClip(spellbookLanding);
    public void PlayInventoryAdd() => PlayOneShotClip(inventoryAddGulp);
    public void PlayInventoryRemove() => PlayOneShotClip(inventoryRemoveHairball);
    public void PlayLegEquip() => PlayOneShotClip(legEquipSquish);
    public void PlayLegUnequip() => PlayOneShotClip(legUnequipDetach);
    public void PlayPickupKey() => PlayOneShotClip(pickupKey);
    public void PlayChestUnlock() => PlayOneShotClip(chestUnlock);
    public void PlayChestOpen() => PlayOneShotClip(chestOpen);
    public void PlayPickupGem() => PlayOneShotClip(pickupGem);
    public void PlayPickupBone() => PlayOneShotClip(pickupBone);
    public void PlayPickupFlower() => PlayOneShotClip(pickupFlower);
    public void PlayCatGup() => PlayOneShotClip(catGup);
    public void PlayCatMeow() => PlayOneShotClip(catMeow1);
    public void PlayFinalSpell() => PlayOneShotClip(finalSpell);
}
