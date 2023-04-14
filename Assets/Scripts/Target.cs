using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public int pointValue;
    private float minSpeed = 15;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
    //按下滑鼠
    //慣用:OnMouseDown / OnMouseUp
    private void OnMouseDown(){
        if (gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
    //離開邊界
    private void OnTriggerEnter(Collider other){
        //sensor:isTrigger
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")){
            gameManager.UpdateLives(-1);
        }
    }
    public void DestroyTarget(){
        if (gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

}
