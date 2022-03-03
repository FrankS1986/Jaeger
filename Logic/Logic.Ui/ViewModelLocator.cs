using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JaegerMeister.MvvmSample.Logic.Ui.Converter;

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
            SimpleIoc.Default.Register<Logic_DokumenteVerwalten>();
            SimpleIoc.Default.Register<Logic_Urkunden_Erstellen>();
            SimpleIoc.Default.Register<Logic_Admin>();
            SimpleIoc.Default.Register<Logic_Termine>();
            SimpleIoc.Default.Register<Logic_Abschussliste>();
            SimpleIoc.Default.Register<Logic_Wildunfaelle>();
            SimpleIoc.Default.Register<Logic_PasswortErneuern>();
            SimpleIoc.Default.Register<Logic_Jaeger_Informationen>();
            SimpleIoc.Default.Register<Logic_Jaeger_Hinzufuegen>();
            SimpleIoc.Default.Register<Logic_Jaeger_Bearbeiten>();
            SimpleIoc.Default.Register<Logic_EinladungErstellen>();
            SimpleIoc.Default.Register<Logic_Einladungsuebersicht>();
            SimpleIoc.Default.Register<Logic_Login>();
            SimpleIoc.Default.Register<Logic_Sicherheitsfrage>();
            SimpleIoc.Default.Register<Logic_Abschussliste>();
            SimpleIoc.Default.Register<Logic_Registrierung>();
            SimpleIoc.Default.Register<Logic_AbschusslisteAktualisieren>();
            SimpleIoc.Default.Register<Logic_Einladungsrueckmeldung>();
            SimpleIoc.Default.Register<Logic_PasswortAendern>();
            SimpleIoc.Default.Register<Logic_NeuesPasswort>();
            SimpleIoc.Default.Register<Logic_SicherheitsFragestellung>();
            SimpleIoc.Default.Register<Logic_Kalender>();
            
            
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public Logic_DokumenteVerwalten logic_DokumenteVerwalten => ServiceLocator.Current.GetInstance<Logic_DokumenteVerwalten>();
        public Logic_Urkunden_Erstellen logic_UrkundenErstellen => ServiceLocator.Current.GetInstance<Logic_Urkunden_Erstellen>();
        public Logic_Admin logic_Admin => ServiceLocator.Current.GetInstance<Logic_Admin>();
        public Logic_Termine logic_Termine => ServiceLocator.Current.GetInstance<Logic_Termine>();
        public Logic_Abschussliste logic_Abschussliste => ServiceLocator.Current.GetInstance<Logic_Abschussliste>();        
        public Logic_Wildunfaelle logic_Wildunfaelle => ServiceLocator.Current.GetInstance<Logic_Wildunfaelle>();        
        public Logic_PasswortErneuern logic_PasswortErneuern => ServiceLocator.Current.GetInstance<Logic_PasswortErneuern>();
        public Logic_EinladungErstellen logic_EinladungErstellen => ServiceLocator.Current.GetInstance<Logic_EinladungErstellen>();
        public Logic_Einladungsuebersicht logic_EinladungsUebersicht => ServiceLocator.Current.GetInstance<Logic_Einladungsuebersicht>();
        public Logic_Login logic_Login => ServiceLocator.Current.GetInstance<Logic_Login>();       
        public Logic_AbschusslisteAktualisieren logic_AbschusslisteAktualisieren => ServiceLocator.Current.GetInstance<Logic_AbschusslisteAktualisieren>();
        public Logic_PasswortAendern logic_PasswortAendern => ServiceLocator.Current.GetInstance<Logic_PasswortAendern>();
        public Logic_NeuesPasswort logic_NeuesPasswort => ServiceLocator.Current.GetInstance<Logic_NeuesPasswort>();
        public Logic_Registrierung logic_Registrierung => ServiceLocator.Current.GetInstance<Logic_Registrierung>();
        public Logic_Sicherheitsfrage logic_SicherheitsfrageZuruecksetzen => ServiceLocator.Current.GetInstance<Logic_Sicherheitsfrage>();
        public Logic_Jaeger_Informationen logic_JaegerInformationen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Informationen>();
        public Logic_Jaeger_Hinzufuegen logic_jaegerHinzufuegen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Hinzufuegen>();
        public Logic_Jaeger_Bearbeiten logic_jaegerBearbeiten => ServiceLocator.Current.GetInstance<Logic_Jaeger_Bearbeiten>();
        public Logic_Einladungsrueckmeldung logic_EinladungsRueckmeldung => ServiceLocator.Current.GetInstance<Logic_Einladungsrueckmeldung>();
        public Logic_SicherheitsFragestellung logic_SicherheitsFragestellung => ServiceLocator.Current.GetInstance<Logic_SicherheitsFragestellung>();
        public Logic_Kalender logic_Kalender => ServiceLocator.Current.GetInstance<Logic_Kalender>();
        


        public static void Cleanup()
        {
            
        }
    }
}