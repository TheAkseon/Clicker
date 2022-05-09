using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private int _purchaseType;

    public void OnBuyButtonDown()
    {
        GameManager.instance.OnBuyButton(_purchaseType);
    }
}
