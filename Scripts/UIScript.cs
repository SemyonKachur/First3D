using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private PlayerController _playerController = null;
    [SerializeField] private Text _ammoCount = null;
    [SerializeField] private Text _bombCount = null;
    [SerializeField] private Image _healhtBox = null;
    [SerializeField] private Text _healht = null;

    private void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void AmmoChnge()
    {
        _ammoCount.text = _playerController.ammo.ToString();
    }
    public void BombChnge()
    {
        _bombCount.text = _playerController.bombAmmo.ToString();
    }
        public void HealhtChange()
    {
        _healht.text = _playerController.health.ToString();
        _healhtBox.fillAmount = float.Parse(_healht.text) / 100;
    }
}
