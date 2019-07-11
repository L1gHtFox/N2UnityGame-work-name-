using UnityEngine;
using UnityEngine.UI;

public class EnergyBank : MonoBehaviour
{
    //изначальные параметры энергии
    private float EnergyFull = 360;

    //параметры энергии орудия
    public static int energyFull; //макс. запас энергии
    public static int energyFullCurrent; //оставшаяся энергия
    public static int energyClip; //макс. запас энергии в обойме
    public static int energyClipCurrent; //оставшаяся энергия в обойме

    //параметры для перезарядки
    private int TakeEnergy_1;
    private int TakeEnergy_2;
    private int ResidueFE;

    //
    public bool reload = false;

    //текстовые объекты
    public Text mainBankText; //текст макс. кол - во патрон
    public Text currentEnergyText; //текст кол - во патрон в обойме

    private static EnergyBank Bank;


    private void Start()
    {
        //ссылки на текст, показывающий энергию
        mainBankText = GameObject.Find("Main_bank").GetComponent<Text>();
        currentEnergyText = GameObject.Find("Use_energy").GetComponent<Text>();        
    }

    private void Update()
    {
        ManagementMainBank();
    }

    public void ManagementMainBank()
    {
        if (!reload)
        {
            mainBankText.text = energyFullCurrent.ToString(); //вывод макс. кол - ва патрон на экран
            currentEnergyText.text = energyClipCurrent.ToString(); //вывод кол - ва патрон в обойме на экран
        }
    }

    public bool reloading(bool state = false)
    {
        reload = state;
        if (reload)
        {
            TakeEnergy_1 = energyClip - energyClipCurrent;
            TakeEnergy_2 = energyFullCurrent / energyClip;

            if (TakeEnergy_2 != 0)
            {
                energyClipCurrent += TakeEnergy_1;
                energyFullCurrent -= TakeEnergy_1;
            }
            else
            {
                ResidueFE = energyFull % energyClip;
                if (TakeEnergy_1 < ResidueFE)
                {
                    energyClipCurrent += TakeEnergy_1;
                    energyFullCurrent -= TakeEnergy_1;
                }
                else
                {
                    energyClipCurrent += ResidueFE;
                    energyFullCurrent = 0;
                }
            }            
        }
        return reload;
    }
}