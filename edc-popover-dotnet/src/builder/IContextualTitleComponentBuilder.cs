using System;
using System.Windows.Media;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using edc_popover_dotnet.src.internalImpl.model;
using edcClientDotnet.model;
using Brush = System.Windows.Media.Brush;

namespace edc_popover_dotnet.src.builder
{
    public interface IContextualTitleComponentBuilder<T>
    {
        /// <summary>
        ///     Define the context item for the component
        /// </summary>
        /// <param name="contextItem">the context item</param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetContextItem(IContextItem? contextItem);

        /// <summary>
        ///     Define the rgb color for the background
        /// </summary>
        /// <param name="rgbColor">the rgb color</param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetBackgroundColor(Brush rgbColor);

        /// <summary>
        ///     Define the header title color
        /// </summary>
        /// <param name="titleColor"></param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetHeaderTitleColor(SolidColorBrush titleColor);

        /// <summary>
        ///     Define the font attributes of the header title
        /// </summary>
        /// <param name="fontAttr"></param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetHeaderFontAttributes(FontAttributes fontAttr);

        /// <summary>
        ///     Show the title
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetShowTitle(bool enable);

        /// <summary>
        ///     Define the error behavior
        /// </summary>
        /// <param name="errorBehavior"></param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetErrorBehavior(ErrorBehavior errorBehavior);

        /// <summary>
        ///     Define the language code
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>the builder</returns>
        IContextualTitleComponentBuilder<T> SetLanguageCode(String languageCode);

        IContextualTitleComponentBuilder<T> SetRectangleSeparator(bool enable);

        IContextualTitleComponentBuilder<T> SetRectangleSeparatorColor(Brush color);

        /// <summary>
        ///     Build the contextual title component.
        /// </summary>
        /// <returns>the contextual component</returns>
        T Build();
    }
}
