

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
            SimpleIoc.Default.Register<Logic_EinladungErstellen>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MainViewModel logic_einladungErstellen => ServiceLocator.Current.GetInstance<MainViewModel>();
        public static void Cleanup()
        {
            
        }
    }
}