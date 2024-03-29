using edc_popover_dotnet.src.builder;
using edc_popover_dotnet.src.Gui;
using edc_popover_dotnet.src.internalImpl.factory;
using edc_popover_dotnet.src.internalImpl.gui;
using edc_popover_dotnet.src.internalImpl.gui.builder;
using edc_popover_dotnet.src.internalImpl.model;
using edc_popover_dotnet.src.internalImpl.gui.components;
using edc_popover_dotnet.src.utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using edc_popover_dotnet.src.desktop;
using edc_popover_dotnet.src.internalImpl.desktop;
using edc_popover_dotnet.factory;
using edc_popover_dotnet.src;
using edc_popover_dotnet.src.internalImpl;

namespace edc_popover_dotnet.injection
{
    public static class Startup
    {
        public static IServiceProvider? serviceProvider;

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHelpConfiguration, HelpConfigurationImpl>();
            services.AddTransient<IContextualComponentBuilder<UIElement>, ContextualComponentBuilderImpl>();
            services.AddTransient<IContextualContentComponentBuilder<UIElement>, ContextualContentComponentBuilderImpl>();
            services.AddTransient<IContextualTitleComponentBuilder<UIElement>, ContextualTitleComponentBuilderImpl>();
            services.AddTransient<IHelpListenerFactory, HelpListenerFactory>();
            services.AddSingleton<IEdcHelpGui, EdcHelpGuiImpl>();
            services.AddSingleton<IEdcDesktop, EdcDesktopImpl>();
            services.AddSingleton<IHttpRestRequest, HttpRestRequestImpl>();
            services.AddSingleton<Popover>();
            services.AddScoped<OpenUrlAction>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
