using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public int spawnQuantity;

    void Awake () {
        spawnEnemy(spawnQuantity);
    }
	
	
	void Update () {

	}


    void spawnEnemy(int enemyQuantity)
    {
        int i = 0;
        while (i < enemyQuantity) {
        float x = Random.RandomRange(-15f, 15f);
        float z = Random.RandomRange(-15f, 15f);
        float rotateY = Random.RandomRange(0f, 360f);
        Instantiate(enemy,new Vector3(x,0f,z), new Quaternion(0f,rotateY,0f,0f));
        i++;
         }
    }
}
