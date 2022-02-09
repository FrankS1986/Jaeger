

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

            SimpleIoc.Default.Register<Logic_Jaeger_Informationen>();

            SimpleIoc.Default.Register<Logic_Jaeger_Hinzufuegen>();

            SimpleIoc.Default.Register<Logic_Jaeger_Bearbeiten>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public Logic_Jaeger_Informationen logic_jaeger_informationen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Informationen>();

        public Logic_Jaeger_Hinzufuegen logic_jaeger_hinzufuegen => ServiceLocator.Current.GetInstance<Logic_Jaeger_Hinzufuegen>();

        public Logic_Jaeger_Bearbeiten logic_jaeger_bearbeiten => ServiceLocator.Current.GetInstance<Logic_Jaeger_Bearbeiten>();

        public static void Cleanup()
        {
            
        }
    }
}