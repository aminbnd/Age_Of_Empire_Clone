using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
public class Player : MonoBehaviour
{
    public string username;
    public bool human;
    public HUD hud;
    public WorldObject SelectedObject { get; set; }
    public int startMoney, startMoneyLimit, startPower, startPowerLimit;
    public int StartWood, StartWoodLimit;
    public int StartFood, StartFoodLimit;
    private Dictionary<ResourceType, int> resources, resourceLimits;
    // Start is called before the first frame update
    private Dictionary<ResourceType, int> InitResourceList()
    {
        Dictionary<ResourceType, int> list = new Dictionary<ResourceType, int>();
        list.Add(ResourceType.Money, 0);
        list.Add(ResourceType.Power, 0);
        list.Add(ResourceType.Food, 0);
        list.Add(ResourceType.Wood, 0);
        return list;
    }
    public void AddResource(ResourceType type, int amount)
    {
        resources[type] += amount;
    }

    public void IncrementResourceLimit(ResourceType type, int amount)
    {
        resourceLimits[type] += amount;
    }
    private void AddStartResourceLimits()
    {
        IncrementResourceLimit(ResourceType.Money, startMoneyLimit);
        IncrementResourceLimit(ResourceType.Power, startPowerLimit);
    }

    private void AddStartResources()
    {
        AddResource(ResourceType.Money, startMoney);
        AddResource(ResourceType.Power, startPower);
    }
    void Awake()
    {
        resources = InitResourceList();
        resourceLimits = InitResourceList();
    }
    void Start()
    {
        hud = GetComponentInChildren<HUD>();
        AddStartResourceLimits();
        AddStartResources();
    }

    // Update is called once per frame
    void Update()
    {
        if (human)
        {
            hud.SetResourceValues(resources, resourceLimits);
        }
    }
}
