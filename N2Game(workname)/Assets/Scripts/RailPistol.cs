using UnityEngine;

public class RailPistol : MonoBehaviour
{
    //ссылка на скрипт
    private EnergyBank Bank;

    //параметры энергии орудия
    public static int energyFull = 35; //макс. запас энергии
    public static int energyFullCurrent = energyFull; //оставшаяся энергия
    public static int energyClip = 7; //макс. запас энергии в обойме
    public static int energyClipCurrent = energyClip; //оставшаяся энергия в обойме

    private void Start()
    {
        //ссылки на скрипты
        Bank = GameObject.Find("EnergyBank").GetComponent<EnergyBank>();
    }

    private void Update()
    {
        ManagementPistol();
    }

    private void ManagementPistol()
    {
        InformOfEnergy();
    }

    private void InformOfEnergy()
    {
        EnergyBank.energyFull = energyFull;
        EnergyBank.energyFullCurrent = energyFullCurrent;
        EnergyBank.energyClip = energyClip;
        EnergyBank.energyClipCurrent = energyClipCurrent;
    }
}
