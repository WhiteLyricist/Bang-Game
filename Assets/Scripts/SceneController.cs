using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject Mob1;
    [SerializeField] private GameObject Mob2;
    [SerializeField] private GameObject Mob3;
    [SerializeField] private GameObject Mob4;
    [SerializeField] private GameObject Bang;

    private float delay;
    private int selectMob;
    private int positionsMob;
    private float MobX;
    private float MobY;
    private float Mob4Y;
    private bool _switch;

    private float k=3.0f;

    GameObject _mob;
    GameObject _boom;
    GameObject hitObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!_switch)
        {
            StartCoroutine(CreateMob());
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Координаты курсора.
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero); //Луч исходящий из курсора.
            if (rayHit.transform != null) //Проверкав на наличие попадания луча.
            {
                hitObject = rayHit.transform.gameObject;
                if (hitObject.tag == "Bonus")
                {
                    UIController.second += 3;
                    _boom = Instantiate(Bang) as GameObject;
                    _boom.transform.position = hitObject.transform.position;
                    Destroy(hitObject);
                }
                if (hitObject.tag != "Floor" && hitObject.tag != "Bonus")
                {
                    UIController.count++;
                    _boom = Instantiate(Bang) as GameObject;
                    _boom.transform.position = hitObject.transform.position;
                    Destroy(hitObject); //Удаление объекта в который попал луч.
                    UIController.slid++;
                }
                else
                {
                    if (hitObject.tag != "Bonus")
                    {
                        UIController.count--;
                        UIController.slid = 0;
                    }
                }
            }
            else 
            {
                UIController.count--;
                UIController.slid = 0;
            }
        }

    }


    public IEnumerator CreateMob() 
    {
        _switch = true;

        if (k == 1)
        {
            delay = 1.0f;
        }
        else 
        {
            delay = Random.Range(1, k);
            k -= 0.05f;
        }

        selectMob = Random.Range(1, 5);
        positionsMob = Random.Range(1, 5);

        yield return new WaitForSeconds(delay);

        switch (positionsMob)
        {
            case 1:
                {
                    MobX = -10.0f;
                    MobY = 2.0f;
                    Mob4Y = Random.Range(2.1f, 4.1f);
                    break;
                }
            case 2:
                {
                    MobX = 10.0f;
                    MobY = 2.0f;
                    Mob4Y = Random.Range(2.1f, 4.1f);
                    break;
                }
            case 3:
                {
                    MobX = -10.0f;
                    MobY = -3.0f;
                    Mob4Y = Random.Range(-3.3f,-0.55f);
                    break;
                }
            case 4:
                {
                    MobX = 10.0f;
                    MobY = -3.0f;
                    Mob4Y = Random.Range(-3.3f, -0.55f);
                    break;
                }
        }

        switch (selectMob) 
        {
            case 1 :
                {
                    _mob = Instantiate(Mob1) as GameObject;
                    _mob.transform.position = new Vector2(MobX, MobY);
                    break;
                }
            case 2:
                {
                    _mob = Instantiate(Mob2) as GameObject;
                    _mob.transform.position = new Vector2(MobX, MobY);
                    break;
                }
            case 3:
                {
                    _mob = Instantiate(Mob3) as GameObject;
                    _mob.transform.position = new Vector2(MobX, MobY);
                    break;
                }
            case 4:
                {
                    _mob = Instantiate(Mob4) as GameObject;
                    _mob.transform.position = new Vector2(MobX, Mob4Y);
                    break;
                }
        }

        _switch = false;

    }

}
