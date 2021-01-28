using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private float gameTime;
    public static float second;
    public static int count;
    public static int slid;

    private float x;
    private float y;

    [SerializeField] private GameObject Bonus;

    GameObject _bonus;

    public Text over;
    public Text timer;
    public Text counter;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
        second = 30.0f;
        slid = 0;
    }

    // Update is called once per frame
    void Update()
    {


        timer.text = $"{second}";

        gameTime += 1 * Time.deltaTime;
        if (gameTime >= 1) 
        {
            second -= 1;
            gameTime = 0;
        }

        if (count <1  || second <1 ) 
        {
            over.text = "Конец игры, Ваш счёт: " + count + " , для выхода нажмите ESC для повтора нажмите Enter.";
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            }
        }

        counter.text = $"{count}";
        if (slid == 5)
        {
            x = Random.Range(-8.5f, 8.5f);
            y = Random.Range(-3.0f, 4.0f);
            _bonus = Instantiate(Bonus) as GameObject;
            _bonus.transform.position = new Vector2(x, y);
            slid = 0;
            slider.value = slid;
        }
        else 
        {
            slider.value = slid;
        }
    }
}
