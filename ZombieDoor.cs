using UnityEngine;

public class ZombieDoor : MonoBehaviour
{
    // The spawns for the left and right side of the building.
    public GameObject rightSpawn;
    public GameObject leftSpawn;
    public GameObject zombiePrefab;

    // A reference to the newly created zombie.
    GameObject zombie;

    // Track whether we spawned or not to control the zombies.
    bool hasSpawned = false;

    /*
    Function to spawn a zombie in at a set spawn.
    GameObject spawnObject -> The spawn we want to instantiate the zombie at.
    */
    void SpawnZombie(GameObject spawnObject){
        // Increase our spawn's Y-position by half the height of the zombie prefab so it is above ground.
        float height = zombiePrefab.transform.localScale.y / 2;
        // Create a new Vector3 from the spawn's position and the new height.
        Vector3 objPos = spawnObject.transform.position;
        Vector3 spawnPos = new Vector3(objPos.x, objPos.y + height, objPos.z);
        // Create our zombie at the new position and assign it to our zombie variable.
        zombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
    
    /*
    Function to check the direction a player is facing and call the zombie spawn function
    depending on which direction they are facing.
    float angle -> the euler angle the player is facing.
    */
    void CheckPlayerDirection(float angle){
        // If the player angle is greater than 0 (forward) and less than 180 (behind)
        // then they must be facing to the right of their character.
        bool rightAngle = angle >= 0 && angle <= 180;
        
        // We only check for the right angle, because if this is false 
        // they are facing left.
        if (rightAngle){
            SpawnZombie(leftSpawn);
        }
        else{
            SpawnZombie(rightSpawn);
        }
    }

    /*
    Event which triggers when a collider passes through the ZombieDoor trigger.
    */
    private void OnTriggerEnter(Collider other){
        // Check if we have not spawned and that the trigger 
        // was set off by a player so that other actors don't spawn zombies.
        if (!hasSpawned && other.CompareTag("Player")){
            // Update our boolean for tracking zombie spawning.
            hasSpawned = true;
            // Using euler angles to clamp our rotation between 0 and 365.
            float playerRotation = other.transform.localRotation.eulerAngles.y; 
            CheckPlayerDirection(playerRotation);
        }

    }

    void Update() {
        // If we hit the R key, reset our spawns.
        if (Input.GetKey(KeyCode.R)) ResetSpawn();
    }
    public void ResetSpawn(){
        hasSpawned = false;
        // If there is a zombie, destroy it.
        if (zombie != null) Destroy(zombie);
    }
}
