using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potion : Item
{
    public Player player;
    public Effect effect;
    public float healthModifier;
    public float speedModifier;
    public float effectTime;

    public override void Use()
    {
        player = FindObjectOfType<Player>();

        switch (effect)
        {
            case Effect.Health:
                player.AddHealth(healthModifier);
                break;
            case Effect.Poison:
                player.TakeDamage(healthModifier);
                break;
            case Effect.Shield:
                break;
            case Effect.Speed:
                player.SpeedBoost(speedModifier, effectTime);
                break;
            default:
                break;
        }

        base.Use();

        RemoveFromInventory();
    }
}

public enum Effect { Health, Poison, Shield, Speed };
