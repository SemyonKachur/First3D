using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZoneTrigger : MonoBehaviour
{
    private AudioReverbZone _reverb = null;
    private void Awake()
    {
        _reverb = GetComponent<AudioReverbZone>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _reverb.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _reverb.enabled = false;
        }
    }
}
