using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Way_shoot_0 : MonoBehaviour
{
    //значения, которые требуют ссылки
    private GameObject _prefabProjectile; //ссылка на сняряд
    private GameObject projectile; //сняряд
    public GameObject _camera;

    //значения патрон
    public int fullAmmo = 60; //максимальный запас патрон
    public int defltAmmoMag = 20; //стандартный запас патрон в обойме
    public int currentAmmo = 20; //текущий запас патрон в обойме
    public int takeAmmo = 0; //патроны, которые герой собирается применить

    //проверка на перезарядку
    private bool reload = false;

    //текстовые объекты
    public Text MagazineText; //текст кол - во патрон в обойме
    public Text fullAmmoText; //текст макс. кол - во патрон

    private void Start()
    {
        //поиск камеры героя
        _camera = GameObject.Find("Main Camera");

        //ссылка на текст, показывающий макс. кол - во патрон
        fullAmmoText = GameObject.Find("Full_Ammo_2").GetComponent<Text>();

        //ссыклка на текст, показывающий кол - во патрон в обойме
        MagazineText = GameObject.Find("AmmoInMagazine_2").GetComponent<Text>();

        //достаем сняряд из папки resources
        _prefabProjectile = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;
    }


    private void Update()
    {
        if (reload == false)
        {
            MagazineText.text = currentAmmo.ToString(); //вывод кол - ва патрон в обойме на экран
            fullAmmoText.text = fullAmmo.ToString(); //вывод макс. кол - ва патрон на экран
        }

        true_of_Shoot();
    }

    //проверка истины стрельбы
    private void true_of_Shoot()
    {
        if (reload == false && Input.GetButtonDown("Fire1") && currentAmmo > 0)
            Shoot();
        else if (Input.GetButtonDown("Reloading") || currentAmmo == 0)
            if (reload == false)
                StartCoroutine(enum_reload());
    }

    //выстрел
    private void Shoot()
    {
        //создаем снаряд
        projectile = Instantiate(_prefabProjectile);

        //рязмещаем снаряд
        projectile.transform.position = _camera.transform.TransformPoint(Vector3.forward * 1.5f);
        projectile.transform.rotation = _camera.transform.rotation;

        currentAmmo -= 1;
        MagazineText.text = currentAmmo.ToString();
    }

    //последовательность действий при перезарядки
    private IEnumerator enum_reload()
    {
        if (fullAmmo != 0)
        {
            MagazineText.text = "Reloading";
            reload = true; //сообщаем о том что оружие на перезарядке
        }
        else
            MagazineText.text = "No_ammo";

        //ждем "завершения" перезарядки
        yield return new WaitForSeconds(1.9f);
        Reloading();
    }

    //перезарядка оружия
    private void Reloading()
    {
        takeAmmo = defltAmmoMag - currentAmmo;

        if (fullAmmo >= takeAmmo)
        {
            fullAmmo -= takeAmmo;
            currentAmmo = defltAmmoMag;
        }
        else if (fullAmmo <= takeAmmo && fullAmmo > 0)
        {
            currentAmmo = fullAmmo;
            fullAmmo -= fullAmmo;
        }

        //сообщяем о завершении перезарядки
        reload = false;
    }
}