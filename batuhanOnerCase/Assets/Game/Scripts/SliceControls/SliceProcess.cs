using EzySlice;
using Game.Scripts.AudioMenager;
using Game.Scripts.EconomyControls;
using Game.Scripts.EffectMenegar;
using UnityEngine;

namespace Game.Scripts.SliceControls
{
    public class SliceProcess : MonoBehaviour
    {
        private Material _material;
        private GameObject _cutOff;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("cuttable")) return;
            GameObject cutOffObject;
            _material = (cutOffObject = other.gameObject).GetComponent<MeshRenderer>().material;
            _cutOff = cutOffObject;
            
            if (_cutOff == null) return;
            SlicedHull cutoff = Slicer(_cutOff, _material);
            
            GameObject cutOffUp = cutoff.CreateUpperHull(_cutOff, _material);
            CutOffAddComponent(cutOffUp);
            CutOffObjectPhysicEffect(cutOffUp, Vector3.right);
            
            GameObject cutOffLower = cutoff.CreateLowerHull(_cutOff, _material);
            CutOffAddComponent(cutOffLower);
            CutOffObjectPhysicEffect(cutOffLower, Vector3.left);
            SliceAfterEventsExecute();
        }

        private SlicedHull Slicer(GameObject cutOff, Material crossSectionMaterial = null)
        {
            var slicerTransform = transform;
            return cutOff.Slice(slicerTransform.position, slicerTransform.right,crossSectionMaterial);
        }
        private void CutOffAddComponent(GameObject cutOffObject)
        {
            cutOffObject.AddComponent<MeshCollider>().convex = true;
            var cutOffRigidbody = cutOffObject.AddComponent<Rigidbody>();
            cutOffRigidbody.useGravity = true;
            cutOffRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        }
        private void CutOffObjectPhysicEffect(GameObject cutOffObject,Vector3 vector)
        {
            cutOffObject.GetComponent<Rigidbody>().AddForce(vector*10,ForceMode.Impulse);
        }

        private void SliceAfterEventsExecute()
        {
            _cutOff.GetComponent<ObstacleEffect>().EffectStart();
            MoneyTextEffect.Instance.EffectExecute(_cutOff.transform,_cutOff.GetComponent<ObstacleEffect>());
            AudioController.Instance.SliceSoundStart();
            MoneyController.Instance.MoneyIncrease(_cutOff.GetComponent<ObstacleEffect>().effectTableObject.moneyWorth);
            Destroy(_cutOff);
        }
    }
}
