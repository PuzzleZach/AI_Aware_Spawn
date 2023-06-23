# AI_Aware_Spawn
A short exercise in spawning actors opposite of the player character.

## To use

1. Have a game object in Unity with a box collider that has a trigger enabled. This will ideally be the door.
2. Have any first person controller with the "Player" tag.
3. 2 game objects inside a building will be the spawns for alternate sides.
4. A zombie prefab which will be spawned.
5. Hook up the spawns and zombie to the ZombieDoor.cs script.

Essentially this will spawn a zombie (or any actor) in the opposite direction that the player is facing as they enter a room or building.
