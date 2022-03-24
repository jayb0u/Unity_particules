using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamethrower : MonoBehaviour
{

    public ParticleSystem psflame1;
    public ParticleSystem psflame2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //si j'appui sur click gauche, j'utilise le lance flame 1
        if (Input.GetButtonDown("Fire1"))
        {
            psflame1.Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            psflame1.Stop();
        }

        //si j'appui sur le click droit, j'utilise le lance flame 2

        if (Input.GetButtonDown("Fire2"))
        {
            psflame2.Play();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            psflame2.Stop();
        }
    }
}
