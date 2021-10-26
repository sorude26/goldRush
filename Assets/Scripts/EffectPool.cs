using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    None,
    CoinHit,
    CoinBreak,
    Explosion,
    Hit,
}
public class EffectPool : MonoBehaviour
{
    public static EffectPool Instance { get; private set; }
    [SerializeField]
    ParticleSystem[] m_effectPrefab = default;
    [SerializeField]
    int[] m_effectCount = default;
    Dictionary<EffectType,ParticleSystem[]> m_allEffect = default;
    private void Awake()
    {
        Instance = this;
        m_allEffect = new Dictionary<EffectType, ParticleSystem[]>();
        if (m_effectPrefab.Length > m_effectCount.Length)
        {
            Debug.LogError("êîó ê›íËïsë´");
            return;
        }
        for (int i = 0; i < m_effectPrefab.Length; i++)
        {
            EffectType effectType = (EffectType)(i + 1);
            m_allEffect.Add(effectType, new ParticleSystem[m_effectCount[i]]);
            for (int k = 0; k < m_effectCount[i]; k++)
            {
                var instance = Instantiate(m_effectPrefab[i], this.transform);
                m_allEffect[effectType][k] = instance;
                instance.gameObject.SetActive(false);
            }
        }
    }
    public void PlayEffect(EffectType effectType, Vector3 pos)
    {
        if (effectType == EffectType.None)
        {
            return;
        }
        foreach (var effect in m_allEffect[effectType])
        {
            if (effect.gameObject.activeSelf)
            {
                continue;
            }
            effect.transform.position = pos;
            effect.gameObject.SetActive(true);
            effect.Play();
            return;
        }
    }
    public void DestroyAll()
    {
        for (int i = 0; i < m_effectPrefab.Length; i++)
        {
            EffectType effectType = (EffectType)i;
            for (int k = 0; k < m_effectCount[i]; k++)
            {
                Destroy(m_allEffect[effectType][k].gameObject);
                m_allEffect[effectType][k] = null;
            }
        }
    }
}
