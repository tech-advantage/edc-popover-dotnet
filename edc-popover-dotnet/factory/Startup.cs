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

namespace edc_popover_dotnet.factory
{
    public static class Startup
    {
        public static IServiceProvider? serviceProvider;

        public static void ConfigureServices()
        {
            edcClientDotnet.Injection.Startup.ConfigureServices();
            var services = edcClientDotnet.Injection.Startup.services;
            
            services.AddSingleton<IHelpConfiguration, HelpConfigurationImpl>();
            services.AddTransient<IContextualComponentBuilder<UIElement>, ContextualComponentBuilderImpl>();
            services.AddTransient<IContextualContentComponentBuilder<UIElement>, ContextualContentComponentBuilderImpl>();
            services.AddTransient<IContextualTitleComponentBuilder<UIElement>, ContextualTitleComponentBuilderImpl>();
            services.AddTransient<IHelpListenerFactory, HelpListenerFactory>();
            services.AddSingleton<IEdcHelpGui, EdcHelpGuiImpl>();
            services.AddSingleton<IDesktopProcess, EdcDesktopProcess>();
            services.AddSingleton<Popover>();
            services.AddScoped<OpenUrlAction>();  

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
