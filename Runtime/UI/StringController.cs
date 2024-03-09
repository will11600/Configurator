using UnityEngine.UI;
using Configurator.Attributes;

namespace Configurator.UI
{
    /// <summary>
    /// A controller for an <see cref="InputField"/> that is bound to a <see cref="TunableAttribute"/> string value.
    /// </summary>
    internal class StringController
    {
        public string key;
        public InputField input;

        private void OnEnable()
        {
            input.text = ControlPanel.GetValue<string>(key);

            ControlPanel.OnChange += OnTunableChanged;
            input.onValueChanged.AddListener(OnUIChanged);
        }

        private void OnTunableChanged(Tunable tunable)
        {
            if (tunable.name != key) { return; }
            input.SetTextWithoutNotify((string)tunable.Value);
        }

        private void OnDisable()
        {
            input.onValueChanged.RemoveListener(OnUIChanged);
        }

        private void OnDestroy()
        {
            input.onValueChanged.RemoveListener(OnUIChanged);
        }

        private void OnUIChanged(string arg0)
        {
            ControlPanel.SetValue(key, arg0, false);
        }
    }
}
