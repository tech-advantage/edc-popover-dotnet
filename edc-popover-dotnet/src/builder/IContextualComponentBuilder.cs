using edc_popover_dotnet.src.internalImpl.model;
using System;

namespace edc_popover_dotnet.src.builder
{
    public interface IContextualComponentBuilder<T>
    {
        /// <summary>
        ///     Define the keys for the component
        /// </summary>
        /// <param name="mainKey">the main key</param>
        /// <param name="subKey">the sub key</param>
        /// <param name="languageCode">the language code</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetKeys(String mainKey, String subKey, String languageCode);

        /// <summary>
        ///     Define the label for the component
        /// </summary>
        /// <param name="label">the label</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetLabel(String label);

        /// <summary>
        ///     Define the iconpath
        /// </summary>
        /// <param name="iconPath">the icon path to set</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetIconPath(String iconPath);

        /// <summary>
        ///     Define the icon dark mode path
        /// </summary>
        /// <param name="iconPath">the icon path to set</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetIconDarkModePath(String iconPath);


        /// <summary>
        ///     Define the error iconpath
        /// </summary>
        /// <param name="iconPath">the error icon path to set</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetErrorIconPath(String iconPath);

        /// <summary>
        ///     Define the error behavior
        /// </summary>
        /// <param name="errorBehavior">the error behavior to set</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetErrorBehavior(ErrorBehavior errorBehavior);

        /// <summary>
        ///     Define the icon state
        /// </summary>
        /// <param name="iconState">the icon state to set</param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetIconState(IconState iconState);

        /// <summary>
        ///     Enable darkMode
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetDarkMode(Boolean enable);

        /// <summary>
        ///     Enable the context item
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>the builder</returns>
        IContextualComponentBuilder<T> SetEnableContextItem(Boolean enable);

        /// <summary>
        ///     Define the visibility of tooltip label
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>true if enabled</returns>
        IContextualComponentBuilder<T> ShowTooltip(Boolean enable);

        /// <summary>
        ///     Build the contextual component.
        /// </summary>
        /// <returns>the contextual component</returns>
        T Build();
    }
}
