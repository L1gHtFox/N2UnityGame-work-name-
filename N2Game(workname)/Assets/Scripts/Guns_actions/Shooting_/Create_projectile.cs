using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Create_projectile : MonoBehaviour
{
    //значения, которые требуют ссылки
    private GameObject _prefabProjectile; //объект "bullet"
    private GameObject _camera; //камера героя 

    //значения методов стрельбы
    public int current_MOS = 0; //текущий выбранный метод
    public int total_MOS = 1; //максимальное кол - во методов
    
    //значения патрон
    public int fullAmmo = 180; //максимальный запас патрон
    public int defltAmmoMag = 30; //стандартный запас патрон в обойме
    public int currentAmmo = 30; //текущий запас патрон в обойме
    
    //текстовые объекты
    public Text ammoInMagazineText; //текст кол - во патрон в обойме
    public Text fullAmmoText; //текст макс. кол - во патрон

    //значения оружий
    public int scrollInt = 0; //текущее оружие
    public int maxGuns = 2; //всего оружий экипировано


    void Start()
    {
        //ссыклка на текст, показывающий кол - во патрон в обойме
        ammoInMagazineText = GameObject.FindWithTag("Text_gun_Two/N1").GetComponent<Text>();

        //ссылка на текст, показывающий макс. кол - во патрон
        fullAmmoText = GameObject.FindWithTag("Text_gun_Two/N2").GetComponent<Text>();

        ammoInMagazineText.text = currentAmmo.ToString(); //вывод кол - ва патрон в обойме на экран
        fullAmmoText.text = fullAmmo.ToString(); //вывод макс. кол - ва патрон на экран
 
        //поиск камеры по тегу
        _camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {      
        shoot();
    }

    //стрельба объектами
    public void shoot()
    {
        choose_MOS(); //подключение возможности "выбор метода стрельбы"
     
        if (Input.GetMouseButtonDown(0) && current_MOS == 0 && currentAmmo > 0)
        {
            //создание "bullet", путем доставания ее из папки
            _prefabProjectile = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;

            GameObject projectile = Instantiate(_prefabProjectile);            

            projectile.transform.position = _camera.transform.TransformPoint(Vector3.forward * 1.5f);
            projectile.transform.rotation = _camera.transform.rotation;           

            currentAmmo -= 1;
            ammoInMagazineText.text = currentAmmo.ToString();             
        }
        else if (Input.GetMouseButton(0) && current_MOS == 1 && currentAmmo > 0)
        {
            //создание "bullet", путем доставания ее из папки
            _prefabProjectile = Resources.Load("Prefubs/Gun_two/projectile_M1") as GameObject;

            GameObject projectile = Instantiate(_prefabProjectile);

            projectile.transform.position = _camera.transform.TransformPoint(Vector3.forward * 1.5f);
            projectile.transform.rotation = _camera.transform.rotation;

            currentAmmo -= 1;
            ammoInMagazineText.text = currentAmmo.ToString();
        }
        else if (currentAmmo <= 0 && fullAmmo - currentAmmo > 0)
        {
            recharge();           
        }
        else if (Input.GetButtonDown("Recharge") && fullAmmo > 0)
        {
            recharge();
        }        
    }   

    //выбор метода стрельбы
    public int choose_MOS()
    {
        if (Input.GetButtonDown("Change")) current_MOS += 1;
        if (current_MOS > total_MOS) current_MOS = 1;      

        return current_MOS;
    }

    //перезарядка оружия
    private void recharge()
    {
        if (fullAmmo - currentAmmo > 0) fullAmmo -= (defltAmmoMag - currentAmmo);
        else if (fullAmmo - currentAmmo < 0) Debug.Log("Нет патронов для пополнения обоймы!"); ;        

        currentAmmo = defltAmmoMag;
       
        ammoInMagazineText.text = currentAmmo.ToString();
        fullAmmoText.text = fullAmmo.ToString();
    }
}