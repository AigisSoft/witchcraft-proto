using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInputParticle : MonoBehaviour
{
    public GameObject attackCircle;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        this.gameObject.SetActive(true);
        iTween.ScaleTo(this.gameObject, iTween.Hash(
                       "x", 10f,
                       "y", 10f,
                       "z", 10f,
                       "time", 0.2f
                      ));
    }

    public void FinishAnimation()
    {
        this.gameObject.SetActive(false);
    }
}
