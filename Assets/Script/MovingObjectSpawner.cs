using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{
[SerializeField] private GameObject spawnObject;
[SerializeField] private Transform spawnPos;
[SerializeField] private float minSeparationTime;
[SerializeField] private float maxSeparationTime;
[SerializeField] private bool isRigtSide;
private void Start(){
    StartCoroutine(SpawnVehicle());
}

private IEnumerator SpawnVehicle(){
    while(true){
    yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
    GameObject go =Instantiate(spawnObject, spawnPos.position, Quaternion.identity);
    go.transform.rotation = (Quaternion.Euler(0, spawnPos.rotation.y, 0)); 
    if(!isRigtSide)
{
    go.transform.Rotate(new Vector3(0, 180, 0));
}}
    }

}
