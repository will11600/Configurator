using UnityEngine.UI;
using Configurator.Attributes;

namespace Configurator.UI
{
    /// <summary>
    /// A controller for a <see cref="Slider"/> that is bound to a <see cref="TunableAttribute"/> float value.
    /// </summary>
    public class FloatController
    {
        public string key;
        public Slider slider;

        private void OnEnable()
        {
            slider.value = ControlPanel.GetValue<float>(key);

            ControlPanel.OnChange += OnTunableChanged;
            slider.onValueChanged.AddListener(OnUIChanged);
        }

        private void OnTunableChanged(Tunable tunable)
        {
            if (tunable.name != key) { return; }
            slider.SetValueWithoutNotify((float)tunable.Value);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnUIChanged);
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(OnUIChanged);
        }

        private void OnUIChanged(float arg0)
        {
            ControlPanel.SetValue(key, arg0, false);
        }
    }
}
