using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Controllers
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _fallDownParticleSystem;
        
        private List<Rigidbody> _rigidbodies = new();
        private List<RagdollData> _rigidbodyDatasTemp = new();
        private List<CharacterJoint> _characterJointsTemp = new();
        private Transform _thisTransform;
        void Start()
        {
            _thisTransform = GetComponent<Transform>();
            _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
        
            //Заполняем данные по Рагдолу
        
            for (int i=0; i < _rigidbodies.Count; i++)
            {
                var zev = new RagdollData();
                zev.transformRB = _rigidbodies[i].transform;
                zev.rigidbodyData = GetDataRigidbody(_rigidbodies[i]);
                if (_rigidbodies[i].transform.gameObject.TryGetComponent<CharacterJoint>(out var joint))
                {
                    zev.joint = GetJointData(joint);
                    _characterJointsTemp.Add(joint);
                }
                _rigidbodyDatasTemp.Add(zev);
            }
        
            //Удаляем Рагдолл
            DestroyRagDoll();
        }

        private void DestroyRagDoll()
        {
            foreach (var joint in _characterJointsTemp)
            {
                Destroy(joint);
            }

            foreach (var rigid in _rigidbodies)
            {
                Destroy(rigid);
            }
            _characterJointsTemp.Clear();
            _rigidbodies.Clear();
        }

   

        public void AddRagDoll()
        {
            for(int i=0; i< _rigidbodyDatasTemp.Count;i++)
            {
            
                if (!TryGetComponent<Rigidbody>(out var rigid))
                    rigid = _rigidbodyDatasTemp[i].transformRB.gameObject.AddComponent<Rigidbody>();
                _rigidbodyDatasTemp[i].rigidbodyData.rigidBody = rigid;
                rigid.mass = _rigidbodyDatasTemp[i].rigidbodyData.mass;
                rigid.angularDrag = _rigidbodyDatasTemp[i].rigidbodyData.angularDrag;
                rigid.useGravity = true;
                rigid.isKinematic = false;
                rigid.detectCollisions = true;
          
                if (_rigidbodyDatasTemp[i].joint !=null && _rigidbodyDatasTemp[i].joint.needJoint)
                {
                    var joi = _rigidbodyDatasTemp[i].transformRB.gameObject.AddComponent<CharacterJoint>();
                    _rigidbodyDatasTemp[i].joint.characterJoint = joi;
                    joi.connectedBody = _rigidbodyDatasTemp[i].joint.connectedBody.GetComponent<Rigidbody>();
                    joi.axis = _rigidbodyDatasTemp[i].joint.axis;
                    joi.connectedAnchor =_rigidbodyDatasTemp[i].joint.connectedAncor; 
                    joi.swingAxis = _rigidbodyDatasTemp[i].joint.swingAxis;
                    SoftJointLimit limit = default;
                    limit.limit = _rigidbodyDatasTemp[i].joint.lowTwistLimitSpring;
                    joi.lowTwistLimit = limit;
                    limit.limit = _rigidbodyDatasTemp[i].joint.hightTwistLimitSpring;
                    joi.highTwistLimit = limit;
                    limit.limit = _rigidbodyDatasTemp[i].joint.swingOneLimitLimitSpring;
                    joi.swing1Limit = limit;
                }
            }
        
            //"Прячем" объект для нового возвращения на стадию
        
            StartCoroutine(SetNonActive());
        }

        public void AddForce(Vector3 direction)
        {
            var randomRB = Random.Range(0, _rigidbodyDatasTemp.Count);
            _rigidbodyDatasTemp[randomRB].transformRB.GetComponent<Rigidbody>().AddForce(direction,ForceMode.Impulse);
        }
    
        public virtual IEnumerator SetNonActive()
        {
            GameController.instance.enemyDead.Invoke();
            yield return new WaitForSeconds(5f);
            foreach (var rb in _rigidbodyDatasTemp)
            {
                if (rb.joint!=null)
                    Destroy(rb.joint.characterJoint);
                Destroy(rb.rigidbodyData.rigidBody);
            }
        
            //Включаем пыль, двигаем объект за карту и выключаем его
            _fallDownParticleSystem.Play();
            while (_thisTransform.position.z <=2)
            {
                _thisTransform.position+=Vector3.forward*0.1f;
                yield return new WaitForSeconds(0.01f);
            }
            _fallDownParticleSystem.Stop();
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
        }
    
        private RigidbodyData GetDataRigidbody(Rigidbody rb)
        {
            var rbd = new RigidbodyData();
            rbd.mass = rb.mass;
            rbd.angularDrag = rb.angularDrag;
            return rbd;
        }
    
        private JointData GetJointData(CharacterJoint joint)
        {
            var data = new JointData();
            data.needJoint = true;
            data.connectedBody = joint.connectedBody.transform;
            data.axis = joint.axis;
            data.connectedAncor = joint.connectedAnchor;
            data.swingAxis = joint.swingAxis;
            data.lowTwistLimitSpring = joint.lowTwistLimit.limit;
            data.hightTwistLimitSpring = joint.highTwistLimit.limit;
            data.swingOneLimitLimitSpring = joint.swing1Limit.limit;
            return data;
        }
    
        [Serializable]
        private class RagdollData
        {
            public Transform transformRB ;
            public JointData joint;
            public RigidbodyData rigidbodyData;
        }
        private class RigidbodyData
        {
            public Rigidbody rigidBody;
            public float mass;
            public float angularDrag;
        }
    
        private class JointData
        {
            public bool needJoint = false;
            public CharacterJoint characterJoint;
            public Transform connectedBody;
            public Vector3 axis, connectedAncor,swingAxis;
            public float swingOneLimitLimitSpring, lowTwistLimitSpring, hightTwistLimitSpring;
        }
    
    }
}

