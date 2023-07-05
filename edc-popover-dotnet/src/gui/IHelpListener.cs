using System;

namespace edc_popover_dotnet.src.gui
{
    public interface IHelpListener : IMouseListener
    {
        void SetKeys(String mainKey, String subKey);
    }
}