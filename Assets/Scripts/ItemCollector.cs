using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    
    private int kiwis = 0;
    private int MelonPowerUps = 0;

    [SerializeField] private Text kiwisText;
    [SerializeField] private Text MelonPowerUpsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "Kiwi's: " + kiwis;
        }

        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            MelonPowerUps++;
            MelonPowerUpsText.text = "Melon PowerUps:" + MelonPowerUps;
        }
    }
}
