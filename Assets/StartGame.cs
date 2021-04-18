using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    bool MovInLodkaFl;
    GameObject lodka;
    GameObject Volk;
    GameObject Koza;
    GameObject Kapysta;
    int Shag;
    float speed = 50f;
    Transform bereg1;
    Transform bereg2;
    Rigidbody2D lodkarb;
    // Start is called before the first frame update
    void Start()
    {
        lodka = GameObject.Find("lodka");
        Volk = GameObject.Find("Volk");
        Koza = GameObject.Find("Koza");
        Kapysta = GameObject.Find("Kapysta");

        bereg1 = GameObject.Find("bereg1").transform;
       bereg2 = GameObject.Find("bereg2").transform;
        lodkarb = lodka.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       

        if (Shag == 1) {
            MovLodka(false);
            // StolLodka(lodkarb, lodkarb.transform, bereg2, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 2)
        {
            MovLodka(true);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 3)
        {
            MovLodka(false);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 4)
        {
            MovLodka(true);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 5)
        {
            MovLodka(false);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 6)
        {
            MovLodka(true);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }
        else if (Shag == 7)
        {
            MovLodka(false);
            // StolLodka(lodkarb, lodkarb.transform, bereg1, 3f, speed); //StartCoroutine()
        }




    }

    public void StartMove()
    {

        //        1.Переправить Козу
        MovInLodka(Koza);

       
        Shag = 1;
  
        //2.Вернуться обр0атно пустым(в лодке никого нет)
        //MovLodka(true);
        //3.Переправить Волка
        //4.Вернуться обратно забрав Козу
        //5.Переправить Капусту, оставив Козу
        //6.Вернуться обратно пустым
        //7.Переправить Козу.


    }

    void MovInLodka(GameObject Nom1, GameObject Nom2 = null)

    {
        Transform point1 = GameObject.Find("point1").transform;
        Nom1.transform.position = point1.position;
        Nom1.transform.SetParent(lodka.transform);

        if (Nom2 != null)
        {
            Transform point2 = GameObject.Find("point2").transform;
            Nom2.transform.position = point2.position;
            Nom2.transform.SetParent(lodka.transform);
        }
    }
    void MovLodka(bool beakbereg)

    { 
        MovInLodkaFl = true;


        if (!beakbereg)
        {
            // lodkarb.AddForceAtPosition(new Vector2(-0.5f, 0.7f), bereg2.position, ForceMode2D.Force);
            //lodkarb.MovePosition(bereg2.position + bereg2.forward * 0.001f * Time.deltaTime);
            StolLodka(lodkarb, lodkarb.transform, bereg2, 2f, speed);
        }
        else
        {
            StolLodka(lodkarb, lodkarb.transform, bereg1, 2f, speed);
            //lodkarb.AddForceAtPosition(new Vector2(0.5f, -0.7f), bereg1.position, ForceMode2D.Force);
        }
    }

   // void FollowTargetWitouthRotation(Rigidbody2D rigidbody, Transform goIt, Transform target, float distanceToStop, float speed)
 //  {

        Vector3 direction = Vector3.zero;
        //if (Vector3.Distance(goIt.position, target.position) > distanceToStop)
        //{
           // goIt.LookAt(target, Vector3.zero); //Vector3.up
       //     direction = target.position - goIt.position;
          //  rigidbody.MovePosition(target.position);//, ForceMode2D.Impulse
            //StartCoroutine(StolLodka(rigidbody, goIt, target, distanceToStop, speed));
        //}
        //else
        //    {
        //        goIt.position = target.position;
        //    }
    //}

    void StolLodka(Rigidbody2D rigidbody, Transform goIt, Transform target, float distanceToStop, float speed)
    {
        //Vector3 direction;
        float dist = Vector3.Distance(goIt.position, target.position);
        if (dist > distanceToStop)
        {
            goIt.position = Vector3.MoveTowards(goIt.position, target.position, Time.deltaTime * speed);

            // yield return null; 
            // goIt.LookAt(target, Vector3.zero); //Vector3.up
            // direction = target.position - goIt.position;
            // rigidbody.AddForceAtPosition(direction* speed, target.position, ForceMode2D.Force);//, ForceMode2D.Impulse
        }
        else
{  
           // yield return null; 
          goIt.position = target.position;
            Shag += 1;
            if (Shag == 2)
            {
                MovOutLodka(Koza, 1);
            }
            if (Shag == 3)
            {
                MovInLodka(Volk);
            }
            if (Shag == 4)
            {
                MovOutLodka(Volk, 1);
                MovInLodka(Koza);
            }
            if (Shag == 5)
            {
                MovOutLodka2(Koza, 1);
                MovInLodka(Kapysta);
            }
            if (Shag == 6)
            {
                MovOutLodka(Kapysta, 2);
               // MovInLodka(Kapysta);
            }
            if (Shag == 7)
            {
                //MovOutLodka2(Koza, 1);
                MovInLodka(Koza);
            }
        if (Shag == 8)
        {
                //MovOutLodka2(Koza, 1);
                MovOutLodka(Koza,3);
        }

    }
    }


    void MovOutLodka(GameObject Nom1, int nomnaber)

    {
        Transform point1 = GameObject.Find("bereg2point" + nomnaber).transform;
        Nom1.transform.position = point1.position;
        Nom1.transform.SetParent(point1.transform);
    }

    void MovOutLodka2(GameObject Nom1, int nomnaber)

    {
        Transform point1 = GameObject.Find("bereg1point" + nomnaber).transform;
        Nom1.transform.position = point1.position;
        Nom1.transform.SetParent(point1.transform);
    }
}

