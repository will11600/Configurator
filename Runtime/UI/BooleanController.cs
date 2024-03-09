using UnityEngine;
using UnityEngine.UI;
using Configurator.Attributes;

namespace Configurator.UI
{
    /// <summary>
    /// A controller for a <see cref="Toggle"/> that is bound to a <see cref="TunableAttribute"/> boolean value.
    /// </summary>
    public class BooleanController : MonoBehaviour
    {
        public string key;
        public Toggle toggle;
    
        private void OnEnable()
        {
            toggle.isOn = ControlPanel.GetValue<bool>(key);
    
            ControlPanel.OnChange += OnTunableChanged;
            toggle.onValueChanged.AddListener(OnUIChanged);
        }
    
        private void OnTunableChanged(Tunable tunable)
        {
            if (tunable.name != key) { return; }
            toggle.SetIsOnWithoutNotify((bool)tunable.Value);
        }
    
        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(OnUIChanged);
        }
    
        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnUIChanged);
        }
    
        private void OnUIChanged(bool arg0)
        {
            ControlPanel.SetValue(key, arg0, false);
        }
    }
}

