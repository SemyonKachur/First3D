using UnityEngine;

public class PlayerController : MonoBehaviour, ITakeDamage
{
    public GameObject bulletSpawnPlace = null;
    public Camera mainCamera = null;
    public bool BlueKeyIsGrab = false;
    public bool RedKeyIsGrab = false;
    public bool GoldKeyIsGrab = false;
    public int ammo = 5;
    public int bombAmmo = 0;
    public int health = 100;
    public float _jumpForce = 1000.0f;

    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject bomb = null;
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _rotateSpeed = 20.0f;
    [SerializeField] private UIScript _playerUI = null;
    [SerializeField] private PauseMenu _pauseMenu = null;
    [SerializeField] AudioClip _playerStepOne = null;
    [SerializeField] AudioClip _playerStepTwo = null;
    [SerializeField] AudioClip _playerDeath = null;
    [SerializeField] AudioClip _playerJump = null;
    [SerializeField] AudioClip _playerDamage = null;
    private Animator _animator = null;
    private Rigidbody _rigidbody = null;
    private AudioSource _playerAudioSource = null;
    private AudioClip _playerShoot = null;
    private Vector3 direction = Vector3.zero;
    private Vector3 rotarion = Vector3.zero;
    private Vector3 _offset = new Vector3(0, 4.5f, -3);
    private RaycastHit hit;
    private bool _isAlive = true;
    private bool _isMove = false;
    private bool _isGround = true;
    private float _forwardMovingStepTime = 0.0f;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerAudioSource = GetComponent<AudioSource>();
        _playerShoot = _playerAudioSource.clip;
        BlueKeyIsGrab = false;
        RedKeyIsGrab = false;
        GoldKeyIsGrab = false;
        _isMove = false;
        ammo = 20;
        bombAmmo = 5;
        _playerUI.AmmoChnge();
        _playerUI.BombChnge();
        _playerUI.HealhtChange();
    }
    void Update()
    {
        if (_isAlive)
        {
            OnGround();
            PlayerControl();
            Shooting();
            Bombing();
            Jump();
         }
    }
    private void PlayerControl()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        rotarion.y = Input.GetAxis("Mouse X");
        direction = direction.normalized;
        _forwardMovingStepTime += Time.deltaTime;

        if(direction != Vector3.zero)
        {
            _animator.SetBool("isMove", true);
            if (_forwardMovingStepTime >= 0.3f)
            {
                StepAudioPlay();
                _forwardMovingStepTime = 0;
            }

        }
        if (direction == Vector3.zero)
        {
            _animator.SetBool("isMove", false);
        }

            transform.Rotate(rotarion * _rotateSpeed * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * direction.z * _speed + transform.right * direction.x * _speed, ForceMode.Impulse);
    }
    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ammo > 0)
            {
                _playerAudioSource.PlayOneShot(_playerShoot);
                Instantiate(bullet, bulletSpawnPlace.transform.position, bulletSpawnPlace.transform.rotation, transform.parent);
                ammo--;
                _playerUI.AmmoChnge();
            }
            if (ammo <= 0)
            {
                Debug.Log("NO AMMO");
            }
        }
    }
    private void Bombing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (bombAmmo > 0)
            {
                Instantiate(bomb, bulletSpawnPlace.transform.position, transform.rotation);
                bombAmmo--;
                _playerUI.BombChnge();
            }
            if (ammo <= 0)
            {
                Debug.Log("NO BOMB");
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        _playerAudioSource.PlayOneShot(_playerDamage);
        _playerUI.HealhtChange();
        if (health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        _isAlive = false;
        _animator.SetBool("Dead", true);
        _playerAudioSource.PlayOneShot(_playerDeath);
        _pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        _pauseMenu._loosePanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&_isGround == true)
        {
            _playerAudioSource.PlayOneShot(_playerJump);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    private void OnGround()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f); 
        if (hit.collider == null)
        {
            _isGround = false;
        }
        else if(hit.collider.gameObject.tag == "level")
        {
            _isGround = true;
        }
    }
    private void StepAudioPlay()
    {
        if (_playerAudioSource.clip == _playerStepTwo)
        {
            _playerAudioSource.clip = _playerStepOne;
            _playerAudioSource.PlayOneShot(_playerStepOne);
        }
        else
        {
            _playerAudioSource.clip = _playerStepTwo;
            _playerAudioSource.PlayOneShot(_playerStepTwo);
        }
    }        

}

