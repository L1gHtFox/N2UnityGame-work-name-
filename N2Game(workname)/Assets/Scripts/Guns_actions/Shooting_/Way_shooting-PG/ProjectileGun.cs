using UnityEngine;
using UnityEngine.UI;

public class ProjectileGun : MonoBehaviour
{
    //объекты
    private Animator anim;
    private GameObject camera;

    //переменные энергии
    public int fullEnergy = 360;
    private int ResidueFE;
    private int takeEnergy_1;
    private int takeEnergy_2;
    private int useEnergy = 20;
    public int currentEnergy;

    private bool Reload = false;
    private bool Shoot = false;

    //переменные для таймера
    private int ValForTimer = 0;
    private bool trueTimer = false;
    private float DynamicSupTime;
    private float StaticSupTime;

    //тайминги
    private float beginTime = 5f;
    private float RateOfShoot = 0.8f;
    private float ReloadTime = 1.8f;
    
    //переменные снаряда
    private GameObject projectile;
    private GameObject square;

    //текстовые объекты
    public Text mainBankText; //текст макс. кол - во патрон
    public Text currentEnergyText; //текст кол - во патрон в обойме    


    private void Start()
    {        
        //достаем сняряд из папки Resources
        square = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;

        //ссылка на камеру главного героя
        camera = GameObject.FindWithTag("MainCamera");

        //ссылка на аниматор
        anim = GetComponent<Animator>();

        //ссылка на текст, показывающий макс. кол - во патрон
        mainBankText = GameObject.Find("Main_bank").GetComponent<Text>();

        //ссыклка на текст, показывающий кол - во патрон в обойме
        currentEnergyText = GameObject.Find("Use_energy").GetComponent<Text>();

        //задаем переменные:
        DynamicSupTime = beginTime; //задаем изначальный интервал таймера (чтобы он сразу не повышался с нуля)
        currentEnergy = useEnergy; //задаем изначально кол-во энергии в обойме 
    }

    private void Update()
    {        
        ManagementProjGun();        
    }

    private void ManagementProjGun()
    {
        InformOfEnergy();

        switch (ValForTimer)
        {
            case 0:
                StaticSupTime = ReloadTime;

              break;

            case 1:
                StaticSupTime = RateOfShoot;

              break;
        }

        if (trueTimer && DynamicSupTime >= StaticSupTime)
            DynamicSupTime = 0;

        if (DynamicSupTime <= StaticSupTime)
            DynamicSupTime += Time.deltaTime;
    }

    private void InformOfEnergy()
    {
        if (currentEnergy == 0 && fullEnergy != 0)
            reloading();

        if (!Reload)
        {
            currentEnergyText.text = currentEnergy.ToString(); //вывод кол - ва патрон в обойме на экран
            mainBankText.text = fullEnergy.ToString(); //вывод макс. кол - ва патрон на экран
        }
        else
        {
            if (DynamicSupTime <= ReloadTime)
            {
                anim.SetTrigger("triggerReloading0");
                trueTimer = true;
            }
        }

        if (ValForTimer == 0 && DynamicSupTime >= ReloadTime)
        {
            trueTimer = false;
            Reload = false;

            anim.ResetTrigger("triggerReloading0");
        }

        if (ValForTimer == 1 && DynamicSupTime >= RateOfShoot)
        {
            trueTimer = false;
            Shoot = false;

            anim.ResetTrigger("triggerShooting0");
        }
    }

    public void reloading()
    {
        if (gameObject.active && !Shoot && !Reload)
        {
            ValForTimer = 0;

            takeEnergy_1 = useEnergy - currentEnergy;
            takeEnergy_2 = fullEnergy / useEnergy;

            if (takeEnergy_2 != 0)
            {
                Reload = true;

                currentEnergy += takeEnergy_1;
                fullEnergy -= takeEnergy_1;
            }
            else
            {
                Reload = true;

                ResidueFE = fullEnergy % useEnergy;
                if (takeEnergy_1 < ResidueFE)
                {
                    currentEnergy += takeEnergy_1;
                    fullEnergy -= takeEnergy_1;
                }
                else
                {
                    currentEnergy += ResidueFE;
                    fullEnergy = 0;
                }
            }
        }
    }

    public void shooting()
    {        
        if (gameObject.active)
        {                        
            if (!Reload && !Shoot)
            {
                ValForTimer = 1;
                if (currentEnergy != 0)
                {
                    trueTimer = true;
                    Shoot = true;
                    anim.SetTrigger("triggerShooting0");
                    CreateProj();
                    currentEnergy -= 1;

                    DynamicSupTime = 0;
                }
                else if (fullEnergy != 0)
                    reloading();                
            }                                     
        }
    }

    private void CreateProj()
    {
        //создаем префаб
        projectile = Instantiate(square);

        //размещаем префаб в точке:
        projectile.transform.position = camera.transform.TransformPoint(
            new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            camera.transform.localPosition.z + 2.4f));

        //направляем префаб
        projectile.transform.rotation = camera.transform.rotation;        
    }
}