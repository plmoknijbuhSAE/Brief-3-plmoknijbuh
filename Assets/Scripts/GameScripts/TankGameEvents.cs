using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Static Class to hold all of events and event types within our project.
/// </summary>
public static class TankGameEvents 
{
    public delegate void TransformDelegate(Transform TankDestroyed);
    public delegate void TransformFloatDelegate(Transform ObjectDamaged, float amountOfDamage);

    public delegate void IntDelegate(int NumberToSpawn);
    public delegate void GameObjectListDelegate(List<GameObject> allTanksSpawnedIn);

    public delegate void VoidDelegate();

    public delegate void PlayerNumberDelegate(PlayerNumber playerNumber);
    public delegate void PlayerNumberIntDelegate(PlayerNumber playerNumber, int Amount);

    /// <summary>
    /// Called when a tank has been destroyed
    /// </summary>
    public static TransformDelegate OnObjectDestroyedEvent;

    /// <summary>
    /// Called whenever damage is applied to a tank
    /// </summary>
    public static TransformFloatDelegate OnObjectTakeDamageEvent;

    /// <summary>
    /// Called when the tanks should be spawned in
    /// </summary>
    public static IntDelegate SpawnTanksEvent;

    /// <summary>
    /// Called after the tanks have been spawned in
    /// </summary>
    public static GameObjectListDelegate OnTanksSpawnedEvent;

    /// <summary>
    /// Called when the game should be reset
    /// </summary>
    public static VoidDelegate OnResetGameEvent;

    /// <summary>
    /// Called before our game starts might be good for set up stuff
    /// </summary>
    public static VoidDelegate OnPreGameEvent;

    /// <summary>
    /// Called when the game begins
    /// </summary>
    public static VoidDelegate OnGameStartedEvent;

    /// <summary>
    /// Called when the round is over
    /// </summary>
    public static PlayerNumberDelegate OnRoundEnededEvent;

    /// <summary>
    /// Called when a player has scored a point
    /// </summary>
    public static PlayerNumberIntDelegate OnScoreUpdatedEvent;
   
    /// <summary>
    /// Called when the round is reset
    /// </summary>
    public static VoidDelegate OnRoundResetEvent;
}
