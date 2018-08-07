using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRock : MonoBehaviour {
    public Rigidbody player;
    private static float strenght = 10;
    private static float speed = 10;
    private static float skipping = 6;
    private static float _skipping = 0;
    public bool isStart = true;
    public bool isFly = false;

    [SerializeField] private Text EarnedMoney;
    [SerializeField] private GameObject EndMenu;

    public GameObject Shop;
    public GameObject body;
    public GameObject camera_;
    public GameObject money_;
    public GameObject PowerScroll;

    float sensitivityX = 0.03f;
    float sensitivityY = 0.1f;

    void Update() {
        if (isStart)
        {
            StartMove();
        }
        if (isFly)
        {
            MoveX();
        }
    }

    private void MoveX()
    {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).deltaPosition.x < 0)
                {
                    if (player.transform.position.x > -10)
                        if ((player.transform.position.x + Input.GetTouch(0).deltaPosition.x * sensitivityX) > -10)
                            player.transform.position = new Vector3(player.transform.position.x + Input.GetTouch(0).deltaPosition.x * sensitivityX, player.transform.position.y, player.transform.position.z);
                        else
                            player.transform.position = new Vector3(-10, player.transform.position.y, player.transform.position.z);

                }
                if (Input.GetTouch(0).deltaPosition.x > 0)
                {
                    if (player.transform.position.x < 10)
                        if ((player.transform.position.x + Input.GetTouch(0).deltaPosition.x * sensitivityX) < 10)
                            player.transform.position = new Vector3(player.transform.position.x + Input.GetTouch(0).deltaPosition.x * sensitivityX, player.transform.position.y, player.transform.position.z);
                        else
                            player.transform.position = new Vector3(10, player.transform.position.y, player.transform.position.z);

                }
            }
    }
    private void Start()
    {
        PowerScroll.SetActive(false);
        EndMenu.SetActive(false);
    }

    private void EndJump()
    {
        _skipping = 0;
        EndMenu.SetActive(true);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        isFly = false;
        EarnedMoney.text = ("" + (int)player.transform.position.z);
        System.GC.Collect();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            if (_skipping > 0) {
                player.velocity = new Vector3(0, Mathf.Min(_skipping, 8), _skipping * speed);
                _skipping--;
            } else {
                EndJump();
            }
        }
        if (collision.gameObject.name == "Island")
        {
            EndJump();
        }
    }

    void StartMove (){
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            if (Input.GetTouch(0).deltaPosition.y < 0)
            {
                if (body.transform.eulerAngles.y < 14)
                {
                    if ((body.transform.eulerAngles.y - Input.GetTouch(0).deltaPosition.y * sensitivityY) > 14)
                        body.transform.Rotate(0, 14 - body.transform.eulerAngles.y, 0);
                    else
                        body.transform.Rotate(0, -1 * sensitivityY * Input.GetTouch(0).deltaPosition.y, 0);
                }
            }
            if (Input.GetTouch(0).deltaPosition.y > 0)
            {
                if (body.transform.rotation.y > 0)
                {
                    if ((body.transform.eulerAngles.y - Input.GetTouch(0).deltaPosition.y * sensitivityY) < 0)
                        body.transform.Rotate(0, -1 * body.transform.eulerAngles.y, 0);
                    else
                        body.transform.Rotate(0, -1 * sensitivityY * Input.GetTouch(0).deltaPosition.y, 0);
                }
            }
        }
        if (body.transform.eulerAngles.y >= 13.6)
        {
            PowerScroll.SetActive(true);
            PowerScroll.GetComponent<Scrollbar>().value = Mathf.PingPong(Time.time, 1);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                float bonus = 1;
                _skipping = skipping;
                Shop.SetActive(false);
                camera_.GetComponent<CameraMove>().CameraMoveOn = true;
                PowerScroll.SetActive(false);
                isStart = false;
                isFly = true;
                if (PowerScroll.GetComponent<Scrollbar>().value >= 0.4 && PowerScroll.GetComponent<Scrollbar>().value <= 0.6)
                {
                    bonus = 2;
                }
                else
                {
                    if (PowerScroll.GetComponent<Scrollbar>().value > 0.6)
                        bonus += (1 - PowerScroll.GetComponent<Scrollbar>().value);
                    else
                        bonus += PowerScroll.GetComponent<Scrollbar>().value;
                }
                player.velocity = new Vector3(player.velocity.x, player.velocity.y + 5, strenght * speed * bonus);
            }
        }
        else
        {
            PowerScroll.SetActive(false);
        }
    }

    public void strenghtSet(float newStrenght)
    {
        strenght = newStrenght;
    }

    public void speedSet(float newSpeed)
    {
        speed = newSpeed;
    }

    public void skippingSet(float newSkipping)
    {
        skipping = newSkipping;
    }



    public void strenghtUp()
    {
        strenght+=0.5f;
    }

    public void speedUp()
    {
        speed += 0.1f;
    }

    public void skippingUp()
    {
        skipping++;
    }

    public float strenghtReturn()
    {
        return (strenght);
    }

    public float speedReturn()
    {
        return (speed);
    }

    public float skippingReturn()
    {
        return (skipping);
    }
}
