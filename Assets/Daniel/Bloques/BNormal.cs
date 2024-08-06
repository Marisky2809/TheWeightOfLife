using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNormal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Simple"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Chorus") || collision.CompareTag("GChorus1") || collision.CompareTag("Chorus2") || collision.CompareTag("Chorus3") || collision.CompareTag("GChorus2"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Distortion") || collision.CompareTag("GDistortion"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Overdrive") || collision.CompareTag("GOverdrive"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Reverb") || collision.CompareTag("GReverb") || collision.CompareTag("Reverb2") || collision.CompareTag("Reverb3"))
        {
            gameObject.SetActive(false);
        }
    }
}
