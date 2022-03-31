using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JaegerMeister.MvvmSample.Logic.Ui.ViewModels;

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
            SimpleIoc.Default.Register<DokumenteVerwaltenViewModel>();
            SimpleIoc.Default.Register<UrkundeErstellenViewModel>();
            SimpleIoc.Default.Register<AdminViewModel>();
            SimpleIoc.Default.Register<TermineViewModel>();
            SimpleIoc.Default.Register<AbschusslisteViewModel>();
            SimpleIoc.Default.Register<WildunfaelleViewModel>();
            SimpleIoc.Default.Register<PasswortErneuernViewModel>();
            SimpleIoc.Default.Register<JaegerInformationenViewModel>();
            SimpleIoc.Default.Register<JaegerHinzufuegenViewModel>();
            SimpleIoc.Default.Register<JaegerBearbeitenViewModel>();
            SimpleIoc.Default.Register<EinladungErstellenViewModel>();
            SimpleIoc.Default.Register<EinladungsuebersichtViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SicherheitsfrageViewModel>();
            SimpleIoc.Default.Register<AbschusslisteViewModel>();
            SimpleIoc.Default.Register<RegistrierungViewModel>();
            SimpleIoc.Default.Register<AbschusslisteAktualisierenViewModel>();
            SimpleIoc.Default.Register<EinladungsrueckmeldungViewModel>();
            SimpleIoc.Default.Register<PasswortAendernViewModel>();
            SimpleIoc.Default.Register<NeuesPasswortViewModel>();
            SimpleIoc.Default.Register<SicherheitsFragestellungViewModel>();
            SimpleIoc.Default.Register<KalenderViewModel>();            
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public DokumenteVerwaltenViewModel DokumenteVerwalten => ServiceLocator.Current.GetInstance<DokumenteVerwaltenViewModel>();
        public UrkundeErstellenViewModel UrkundenErstellen => ServiceLocator.Current.GetInstance<UrkundeErstellenViewModel>();
        public AdminViewModel Admin => ServiceLocator.Current.GetInstance<AdminViewModel>();
        public TermineViewModel Termine => ServiceLocator.Current.GetInstance<TermineViewModel>();
        public AbschusslisteViewModel Abschussliste => ServiceLocator.Current.GetInstance<AbschusslisteViewModel>();        
        public WildunfaelleViewModel Wildunfaelle => ServiceLocator.Current.GetInstance<WildunfaelleViewModel>();        
        public PasswortErneuernViewModel PasswortErneuern => ServiceLocator.Current.GetInstance<PasswortErneuernViewModel>();
        public EinladungErstellenViewModel EinladungErstellen => ServiceLocator.Current.GetInstance<EinladungErstellenViewModel>();
        public EinladungsuebersichtViewModel EinladungsUebersicht => ServiceLocator.Current.GetInstance<EinladungsuebersichtViewModel>();
        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();       
        public AbschusslisteAktualisierenViewModel AbschusslisteAktualisieren => ServiceLocator.Current.GetInstance<AbschusslisteAktualisierenViewModel>();
        public PasswortAendernViewModel PasswortAendern => ServiceLocator.Current.GetInstance<PasswortAendernViewModel>();
        public NeuesPasswortViewModel NeuesPasswort => ServiceLocator.Current.GetInstance<NeuesPasswortViewModel>();
        public RegistrierungViewModel Registrierung => ServiceLocator.Current.GetInstance<RegistrierungViewModel>();
        public SicherheitsfrageViewModel SicherheitsfrageZuruecksetzen => ServiceLocator.Current.GetInstance<SicherheitsfrageViewModel>();
        public JaegerInformationenViewModel JaegerInformationen => ServiceLocator.Current.GetInstance<JaegerInformationenViewModel>();
        public JaegerHinzufuegenViewModel Jaeger_Hinzufuegen => ServiceLocator.Current.GetInstance<JaegerHinzufuegenViewModel>();
        public JaegerBearbeitenViewModel jaegerBearbeiten => ServiceLocator.Current.GetInstance<JaegerBearbeitenViewModel>();
        public EinladungsrueckmeldungViewModel EinladungsRueckmeldung => ServiceLocator.Current.GetInstance<EinladungsrueckmeldungViewModel>();
        public SicherheitsFragestellungViewModel SicherheitsFragestellung => ServiceLocator.Current.GetInstance<SicherheitsFragestellungViewModel>();
        public KalenderViewModel Kalender => ServiceLocator.Current.GetInstance<KalenderViewModel>();


        public static void Cleanup()
        {
            
        }
    }
}