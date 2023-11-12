using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{

    public float speedMultiplier = 2f;
    public float powerUpDuration = 5f;
    public GameObject SpeedUpFruit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivatePowerUp(collision.gameObject);

            Destroy(gameObject);


        }
    }

    void ActivatePowerUp(GameObject player)
    {
        Debug.Log("Speed PowerUp Activated!");

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.speed *= speedMultiplier;

            playerMovement.StartCoroutine(DeactivatePowerUp(playerMovement, powerUpDuration));
        }
    }

    IEnumerator DeactivatePowerUp(PlayerMovement playerMovement, float duration)
    {
        yield return new WaitForSeconds(duration);

        Debug.Log("Speed PowerUp Deactivated!");

        playerMovement.speed /= speedMultiplier;
    }
}
