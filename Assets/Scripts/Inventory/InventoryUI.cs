using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public Transform itemsParent;
    public GameObject inventoryUI;
    //public Player player;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        //player = Player.instance;
        //player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetActive();
            //inventoryUI.SetActive(!inventoryUI.activeSelf);

            //if (inventoryUI.activeSelf == true)
            //{
            //    player.canMove = false;
            //}
            //else
            //{
            //    player.canMove = true;
            //}
        }

    }

    public void SetActive()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        //Debug.Log("UPDATING UI");
    }
}
