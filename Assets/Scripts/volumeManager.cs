using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class volumeManager : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider sliderMaster;
    public Slider sliderAmbiance;
    public Slider sliderEffects;
    public Slider sliderEnnemis;

    public AudioSource sourceBoss;
    public AudioClip clipBleedToDeath;

    public AudioMixerSnapshot snapDialog;
    public AudioMixerSnapshot snapMain;

    bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // Appliquer les valeurs de départ aux sliders
        SliderSetup(sliderMaster);
        SliderSetup(sliderAmbiance);
        SliderSetup(sliderEffects);
        SliderSetup(sliderEnnemis);


        // Event Listener
        sliderMaster.onValueChanged.AddListener(SliderMaster_valueChanged);
        sliderAmbiance.onValueChanged.AddListener(SliderAmbiance_valueChanged);
        sliderEffects.onValueChanged.AddListener(SliderEffects_valueChanged);
        sliderEnnemis.onValueChanged.AddListener(SliderEnnemis_valueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        // si on appuye sur E et que le boss ne parle pas déjà
        if (Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            //on début son dialog
            StartCoroutine(PlayDialog());

        }
    }

    

    IEnumerator PlayDialog()
    {
        isTalking = true;

        // transition vers snap de dialog
        snapDialog.TransitionTo(0.5f);

        // début du dialog
        sourceBoss.PlayOneShot(clipBleedToDeath);

        // attendre la fin du dialog
        yield return new WaitForSeconds(clipBleedToDeath.length + 0.5f);

        snapMain.TransitionTo(0.5f);

        isTalking = false;
    }

    void SliderSetup(Slider slider)
    {
        // Appliquer le min et max
        slider.minValue = 0.001f;
        slider.maxValue = 1.6f;

        // Appliquer la valeur par défaut
        slider.value = 1f;
    }

    void SliderMaster_valueChanged(float value)
    {
        // Modifier le volume du channel master
        mixer.SetFloat("volMaster", Mathf.Log(value) * 20);
    }

    void SliderAmbiance_valueChanged(float value)
    {
        // Modifier le volume du channel master
        mixer.SetFloat("volAmbiance", Mathf.Log(value) * 20);
    }

    void SliderEffects_valueChanged(float value)
    {
        // Modifier le volume du channel master
        mixer.SetFloat("volEffet", Mathf.Log(value) * 20);
    }

    void SliderEnnemis_valueChanged(float value)
    {
        // Modifier le volume du channel master
        mixer.SetFloat("volEnnemis", Mathf.Log(value) * 20);
    }
}
