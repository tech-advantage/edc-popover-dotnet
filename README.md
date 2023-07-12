# edc-popover-dotnet
To use edc publication in your .NET application, you can use this utility.

## edc Version

Current release is compatible with edc v3.0+

## Configuration 

We will be able to configure the url to get the documentation and the widget properties.

| Properties | Method | Default | Description |
|--|--|--|--|
| Icon Path| ``SetIconPath`` | icons/icon-32px.png| The help icon displays in the component |
| Language Code | ``SetLanguageCode`` | en | The help language code |
| Tooltip | ``SetTooltipLabel`` | '' | The tooltip displays on the help icon |
| DarkMode | ``SetDarkMode`` | false | Enable the dark mode for icon |
| IconDarkModePath | ``SetIconDarkModePath`` | icons/icon2-32px.png | The help icon dark displays in the component |
| Tooltip display | ``SetTooltipDisplay`` | true | Display the tooltip on the help icon and close icon in popover |
| Popover Help | ``SetPopoverDisplay`` | false | Display the help summary dialog |
| Hover display popover | ``SetHoverDisplayPopover`` | false | Display the popover when the mouse is over it |
| Separator | ``SetSeparatorDisplay`` | true | Display the separator in the help header |
| Background color | ``SetBackgroundColor`` | WHITE | Background color of the help dialog |
| Separator color | ``SetSeparatorColor`` | #3C8DBC | Separator color of the help dialog |
| Font attributes | ``SetHeaderTitleFontAttributes`` | new FontAttributes(new FontFamily("Arial"), 14, FontWeights.Bold) | Font attributes of Popover main title in the header of the help dialog |
| Header title color | ``SetHeaderTitleColor`` | BLACK | Color of Popover main title in the header of the help dialog |
| Font attributes | ``SetPopoverDescriptionFont`` | new FontAttributes(new FontFamily("Arial"), 14, FontWeights.Bold) | Font attributes of Popover description of the help dialog |
| Popover description color | ``SetPopoverDescriptionColor`` | BLACK | Color of Popover description of the help dialog |
| Font attributes | ``SetPopoverSectionTitleFont`` | new FontAttributes(new FontFamily("Arial"), 14, FontWeights.Bold) | Font attributes of the popover section title ("Need more" | "Related topics") in the help dialog |
| Title color | ``SetPopoverSectionTitleColor`` | BLACK | Color of the popover section title ("Need more" & "Related topics") in the help dialog |
| Font attributes | ``SetPopoverLinksFont`` | new FontAttributes(new FontFamily("Arial"), 14, FontWeights.Normal) | Font attributes of Popover links of the help dialog |
| Popover links color | ``SetPopoverLinksColor`` | BLUE | Color of Popover links of the help dialog |
| Close Icon | ``SetCloseIconPath`` | popover/close1.png | The close icon display in the summary dialog |
| Error Icon | ``SetErrorIconPath`` | icons/icon_exclamation-32px.png | The error icon displays in the component |
| Popover placement | ``SetPopoverPlacement`` | TOP, RIGHT, BOTTOM, LEFT | Set the position of popover |
| Error behavior | ``SetErrorBehavior`` | ERROR_SHOWN, FRIENDLY_MSG, NO_POPOVER | Set the error behavior of popover |
| Icon state | ``SetIconState`` | ERROR, SHOWN, HIDDEN, DISABLED | Set the icon behavior of popover |
| Title | ``SetTitleDisplay`` | true | Display the title in the help dialog |
| Related topics display | ``SetRelatedTopicsDisplay`` | true | Enable the related topics |
| Article display | ``SetArticleDisplay`` | true | Enable the article |
| HelpViewer | ``SetHelpViewer`` | SYSTEM_BROWSER | EDC_DESKTOP_VIEWER |
| Desktop Viewer | ``SetViewerDesktopServerURL`` | http://localhost:60000 | Define the desktop viewer url |
| Desktop Viewer | ``SetViewerDesktopWidth`` | 1900 | Define the desktop viewer width |
| Desktop Viewer | ``SetViewerDesktopHeight`` | 1200 | Define the desktop viewer height |

### with injection

Based on Microsoft DependencyInjection, you need to call the ConfigureServices method from edcClientDotnet, then get the services static variable of type IServiceCollection type from edcClientDotnet and set it to the ConfigureService method of edcPopoverDotnet. 
```.NET

String viewerDesktopPath = "";

HelpViewer helpViewerMode = HelpViewer.SYSTEM_BROWSER;
String serverUrl = "https://demo.easydoccontents.com";


edcClientDotnet.Injection.Startup.ConfigureServices();
IServiceCollection services = edcClientDotnet.Injection.Startup.services;
edc_popover_dotnet.injection.Startup.ConfigureServices(services);

edcHelp = edc_popover_dotnet.injection.Startup.serviceProvider.GetRequiredService<IEdcHelpGui>();
edcClient = edc_popover_dotnet.injection.Startup.serviceProvider.GetRequiredService<IEdcClient>();

if (!String.IsNullOrEmpty(viewerDesktopServerURL) && !String.IsNullOrEmpty(viewerDesktopPath))
{
    edcDesktop = edc_popover_dotnet.injection.Startup.serviceProvider.GetRequiredService<IDesktopProcess>();
    edcDesktop.ConfigureDesktopProcess(edcHelp, edcClient, viewerDesktopPath, viewerDesktopServerURL);
}

edcClient.SetServerUrl(serverUrl);

Example example = new Example(edcHelp);
example.Configure();
```

