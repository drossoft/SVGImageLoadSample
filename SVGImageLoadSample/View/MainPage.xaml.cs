using SVGImageLoadSample.ViewModel;

namespace SVGImageLoadSample.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

