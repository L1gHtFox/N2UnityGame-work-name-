using UnityEngine;
using UnityEngine.UI;

public class EnergyBank : MonoBehaviour
{
    //изначальные параметры энергии
    private int EnergyFull = 360;
    private float EnergyMagazin;
    private float EnergyOneShot;

    //сокращенные параметры энергии
    private float rEnergyFull;
    private float rEnergyMagazin;
    private int sEnergyOneShot = 1;


    //сокращенные параметры энергии для оружия A
    private float aEnergyFull;
    private float aEnergyMagazin;

    //сокращенные параметры энергии для доп. оружия
    private float dopEnergyFull;
    private float dopEnergyMagazin;


    //высчитанные переменные для вывода    
    public int energyFull;
    public int energyMagazin;
    public int currentEnergy;

    //параметры для перезарядки
    private int TakeEnergy_1;
    private int TakeEnergy_2;
    private int ResidueFE;

    //параметры активации преобразования энергии
    private int reloadWeapon;
    private bool Reload = false;
    private bool Shot = false;

    //текстовые объекты
    public Text mainBankText; //текст макс. кол - во патрон
    public Text currentEnergyText; //текст кол - во патрон в обойме


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
        if (!Reload)
        {
            mainBankText.text = energyFull.ToString(); //вывод макс. кол - ва патрон на экран
            currentEnergyText.text = currentEnergy.ToString(); //вывод кол - ва патрон в обойме на экран
        }

        Reload = false;
        Shot = false;
    }

    public void transform(float oneShot, int numberWeapon)
    {
        EnergyOneShot = oneShot; //задаем потребность орудия в энергии для одного выстрела
        reloadWeapon = numberWeapon; //задаем номер перезаряжающегося орудия

        //находим не сокращенную велечину энерг. магазина
        EnergyMagazin = EnergyFull / EnergyOneShot;

        //сокращаем параметры энергии
        rEnergyFull = EnergyMagazin;
        rEnergyMagazin = EnergyMagazin / EnergyOneShot;


        if (numberWeapon == 1)
        {
            MainWeapon(true);
        }
        else
            DopWeapon(true);

        currentEnergy = energyMagazin;
    }

    public bool shooting(bool _shot)
    {
        if (currentEnergy != 0)
            currentEnergy -= 1;

        Reverse(true);

        Shot = _shot;
        return Shot;
    }

    public bool reloading(bool state)
    {
        TakeEnergy_1 = energyMagazin - currentEnergy;
        TakeEnergy_2 = energyFull / energyMagazin;

        if (TakeEnergy_2 != 0)
        {
            currentEnergy += TakeEnergy_1;
            energyFull -= TakeEnergy_1;
        }
        else
        {
            ResidueFE = energyFull % energyMagazin;
            if (TakeEnergy_1 < ResidueFE)
            {
                currentEnergy += TakeEnergy_1;
                energyFull -= TakeEnergy_1;
            }
            else
            {
                currentEnergy += ResidueFE;
                energyFull = 0;
            }
        }

        Reverse(true);

        Reload = state;
        return Reload;
    }

    private void MainWeapon(bool restart)
    {
        if (restart)
        {
            aEnergyFull = rEnergyFull / 3 * 2 - (EnergyFull % EnergyOneShot / EnergyOneShot);
            aEnergyMagazin = rEnergyMagazin - (EnergyMagazin % EnergyOneShot / EnergyOneShot);
            
            MainWeapon(false);
        }
        else
        {
            energyFull = (int)aEnergyFull;
            energyMagazin = (int)aEnergyMagazin;
        }
    }

    private void DopWeapon(bool restart)
    {
        if (restart)
        {
            dopEnergyFull = rEnergyFull / 3 - (EnergyFull % EnergyOneShot / EnergyOneShot);
            dopEnergyMagazin = rEnergyMagazin / 3 - (EnergyMagazin % EnergyOneShot / EnergyOneShot);

            DopWeapon(false);
        }
        else
        {
            energyFull = (int)dopEnergyFull;
            energyMagazin = (int)dopEnergyMagazin;
        }
    }

    private void Reverse(bool state)
    {
        if (state)
            if (reloadWeapon == 1)
            {
                aEnergyFull = energyFull;
                aEnergyMagazin = energyMagazin;
            }
            else
            {
                dopEnergyFull = energyFull;
                dopEnergyMagazin = energyMagazin;
            }
    }    
}