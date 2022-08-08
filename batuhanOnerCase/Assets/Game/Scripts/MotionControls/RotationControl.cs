
using System.Collections;
using Game.Scripts.AudioMenager;
using Game.Scripts.EventMenager;
using Game.Scripts.ItemMenager;
using Game.Scripts.ObstacleControls;
using Game.Scripts.Pattern;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.MotionControls
{
    public class RotationControl : Singleton<RotationControl>
    {
       
        [HideInInspector] public bool isTouchActive;
        [HideInInspector] public bool canRotate;
        private const int MaximumDecelerationAngle = 50;
        private const int MinimumDecelerationAngle = 0;
        private float _defaultAngularDrag;
        private bool _firstTouch;
        
        protected override void Awake()
        {
            MotionTouchEvents.AddMotionEvent(RotateTheObject);
        }

        private void Start()
        {
            _defaultAngularDrag = Item.Instance.currentUsedItemRigidbody.angularDrag;
            Item.Instance.currentUsedItemRigidbody.maxAngularVelocity = Item.Instance.currentTableObjectValues.specificMaxAngularVelocity;
        }

        private void RotateTheObject()
        {
            Item.Instance.currentUsedItemRigidbody.isKinematic = false;
            AudioController.Instance.RotationSoundStart();
            _firstTouch = true;
            canRotate = true;
            isTouchActive = true;
            StopAllCoroutines();
            StartCoroutine(nameof(StopRotate));

        }
        private IEnumerator StopRotate()
        {
            yield return new WaitForSeconds(Item.Instance.currentTableObjectValues.touchCancelWaitingTime);
            isTouchActive = false;
        }
        private void FixedUpdate()
        {
         
            var currentObjectRotationX = TransformUtils.GetInspectorRotation(Item.Instance.currentUsedItem.transform).x;
            if (!canRotate) return;
            if (isTouchActive)
            {
                DefaultRotationPhysics();
            }
            if (currentObjectRotationX is < MaximumDecelerationAngle and > MinimumDecelerationAngle && !isTouchActive)
            {
                ObstacleCollisionControl.EndCollisionObstaclePhysicsOpen();
                SpecificRotationPhysics();
            }
            else if (_firstTouch && !isTouchActive)
            {
                DefaultRotationPhysics();
            }
        }
        private void DefaultRotationPhysics()
        {
            Item.Instance.currentUsedItemRigidbody.angularDrag = _defaultAngularDrag;
            Item.Instance.currentUsedItemRigidbody.AddTorque(transform.right*Item.Instance.currentTableObjectValues.rotateSpeed *Time.deltaTime,ForceMode.Impulse);
            
        }
        private void SpecificRotationPhysics()
        {
            Item.Instance.currentUsedItemRigidbody.angularDrag = Item.Instance.currentTableObjectValues.specificAngularDrag;
            Item.Instance.currentUsedItemRigidbody.AddRelativeTorque(transform.right * (Item.Instance.currentTableObjectValues.rotateSpeed *Time.deltaTime * Item.Instance.currentTableObjectValues.specificLowRotateSpeed),ForceMode.Impulse);
        }
        
    }
}

