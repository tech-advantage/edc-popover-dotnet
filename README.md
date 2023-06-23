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
| Hover display popover | ``SetHoverDisplayPopover`` |false| Display the popover when the mouse is over it |
| Separator | ``SetSeparatorDisplay`` | true | Display the separator in the help header |
| Header title color | ``SetHeaderTitleColor`` | BLACK | Color of the title in the header of the help dialog |
| Background color | ``SetBackgroundColor`` | WHITE | Background color of the help dialog |
| Separator color | ``SetSeparatorColor`` | #3C8DBC | Separator color of the help dialog |
| Font attributes | ``SetPopoverSectionTitleFont`` | new FontAttributes(new FontFamily("Arial"), 14, FontWeights.Bold) | Font attributes of the popover section title |
| Title color | ``SetPopoverSectionTitleColor`` | BLACK | Color of the popover section title in the help dialog |
| Close Icon | ``SetCloseIconPath`` | popover/close1.png | The close icon display in the summary dialog |
| Error Icon | ``SetErrorIconPath`` | icons/icon_exclamation-32px.png | The error icon displays in the component |
| Popover placement | ``SetPopoverPlacement`` | TOP, RIGHT, BOTTOM, LEFT | Set the position of popover |
| Error behavior | ``SetErrorBehavior`` | ERROR_SHOWN, FRIENDLY_MSG, NO_POPOVER | Set the error behavior of popover |
| Icon state | ``SetIconState`` | ERROR, SHOWN, HIDDEN, DISABLED | Set the icon behavior of popover |
| Title | ``SetTitleDisplay`` | true | Display the title in the help dialog |
| Related topics display | ``SetRelatedTopicsDisplay`` | true | Enable the related topics |
| Article display | ``SetArticleDisplay`` | true | Enable the article |
| HelpViewer | ``SetHelpViewer`` | SYSTEM_BROWSER | EDC_DESKTOP_VIEWER |

### with injection

Based on Microsoft DependencyInjection, you need to call the ConfigureServices method from edcClientDotnet, then get the services static variable of type IServiceCollection type from edcClientDotnet and set it to the ConfigureService method of edcPopoverDotnet. 
```.NET

String viewerDesktopPath = "";
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
else
{
    edcClient.SetServerUrl(serverUrl);
}

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
String serverUrl = "https://demo.easydoccontents.com";

edcHelp = EdcHelpSingletonGui.GetInstance();
edcClient = EdcHelpSingletonGui.GetInstance().GetEdcClient();

if (!String.IsNullOrEmpty(viewerDesktopServerURL) && !String.IsNullOrEmpty(viewerDesktopPath))
{
    edcDesktop = edc_popover_dotnet.injection.Startup.serviceProvider.GetRequiredService<IDesktopProcess>();
    edcDesktop.ConfigureDesktopProcess(edcHelp, edcClient, viewerDesktopPath, viewerDesktopServerURL);
}
else
{
    EdcHelpSingletonGui.GetInstance().GetEdcClient().SetServerUrl(serverUrl);
}

```  

To change the icon path and the default language
```.NET
EdcHelpSingletonGui.GetInstance().SetIconPath("my-icon.png");
EdcHelpSingletonGui.GetInstance().SetLanguageCode("fr");
EdcHelpSingletonGui.GetInstance().SetTooltipLabel("edc Help");
EdcHelpSingletonGui.GetInstance().SetPopoverDisplay(true);
EdcHelpSingletonGui.GetInstance().SetBackgroundColor(Color.BLUE);
EdcHelpSingletonGui.GetInstance().SetCloseIconPath("popover/close2.png");
```

### Config desktop help viewer

If you want to use the desktop viewer, you have to set the viewerDesktopPath and viewerDesktopServerURL :
```.NET
  String viewerDesktopPath = "Here the path of desktop help viewer";
  If you are using a custom server for the viewer desktop, set EdcHelpSingletonGui.GetInstance().SetViewerDesktopServerURL(Set the server url here); <--- Default server: http://localhost:60000
```
And replace to the help configuration HelpViewer.SYSTEM_BROWSER by HelpViewer.EDC_DESKTOP_VIEWER
```.NET
  EdcHelpSingletonGui.GetInstance().SetHelpViewer(HelpViewer.EDC_DESKTOP_VIEWER);
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
    "links": "Related topics"
  }
}
```

You can find a simple implementation in the example section below

## Example
To see this utility in action, just run this example

## License

MIT [TECH'advantage](mailto:contact@tech-advantage.com)