```.NET
public class Example
    {
        private IEdcHelpGui help;

        public Example(IEdcHelpGui help) { 
            this.help = help;
        }

        public void Configure()
        {
            help.SetTooltipLabel("Help");
            help.SetBackgroundColor(Brushes.White);
            help.SetLanguageCode("en");
            help.SetIconState(IconState.SHOWN);
            help.SetSeparatorColor(Brushes.Red);
            help.SetErrorBehavior(ErrorBehavior.FRIENDLY_MSG);
            help.SetHelpViewer(HelpViewer.SYSTEM_BROWSER);
            help.SetIconDarkModePath("icons/icon2-32px.png");
            help.SetIconPath("icons/icon-32px.png");
            help.SetCloseIconPath("popover/close.png");
        }
    }
```

### with Singleton

To define the server url:  
```.NET
String viewerDesktopPath = "";

HelpViewer helpViewerMode = HelpViewer.SYSTEM_BROWSER;
String serverUrl = "https://demo.easydoccontents.com";

edcHelp = EdcHelpSingletonGui.GetInstance();
edcClient = EdcHelpSingletonGui.GetInstance().GetEdcClient();

if (!String.IsNullOrEmpty(viewerDesktopServerURL) && !String.IsNullOrEmpty(viewerDesktopPath))
{
    edcDesktop = edc_popover_dotnet.injection.Startup.serviceProvider.GetRequiredService<IDesktopProcess>();
    edcDesktop.ConfigureDesktopProcess(edcHelp, edcClient, viewerDesktopPath, viewerDesktopServerURL);
}

EdcHelpSingletonGui.GetInstance().GetEdcClient().SetServerUrl(serverUrl);

```  

To change the icon path and the default language
```.NET
EdcHelpSingletonGui.GetInstance().SetIconPath("my-icon.png");
EdcHelpSingletonGui.GetInstance().SetLanguageCode("fr");
EdcHelpSingletonGui.GetInstance().SetTooltipLabel("edc Help");
EdcHelpSingletonGui.GetInstance().SetPopoverDisplay(true);
EdcHelpSingletonGui.GetInstance().SetBackgroundColor(Color.WHITE);
EdcHelpSingletonGui.GetInstance().SetCloseIconPath("popover/close2.png");
```

### Config desktop viewer

If you want to use the desktop viewer, you should define the path
```
HelpViewer helpViewerMode = HelpViewer.EDC_DESKTOP_VIEWER;
...
EdcHelpSingletonGui.GetInstance().SetHelpViewer(helpViewerMode);
EdcHelpSingletonGui.GetInstance().SetViewerDesktopPath("Define the path here");
```

If you want to configure the size of edc viewer desktop window, you should define the size with this method before the configureDesktop method
```
EdcHelpSingletonGui.GetInstance().SetViewerDesktopWidth(1000);
EdcHelpSingletonGui.GetInstance().SetViewerDesktopHeight(800);
```
The default port is 60000, if you changed the port on the edc-desktop-viewer electron configuration, apply the new desktop server url with this method :
```
EdcHelpSingletonGui.GetInstance().SetViewerDesktopServerURL("Define the desktop server path here");
```


## Add the contextual button

By default, this engine create a button with icon.
On clic, the system browser is open and the documentation is displayed.

To create the component, you just need to 

### with Singleton

Get the instance of ``EdcHelpSingletonGui`` and call the method ``CreateComponent`` with two parameters : the main and sub key, you are defined in the brick  

```.NET
EdcHelpSingletonGui.GetInstance().CreateComponent("fr.techad.edc", "help.center");
```

## Add the contextual button with a customized icon

If you want to change the default icon for some button, you can call the createComponent method and set the icon path.

### with Singleton

Get the instance of ``EdcHelpSingletonGui`` and call the method ``CreateComponent`` with 3 parameters : the main and sub key, you are defined in the brick and the icon path 

```.NET
EdcHelpSingletonGui.GetInstance().CreateComponent("fr.techad.edc", "help.center", "popover/close1.png");
```

## Fail behavior
You can customize the popover's behavior when an error occurs with the following property:
 - `SHOWN` The help icon is shown as usual
 - `DISABLED` The help icon is greyed out
 - `HIDDEN` The help icon is completely hidden
 - `ERROR` The help icon is replaced by an exclamation point

For the popover when an error occurs:
 - `ERROR_SHOWN` An error message is shown in the popover
 - `FRIENDLY_MSG` A friendly and translated message is shown in the popover
 - `NO_POPOVER` No popover appears when the help icon is triggered

By default, the icon is `SHOWN` and the popover is set to `FRIENDLY_MSG`.


## Language selection
You can set the language for the content and the popover labels by calling the method ``SetLanguageCode`` (see the Example section below).

Label translations can be modified in the associated i18n json files, present in the documentation export (at [yourDocPath]/popover/i18n/ (*.json)).

There is one file per language (see file structure below), and files should be named following the ISO639-1 two letters standards 
(ie en.json, it.json...).

As an example, here is the en.json file used by default:

```json
{
  "labels": {
    "articles": "Need more...",
    "links": "Related topics",
    "iconAlt": "Help",
    "comingSoon": "Contextual help is coming soon.",
    "errorTitle":  "Error"
  },
  "errors": {
    "failedData": "An error occurred when fetching data !\nCheck the brick keys provided to the EdcHelp component."
  }
}
```

You can find a simple implementation in the example section below

## Example
To see this utility in action, just run this example the edc-popover-dotnet-example-app

## License

MIT [TECH'advantage](mailto:contact@tech-advantage.com)