/*** Auto-generated ***/

namespace Sample.Avalonia {

    using BaseComponent = Sample.Avalonia.ExtendedReactView;
    using BaseModule = ReactViewControl.ViewModuleContainer;

    

    

    public partial interface IMainViewModule {
        
    }
    
    public partial interface IMainView : IMainViewModule {}

    public partial class MainViewModule : BaseModule, IMainViewModule {
        
        internal interface IProperties {
            
        }
        
        private class Properties : IProperties {
            protected MainViewModule Owner { get; }
            public Properties(MainViewModule owner) => Owner = owner;
            // the interface does not contain methods
        }
        
        
        
        protected override string MainJsSource => "/Sample.Avalonia/Generated/MainView.js";
        protected override string NativeObjectName => "MainView";
        protected override string ModuleName => "MainView";
        protected override object CreateNativeObject() => new Properties(this);
        
        
        #if DEBUG
        protected override string Source => "/Users/conrado.goncalves/Documents/Github/ReactView-SampleAvalonia/Sample.Avalonia/Generated/MainView.js";
        #endif
    }
    
    public partial class MainView : BaseComponent, IMainViewModule {
    
        public MainView() : base(new MainViewModule()) {
            InitializeMainView();
        }
    
        partial void InitializeMainView();
    
        protected new MainViewModule MainModule => (MainViewModule) base.MainModule;
    
        
    }

}