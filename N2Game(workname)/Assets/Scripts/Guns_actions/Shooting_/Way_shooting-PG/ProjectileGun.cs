using System;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileGun : MonoBehaviour
{
    //параметры энергии орудия
    public static int energyFull = 32; //макс. запас энергии
    public static int energyFullCurrent = energyFull; //оставшаяся энергия
    public static int energyClip = 4; //макс. запас энергии в обойме
    public static int energyClipCurrent = energyClip; //оставшаяся энергия в обойме

    //ссылка на скрипт
    private EnergyBank Bank;

    //объекты
    private Animator anim;
    private GameObject ProjGun;
    private GameObject MainCamera;
        
    //переменные снаряда
    private GameObject projectile;
    private GameObject square;

    //текстовые объекты
    public Text mainBankText; //текст макс. кол - во патрон
    public Text currentEnergyText; //текст кол - во патрон в обойме


    private void Start()
    {
        //ссылки на игровые объекты        
        anim = GetComponent<Animator>();
        ProjGun = GameObject.Find("Gun_two").GetComponent<GameObject>();
        MainCamera = GameObject.FindWithTag("MainCamera");

        //находим префабы:
        square = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;

        //ссылки на скрипты
        Bank = GameObject.Find("EnergyBank").GetComponent<EnergyBank>();

        //ссылки на текст, показывающий энергию
        mainBankText = GameObject.Find("Main_bank").GetComponent<Text>();
        currentEnergyText = GameObject.Find("Use_energy").GetComponent<Text>();
    }

    private void Update()
    {
        ManagementProjGun();
    }

    private void ManagementProjGun()
    {
        InformOfEnergy();                
    }

    private void InformOfEnergy()
    {
        if (!Bank.reload)
        {
            EnergyBank.energyFull = energyFull;
            EnergyBank.energyFullCurrent = energyFullCurrent;
            EnergyBank.energyClip = energyClip;
            EnergyBank.energyClipCurrent = energyClipCurrent;
        }
        else
        {
            energyFullCurrent = EnergyBank.energyFullCurrent;
            energyClipCurrent = EnergyBank.energyClipCurrent;
            Bank.reloading(false);
        }
        if (energyClipCurrent == 0 && energyFullCurrent != 0) reloading();
    }

    public void reloading()
    {
        if (!anim.GetBool("boolReloading") && !anim.GetBool("boolShooting")
            && gameObject.active && energyClipCurrent != energyClip)
        {            
            anim.SetBool("boolReloading", true);
        }
    }

    public void shooting()
    {
        if (!anim.GetBool("boolReloading") && !anim.GetBool("boolShooting")
            && gameObject.active)
        {
            if (energyClipCurrent != 0)
            {
                anim.SetBool("boolShooting", true);
                CreateProj();
                energyClipCurrent--;
            }
            else if (energyFull != 0)
                reloading();
        }
    }

    private void CreateProj()
    {
        //создаем префаб
        projectile = Instantiate(square);

        //размещаем префаб в точке:
        projectile.transform.position = MainCamera.transform.TransformPoint(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1.2f);

        //направляем префаб
        projectile.transform.localRotation = MainCamera.transform.rotation;        
    }

    private void AnimationControll()
    {
        if (anim.GetBool("boolReloading"))
        {
            anim.SetBool("boolReloading", false);
            Bank.reloading(true);
        }

        anim.SetBool("boolShooting", false);        
    }
}