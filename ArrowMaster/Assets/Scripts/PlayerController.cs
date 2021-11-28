using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    public float LeftRightSpeed;
    Vector2 StartTouchVector;
    public GameObject camera;
    Vector3 arrowpos;
    public GameObject arrow;
    public List<GameObject> arrowList;
    public GameObject ArrowSizeText;
    public GameObject FailPanel;
    public GameObject WinnerPanel;
    public bool FinishConnect;
   public enum PlayerStatus {
    plus,
    minus,
    impac,
    divide
    };
    public static PlayerController instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
        camera.transform.position += Vector3.forward * speed * Time.deltaTime;
        if (!FinishConnect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartTouchVector = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                if (this.transform.position.x <= 4.10f && this.transform.position.x >= -4.10f)
                {
                    if (Input.mousePosition.x > StartTouchVector.x)
                    {
                        this.transform.position += Vector3.right * LeftRightSpeed * Time.deltaTime;
                    }
                    if (Input.mousePosition.x < StartTouchVector.x)
                    {
                        this.transform.position += Vector3.left * LeftRightSpeed * Time.deltaTime;
                    }
                    StartTouchVector = Input.mousePosition;
                }
                else
                {
                    if (this.transform.position.x > 4.10f)
                    {
                        this.transform.position = new Vector3(4.09f, this.transform.position.y, this.transform.position.z);
                    }
                    else if (this.transform.position.x < -4.10f)
                    {
                        this.transform.position = new Vector3(-4.09f, this.transform.position.y, this.transform.position.z);
                    }
                }

            }
        }
        
     

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Finish")
        {
            FinishConnect = true;

            this.transform.position = new Vector3(0, transform.position.y+2, transform.position.z);
            this.GetComponent<BoxCollider>().size = new Vector3(10, 5, 1);
            ArrowEnemydecline(other.GetComponent<EnemyController>().EnemySize, other.GetComponent<EnemyController>().enemyStatus);

        }
        if (other.gameObject.tag=="Gate")
        {

            ArrowDuplication(other.GetComponent<GateController>().gatesize, other.GetComponent<GateController>().gateStatus);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag=="Enemy")
        {
            if (other.GetComponent<EnemyController>().Death == false)
            {
                ArrowEnemydecline(other.GetComponent<EnemyController>().EnemySize, other.GetComponent<EnemyController>().enemyStatus);
                other.GetComponent<EnemyController>().DeathAnim();

            }
        }
        if (other.gameObject.tag=="FinishEnd")
        {
            speed = 0;
            foreach (GameObject g in arrowList)
            {
                Destroy(g);
            }
            WinnerPanel.SetActive(true);
            Destroy(ArrowSizeText);
        }
    }
    public void ArrowDuplication(int value,PlayerStatus status)
    {
        int objeSize = 0;
        int arrowListCount = 0;

        if (status==PlayerStatus.plus)
        {
            arrowListCount = value + arrowList.Count;
        }
        if (status==PlayerStatus.minus)
        {
            arrowListCount = arrowList.Count-value;
        }
        if (status==PlayerStatus.impac)
        {
            arrowListCount = arrowList.Count * value;
        }
        if (status == PlayerStatus.divide)
        {
            arrowListCount = arrowList.Count / value;
        }
        foreach (GameObject g in arrowList)
        {
            Destroy(g);
        }
        arrowList.Clear();

        //for (int i = 0; i < value ; i++)
        //{

        //    //Instantiate(arrow, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        //    GameObject obj = Instantiate(arrow, this.transform);
        //    obj.transform.localPosition = new Vector3(i * 0.2F, 0, 0);
        //    arrowList.Add(obj);

        //}

        if (arrowListCount<1)
        {
            speed = 0;
            FailPanel.SetActive(true);
            Destroy(ArrowSizeText);
        }
         

        else  if (arrowListCount==1)
        {
         GameObject obj = Instantiate(arrow, this.transform);
         obj.transform.localPosition = new Vector3( 0, 0, 0);
         arrowList.Add(obj);
          
        }
        else if (arrowListCount < 10)
        {
            for (float i = -0.2f; i < 0.2; i+=0.2f)
            {
                for (float  j = -0.2f; j < 0.2; j+=0.2f)
                {
                    if (objeSize!=arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize==arrowListCount)
                {
                    break;
                }
            }
        }
        else if (arrowListCount < 26)
        {
            for (float i = -0.4f; i < 0.4f; i += 0.2f)
            {
                for (float j = -0.4f; j < 0.4; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
        }
        else if (arrowListCount < 50)
        {
            for (float i = -0.6f; i < 0.6f; i += 0.2f)
            {
                for (float j = -0.6f; j < 0.6f; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
        }
        else if (arrowListCount < 82 )
        {
            for (float i = -0.8f; i < 0.8; i += 0.2f)
            {
                for (float j = -0.8f; j < 0.8; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
        }
        else if (arrowListCount < 122)
        {
            for (float i = -1; i < 1; i += 0.2f)
            {
                for (float j = -1f ; j < 1f; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
        }
        else  
        {
            for (float i = -1.2f; i < 1.2f; i += 0.2f)
            {
                for (float j = -1.2f; j < 1.2f; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(i, j, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
        }
        ArrowSizeText.GetComponent<TextMesh>().text = arrowListCount.ToString();




    }
    public void ArrowEnemydecline(int value, PlayerStatus status)
    {
        int objeSize = 0;
        int arrowListCount = 0;
        if (status == PlayerStatus.minus)
        {
            arrowListCount = arrowList.Count - value;
        }
        if (arrowListCount < 1)
        {
            speed = 0;
            foreach (GameObject g in arrowList)
            {
                Destroy(g);
            }
            WinnerPanel.SetActive(true);
            Destroy(ArrowSizeText);
        }
        else
        {


            foreach (GameObject g in arrowList)
            {
                Destroy(g);
            }
            arrowList.Clear();
            for (float i = -3f; i < 3; i += 0.2f)
            {
                for (float j = -3f; j < 3; j += 0.2f)
                {
                    if (objeSize != arrowListCount)
                    {
                        GameObject obj = Instantiate(arrow, this.transform);
                        obj.transform.localPosition = new Vector3(j, i, 0);
                        arrowList.Add(obj);
                        objeSize++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (objeSize == arrowListCount)
                {
                    break;
                }
            }
            ArrowSizeText.GetComponent<TextMesh>().text = arrowListCount.ToString();

        }

    }
}
