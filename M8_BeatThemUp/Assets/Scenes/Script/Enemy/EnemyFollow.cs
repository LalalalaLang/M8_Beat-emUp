using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FollowPlayer
{
    [RequireComponent(typeof(Rigidbody))]

    public class EnemyFollow : MonoBehaviour

    {
        private Transform _transform;
        private Rigidbody _rigidbody;

        public float _moveSpeed = default;

        public float _rotatSpeed = default;

        [SerializeField]
        private Transform _playerTransform;


        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            _playerTransform = GameObject.Find("Player").transform;
        }

        private void FixedUpdate()
        {
            TurnTowardsPlayer();//méthode tourner l'ennemi vers le joueur
            
            MoveForward();//méthode avancer progressivement l'ennemi vers le joueur.
        }


        // Faire tourner l'ennemi vers le joueur
        private void TurnTowardsPlayer()
        {
            Vector3 directionToPlayer = (_playerTransform.position - _transform.position).normalized;

            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

            Quaternion rotation = Quaternion.RotateTowards(_transform.rotation, rotationToPlayer, _rotatSpeed * Time.fixedDeltaTime);

            _rigidbody.MoveRotation(rotation);
        }

        // Faire avancer l'ennemi tout droit
        private void MoveForward()
        {
            Vector3 velocity = _transform.forward * _moveSpeed;
            _rigidbody.velocity = velocity;
        }
    }
}