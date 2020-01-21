using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            return;
        }
        instance = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static List<Item> items = new List<Item>();
    public int space = 20;

    //public TextAsset inventoryText;
    //public int startLine;
    //public int endLine;
    //public TextBoxManager theTextBox;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            //onItemChangedCallback.Invoke();

            if (items.Count() >= space)
            {
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public bool SearchForCrystals()
    {
        int count = (from i in items
                     where i.name == "Crystal Fragment"
                     select i).Count();

        if (count == 3)
        {
            return true;
        }

        return false;
    }

    public bool SearchForFishingRod()
    {
        Item rod = (from i in items
                    where i.name == "Fishing Rod"
                    select i).FirstOrDefault();

        if (rod != null)
        {
            return true;
        }

        return false;

    }

    public void GameOver()
    {
        items = null;
        items = new List<Item>();
        onItemChangedCallback.Invoke();
    }
}
