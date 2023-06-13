using edcClientDotnet.model;
using edc_popover_dotnet.src.internalImpl.model;
using System;
using Brush = System.Windows.Media.Brush;
using edc_popover_dotnet.src.internalImpl.gui.tools;
using System.Windows.Media;

namespace edc_popover_dotnet.src.builder
{
    public interface IContextualContentComponentBuilder<T>
    {
        /// <summary>
        ///     Define the context item for the component
        /// </summary>
        /// <param name="contextItem">the context item</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetContextItem(IContextItem? contextItem);

        /// <summary>
        ///     Define the rgb color for the background
        /// </summary>
        /// <param name="rgbColor">the rgb color</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetBackgroundColor(Brush rgbColor);

        /// <summary>
        ///     Define the error behavior
        /// </summary>
        /// <param name="errorBehavior">the error behavior</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetErrorBehavior(ErrorBehavior errorBehavior);

        /// <summary>
        ///     Define the language code
        /// </summary>
        /// <param name="languageCode">the language code</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetLanguageCode(String languageCode);

        /// <summary>
        ///     Enable the related topics display
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> EnableRelatedTopics(Boolean enable);

        /// <summary>
        ///     Define the article title color
        /// </summary>
        /// <param name="titleColor">the title color</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetPopoverSectionTitleColor(SolidColorBrush titleColor);

        /// <summary>
        ///     Define the font attributes of article title
        /// </summary>
        /// <param name="fontAttr">the font attribute</param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> SetPopoverSectionTitleFont(FontAttributes fontAttr);

        /// <summary>
        ///     Enable the article display
        /// </summary>
        /// <param name="enable"></param>
        /// <returns>the builder</returns>
        IContextualContentComponentBuilder<T> EnableArticle(Boolean enable);

        /// <summary>
        ///     Build the contextual component.
        /// </summary>
        /// <returns>the contextual component</returns>
        T Build();
    }
}
