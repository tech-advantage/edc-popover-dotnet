using edc_popover_dotnet.factory;
using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.gui;
using edc_popover_dotnet.src.internalImpl.gui.components;
using edc_popover_dotnet.src.internalImpl.model;
using edc_popover_dotnet.src.utils;
using edcClientDotnet;
using System.Windows;

namespace edc_popover_dotnet.src.internalImpl.factory
{
    public class HelpListenerFactory : IHelpListenerFactory
    {
        private readonly IEdcClient edcClient;
        private readonly IHelpConfiguration helpConfiguration;
        private readonly IContextualContentComponentBuilder<UIElement> contextualContentComponentBuilder;
        private readonly Popover popover;
        private readonly OpenUrlAction openUrlAction;
        private readonly IContextualTitleComponentBuilder<UIElement> contextualTitleComponentBuilder;

        public HelpListenerFactory(
            IEdcClient edcClient,
            IHelpConfiguration helpConfiguration,
            IContextualContentComponentBuilder<UIElement> contextualContentComponentBuilder,
            IContextualTitleComponentBuilder<UIElement> contextualTitleComponentBuilder,
            Popover popover,
            OpenUrlAction openUrlAction
            )
        {
            this.edcClient = edcClient;
            this.helpConfiguration = helpConfiguration;
            this.contextualContentComponentBuilder = contextualContentComponentBuilder;
            this.contextualTitleComponentBuilder = contextualTitleComponentBuilder;
            this.popover = popover;
            this.openUrlAction = openUrlAction;
        }


        public IHelpListener Create()
        {
            return new ActionButtonHandler(edcClient, helpConfiguration, contextualContentComponentBuilder, contextualTitleComponentBuilder, popover, openUrlAction);
        }

        

    }
}
