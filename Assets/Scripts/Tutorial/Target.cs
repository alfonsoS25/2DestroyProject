using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager _gameManager;

    private ParticleManager _particleManager;

    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _id;

    private Rigidbody2D _rig;
    void Start()
    {
        _rig = gameObject.GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        _particleManager = GameObject.FindGameObjectWithTag("ParticleManager").gameObject.GetComponent<ParticleManager>();
        _id = _gameManager.getTargetID;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("aweno"))
        {
            for (int i = 0; i < 3; i++)
            {
                var thisSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                GameObject BrokenBlock = _particleManager.GetPooledObject();

                if (BrokenBlock != null)
                {
                    BrokenBlock.GetComponent<SpriteRenderer>().sprite = _sprite;
                    BrokenBlock.transform.position = transform.position;
                    BrokenBlock.transform.rotation = BrokenBlock.transform.rotation;
                    BrokenBlock.SetActive(true);
                    var RigAttach = BrokenBlock.GetComponent<Rigidbody2D>();
                    RigAttach.velocity = _rig.velocity;
                    RigAttach.angularDrag = _rig.angularVelocity;
                }
            }
            _gameManager.targetCounter++;
            _gameManager.StartCoroutine(_gameManager.targetDestroyed());
            Destroy(this.gameObject);
        }
    }
}
