using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour, IEnemy
{
    [SerializeField] public GameObject dragonEgg;
    [SerializeField] public GameObject dragonGreenEgg;
    [SerializeField] public GameObject miniBasket;

    private float[] force =new float[] { 450f, 600f, 750f, 900f,1000f } ;
    private float[] speed =new float[] { 6f,8f,12f,16f,32f };
    private float currentSpeed = 4f;
    private float currentForce = 300f;
    [SerializeField] private float timeBetweenEggDrops = 2f;
    [SerializeField] private float leftRightDistanse = 10f;
    [SerializeField] private float chanceDirections = 0.01f;
    
    private float timerForDropEgg;
    
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (Random.value<chanceDirections)
        {
            currentSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RandomChoiceItem();
    }

   

    public void Move()
    {
        Vector3 pos = transform.position;
        pos.x += currentSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftRightDistanse)
        {
            currentSpeed = Mathf.Abs(currentSpeed);
        }
        else if (pos.x > leftRightDistanse)
        {
            currentSpeed = -Mathf.Abs(currentSpeed);
        }
    }

    public void RandomChoiceItem()
    {
        if (timerForDropEgg <= 0)
        {
            if (!(ScharedData.Health<3f))
            {
                EggSelection();
            }
            else
            {
                if (Random.Range(0f, 7f) >= 6)
                {
                    TeleportItemToDragon(miniBasket);
                }
                else
                {
                    EggSelection();
                }
            }
            
            timerForDropEgg = timeBetweenEggDrops;

        }
        else
        {
            timerForDropEgg -= Time.deltaTime;
        }
    }

    public void TeleportItemToDragon(GameObject dragonEgg) 
    {
        Vector3 delayPositionCreateEgg = new Vector3(0f, 5f, 0f);
        dragonEgg.GetComponent<Rigidbody>().velocity = Vector3.zero;
        dragonEgg.transform.position = transform.position + delayPositionCreateEgg;
        dragonEgg.GetComponent<Rigidbody>().AddForce(Vector3.down * currentForce);
        
    }
    private void OnEnable()
    {
        EventManager.eventOnScoreUpdate += CheckScoreAndChangeDifficulty;
    }
    void OnDisable()
    {
        EventManager.eventOnScoreUpdate -= CheckScoreAndChangeDifficulty;
    }
    private void CheckScoreAndChangeDifficulty()
    {
        switch (ScharedData.Score)
        {
            case 40:
                currentForce = force[4];
                currentSpeed = speed[4];
                timeBetweenEggDrops = 1f;
                break;
            case 30:
                currentForce = force[3];
                currentSpeed = speed[3];
                timeBetweenEggDrops = 1.1f;
                break;
            case 20:
                currentForce = force[2];
                currentSpeed = speed[2];
                timeBetweenEggDrops = 1.4f;
                break;
            case 10:
                currentForce = force[1];
                currentSpeed = speed[1];
                timeBetweenEggDrops = 1.7f;
                break;
            case 5:
                currentForce = force[0];
                currentSpeed = speed[0];
                timeBetweenEggDrops = 1.8f;
                break;
            default:
                break;
        }
        
    }
    private void EggSelection()
    {
        if (Random.Range(0f, 5f) >= 3)
        {
            TeleportItemToDragon(dragonGreenEgg);
        }
        else
        {
            TeleportItemToDragon(dragonEgg);
        }
    }
}
