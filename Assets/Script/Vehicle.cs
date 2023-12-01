using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
   [SerializeField] private float speed;
    public bool isLog;
   private void Update(){
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
   }

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
