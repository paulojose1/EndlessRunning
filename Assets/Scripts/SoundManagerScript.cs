
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerHitSound, FreddySound, michaelSound, jumpSound, playerDeathSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {

        playerHitSound = Resources.Load<AudioClip>("StabSound");
        FreddySound = Resources.Load<AudioClip>("Decapitation");
        michaelSound = Resources.Load<AudioClip>("Michael");
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        playerDeathSound = Resources.Load<AudioClip>("death");

        audioSrc = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {

        switch (clip)
        {
            case "StabSound":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "Decapitation":
                audioSrc.PlayOneShot(FreddySound);
                break;
            case "Michael":
                audioSrc.PlayOneShot(michaelSound);
                break;
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "death":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
