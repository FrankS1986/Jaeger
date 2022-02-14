using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
              
            }
            else
            {
                // Create run time view services and models
          
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Logic_Abschussliste>();
            SimpleIoc.Default.Register<Logic_Wildunfaelle>();
            SimpleIoc.Default.Register<Logic_PasswortErneuern>();

            SimpleIoc.Default.Register<Logic_Jaeger_Informationen>();

            SimpleIoc.Default.Register<Logic_Jaeger_Hinzufuegen>();

            SimpleIoc.Default.Register<Logic_Jaeger_Bearbeiten>();
            SimpleIoc.Default.Register<Logic_EinladungErstellen>();
            SimpleIoc.Default.Register<Logic_Einladungsuebersicht>();
            SimpleIoc.Default.Register<Logic_Login>();

            SimpleIoc.Default.Register<Logic_Sicherheitsfrage_zuruecksetzen>();
            SimpleIoc.Default.Register<Logic_Abschussliste>();

            SimpleIoc.Default.Register<Logic_Registrierung>();
            SimpleIoc.Default.Register<UrkundeErstellenViewModel>();
            SimpleIoc.Default.Register<Logic_AbschusslisteAktualisieren>();
            SimpleIoc.Default.Register<Logic_PasswortAendern>();
            SimpleIoc.Default.Register<Logic_NeuesPasswort>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public Logic_Abschussliste logic_abschussliste => ServiceLocator.Current.GetInstance<Logic_Abschussliste>();
          public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public Logic_Wildunfaelle logic_wildunfaelle => ServiceLocator.Current.GetInstance<Logic_Wildunfaelle>();
        
        public Logic_PasswortErneuern logic_passwortErneuern => ServiceLocator.Current.GetInstance<Logic_PasswortErneuern>();
        public MainViewModel Logic_EinladungErstellen => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MainViewModel Logic_Einladungsuebersicht => ServiceLocator.Current.GetInstance<MainViewModel>();
        public Logic_Login logic_login => ServiceLocator.Current.GetInstance<Logic_Login>();
        public Logic_Abschussliste logic_abschussliste => ServiceLocator.Current.GetInstance<Logic_Abschussliste>();
        public Logic_AbschusslisteAktualisieren logic_AbschusslisteAktualisieren => ServiceLocator.Current.GetInstance<Logic_AbschusslisteAktualisieren>();
        public UrkundeErstellenViewModel UrkundeErstellen => ServiceLocator.Current.GetInstance<UrkundeErstellenViewModel>();
        public Logic_PasswortAendern logic_passwortAendern => ServiceLocator.Current.GetInstance<Logic_PasswortAendern>();

        public Logic_NeuesPasswort logic_neuespasswort => ServiceLocator.Current.GetInstance<Logic_NeuesPasswort>();

        public Logic_Registrierung logic_registrierung => ServiceLocator.Current.GetInstance<Logic_Registrierung>();

        public Logic_Sicherheitsfrage_zuruecksetzen logic_sicherheitsfrage_zuruecksetzen => ServiceLocator.Current.GetInstance<Logic_Sicherheitsfrage_zuruecksetzen>();

        public Logic_Jaeger_Informationen logic_jaeger_informationen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Informationen>();

        public Logic_Jaeger_Hinzufuegen logic_jaeger_hinzufuegen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Hinzufuegen>();

        public Logic_Jaeger_Bearbeiten logic_jaeger_bearbeiten => ServiceLocator.Current.GetInstance<Logic_Jaeger_Bearbeiten>();

        public static void Cleanup()
        {
            
        }
    }
}