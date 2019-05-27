using UnityEngine;

public class ProjectileGun_MOS_0__ : MonoBehaviour
{
    private Animator anim;
    private Animation Animat;
    private GameObject camera;



    //private float Timer_0;
    //private float Timer_1;

    //private bool reload = false;    
    //private bool shooting = false;
    //private float reloadTiming = 1.2f;
    //private float shootingTiming = 1f;


    private Main_bank val;
    public int UseEnergy = 20;
    public int CurrentEnergy;    

    private GameObject projectile;
    private GameObject square;

    

    public bool F = false;

    private void Start()
    {

        int hash = Animator.StringToHash("ShootingProjGun_TypeNull");





        //достаем сняряд из папки Resources
        square = Resources.Load("Prefubs/Gun_two/projectile_M0") as GameObject;

        Animat = GetComponent<Animation>();

        camera = GameObject.FindWithTag("MainCamera");
        anim = GetComponent<Animator>();
        val = GetComponent<Main_bank>();
    }

    private void Update()
    {
        Shot();
    }


    private void Shot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!anim.GetBool("boolShooting0"))
            {
                anim.SetBool("boolShooting0", true);

                //создаем префаб
                projectile = Instantiate(square);

                //размещаем префаб
                projectile.transform.position = camera.transform.TransformPoint(
                    new Vector3(
                    transform.localPosition.x,
                    transform.localPosition.y,
                    camera.transform.localPosition.z + 1.8f));

                //направляем префаб
                projectile.transform.rotation = camera.transform.rotation;

                

                //anim.SetBool("boolShooting0", false);
                CurrentEnergy -= 1;
            }
        }
    }


    private void ShotAgain()
    {
        anim.SetTrigger("triggerShooting0");
    }
}