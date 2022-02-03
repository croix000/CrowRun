using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool enteredOnce;
    private void OnCollisionEnter(Collision collision)
    {
        if (!enteredOnce)
        {
            enteredOnce = true;
            GameManager.Instance.HandleCoin();
            GameObject.Destroy(this.gameObject);

        }
    }
}
