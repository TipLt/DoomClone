using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;


    public float bigDamage = 2f;
    public float smallDamage = 1f;



    public float fireRate = 1f;
    private float nextTimeToFire;

    public int maxAmmo;
    private int ammo;
    private BoxCollider gunTrigger;

    public EnemyManager enemyManager;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;



    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        UICanvasManager.Instance.UpdateAmmo(ammo);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        //play audio here
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();


        Collider[] hitEnemies;
        hitEnemies = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach(var hitEnemy in hitEnemies)
        {
            hitEnemy.GetComponent<EnemyAwareness>().isAggro = true;
        }
        //damage enemies
        foreach (var enemy in enemyManager.enemiesInRange)
        {

            if(enemy == null) continue;

            //get direction to enemy
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {

                    //range check
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        //damage enemy small
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        //damage enemy big
                        enemy.TakeDamage(bigDamage);
                    }



                        Debug.DrawRay(transform.position, dir, Color.green);

                }
            }


        }

        

        //reset fire rate
        nextTimeToFire = Time.time + fireRate;

        //deduct 1 ammo
        ammo--;
        Debug.Log("Ammo left: " + ammo);
        UICanvasManager.Instance.UpdateAmmo(ammo);

    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            int ammoBefore = ammo;

            ammo += amount;
            
        

        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        int actualAmmoGiven = ammo - ammoBefore;
        Debug.Log("Picked up " + actualAmmoGiven + " ammo. Current ammo: " + ammo);


        Destroy(pickup);

        }
        else
        {
            Debug.Log("Ammo full! Cannot pick up. (" + ammo + "/" + maxAmmo + ")");
        }

        UICanvasManager.Instance.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
