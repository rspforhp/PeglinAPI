using System;
using UnityEngine;

namespace API
{
    public class OrbBuilder
    {
        public OrbBuilder()
        {
            _info = new OrbInfo(this);
        }

        private OrbInfo _info;

        public class OrbInfo
        {
            public OrbInfo(OrbBuilder instance) : base()
            {
                if (instance == null )
                {
                    throw (new Exception("This is not how you supposed to instantiate this, use OrbBuilder instead"));
                }
            }

            public string name;
            public float damage;
            public float critDamage;
            public OrbInfo nextLevel;
            public string description;
        }

        public OrbBuilder WithName(string name)
        {
            _info.name = name;
            return this;
        }
        public OrbBuilder WithDescription(string description)
        {
            _info.description = description;
            return this;
        }
        public OrbBuilder WithDamage(int dmg)
        {
            _info.damage = dmg;
            return this;
        }
        public OrbBuilder WithCriticalDamage(int dmg)
        {
            _info.critDamage = dmg;
            return this;
        }
        public OrbBuilder WithNextLevel(OrbInfo info)
        {
            _info.nextLevel = info;
            return this;
        }

        public (OrbInfo, GameObject) Build()
        {
            GameObject gameObject = new GameObject();
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            gameObject.SetActive(false);
            gameObject.AddComponent<ActivateOnCreate>();
            var attack=gameObject.AddComponent<Attack>();
            attack.locNameString = _info.name;
            attack.locDescStrings = new[] { _info.description };
            Plugin.allOrbs.Add(_info, gameObject);
            return (_info,gameObject);
        }
    }
}