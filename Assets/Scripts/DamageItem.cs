using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        GameManager.Instance.HandleGameOver();
        GameObject.Destroy(gameObject);
    }
}
