using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public float radius = 3f;
    //Item item;

    public virtual void Interact()
    {
        //this method is meant to be overwritten
        //Debug.Log("Interacting with " + item.name);

    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        item = collision.GetComponent<Item>();
    //        Interact();

    //        //Obstacle o = collision.GetComponent<Obstacle>();
    //        //obstacles.Remove(o);
    //        //if (obstacles.Count == 0)
    //        //{
    //        //    parentRenderer.sortingOrder = 200;
    //        //}
    //        //else
    //        //{
    //        //    obstacles.Sort();
    //        //    parentRenderer.sortingOrder = obstacles[0].MySpriteRenderer.sortingOrder - 1;
    //        //}
    //    }
    //}
    //    void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}
}
