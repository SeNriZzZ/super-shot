using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammotext;

    [SerializeField] private Text _reloadingText;

    [SerializeField] private Text _pressEtext;

    [SerializeField] private GameObject _coinImage;

    public void UpdateAmmo(int count)
    {
        _ammotext.text = "Ammo: " + count;
    }

    void Start()
    {
        _reloadingText.enabled = false;
        _pressEtext.enabled = false;
    }

    public void EnableReload()
    {
        _reloadingText.enabled = true;
    }

    public void DisableReload()
    {
        _reloadingText.enabled = false;
    }

    public void HasCoin()
    {
        _coinImage.SetActive(true);
    }

    public void HasNoCoin()
    {
        _coinImage.SetActive(false);
    }
}