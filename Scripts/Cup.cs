using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private PauseMenu _winMenu = null;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _winMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
            _winMenu._winPanel.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }

    }
}
