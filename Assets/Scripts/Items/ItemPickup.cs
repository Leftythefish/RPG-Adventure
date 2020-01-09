using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickup : Interactable
{
    public Item item;
    bool hasInteracted = false;
    public bool wasPickedUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //wasPickedUp = false;

        if (collision.CompareTag("Player") && !hasInteracted)
        {
            hasInteracted = true;

            Interact();
            //Obstacle o = collision.GetComponent<Obstacle>();
            //obstacles.Remove(o);
            //if (obstacles.Count == 0)
            //{
            //    parentRenderer.sortingOrder = 200;
            //}
            //else
            //{
            //    obstacles.Sort();
            //    parentRenderer.sortingOrder = obstacles[0].MySpriteRenderer.sortingOrder - 1;
            //}
        }
    }
    public override void Interact()
    {
        //base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);

        wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Starting_area":
                    switch (item.name)
                    {
                        case "Key":
                            Instantiation.keyPicked = true;
                            break;
                        case "Health Potion":
                            Instantiation.healthPicked = true;
                            break;
                        case "Speed Potion":
                            Instantiation.speedPicked = true;
                            break;
                        case "Poison Potion":
                            Instantiation.poisonPicked = true;
                            break;
                        default:
                            break;
                    }
                    break;

                case "Home":
                    switch (item.name)
                    {
                        case "Health Potion":
                            HomeInstantiation.healthPicked = true;
                            break;
                        case "Poison Potion":
                            HomeInstantiation.poisonPicked = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "TheTown_01":
                    switch (item.name)
                    {
                        case "Crystal Fragment":
                            TownInstantiation.crystalPicked = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Cave":
                    switch (item.name)
                    {
                        case "Crystal Fragment":
                            CaveInstantiation.crystalPicked = true;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Theforest_02":
                    switch (item.name)
                    {
                        case "Crystal Fragment":
                            Forest2Instantiation.crystalPicked = true;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            //item.used = true;
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
