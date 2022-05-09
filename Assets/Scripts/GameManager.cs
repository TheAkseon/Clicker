using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyText;
    [SerializeField] private GameObject _firstShopButton, _secondShopButton, _thirdShopButton;

    private int _moneyCount = 1;

    public static GameManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _money = PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") : 0;
        _moneyCount = PlayerPrefs.HasKey("MoneyCount") ? PlayerPrefs.GetInt("MoneyCount") : 1;

        if (_moneyCount == 2)
        {
            Destroy(_firstShopButton);
        }
        if (_moneyCount == 3)
        {
            Destroy(_firstShopButton);
            Destroy(_secondShopButton);
        }
        if (_moneyCount == 4)
        {
            Destroy(_firstShopButton);
            Destroy(_secondShopButton);
            Destroy(_thirdShopButton);
        }
    }

    private void Update()
    {
        _moneyText.text = _money + "Ð";
    }

    public void UpdateMoney()
    {
        _money += _moneyCount;
        PlayerPrefs.SetInt("Money", _money);
    }

    public void OnBuyButton(int purchaseType)
    {
        switch (purchaseType)
        {
            case 1:
                if(_money >= 100)
                {
                    _moneyCount = 1;
                    _money -= 100;
                    _moneyCount *= 2;
                    Destroy(_firstShopButton);
                }
                else
                {
                    return;
                }
                break;
            case 2:
                if(_money >= 300)
                {
                    _moneyCount = 1;
                    _money -= 300;
                    _moneyCount *= 3;
                    Destroy(_secondShopButton);
                }
                else
                {
                    return;
                }
                break;
            case 3:
                if(_money >= 600)
                {
                    _moneyCount = 1;
                    _money -= 600;
                    _moneyCount *= 4;
                    Destroy(_thirdShopButton);
                }
                else
                {
                    return;
                }
                break;
        }
        PlayerPrefs.SetInt("MoneyCount", _moneyCount);
        PlayerPrefs.SetInt("Money", _money);
    }
}
