using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandom : MonoBehaviour
{
    public Animator animator2;
    [SerializeField] private int RandomV;
    [SerializeField] private int frameInterval = 100;
    [SerializeField] private int Range = 10;
    private int frameCounter = 0;

    void Update()
    {
        frameCounter++;
        animator2.SetInteger("frameCounter", frameCounter);
        if (frameCounter >= frameInterval) { 
            RandomV = Random.Range(0, Range);
            animator2.SetInteger("RandomV", RandomV);
            frameCounter = 0;
        }


    }
}

