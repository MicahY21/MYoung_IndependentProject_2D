using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider CoryGorrillaPlayer)
    {
        Destroy(CoryGorrillaPlayer.gameObject);
        Destroy(gameObject);



    }

    
}
