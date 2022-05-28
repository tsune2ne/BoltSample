using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace StateGraphSample
{ 
    public class EffectController : SingletonMonoBehaviour<EffectController>
    {
        [SerializeField] ParticleSystem hitEffect;
        [SerializeField] ParticleSystem guardEffect;
        [SerializeField] ParticleSystem guardBreakEffect;

        public void PlayHitEffect()
        {
            hitEffect.Stop();
            hitEffect.gameObject.SetActive(true);
            hitEffect.Play();
        }

        public void PlayGuardEffect()
        {
            guardEffect.Stop();
            guardEffect.gameObject.SetActive(true);
            guardEffect.Play();
        }

        public void PlayGuardBreakEffect()
        {
            guardBreakEffect.Stop();
            guardBreakEffect.gameObject.SetActive(true);
            guardBreakEffect.Play();
        }
    }
}