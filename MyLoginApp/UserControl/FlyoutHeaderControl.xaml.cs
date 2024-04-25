//namespace MyLoginApp.NewFolder;
namespace MyLoginApp.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
    {
        InitializeComponent();

        // Check if user information is available
        if (App.UserInfo != null)
        {
            lblUserName.Text = "Logged in as: " + App.UserInfo.UserName;
            lblUserEmail.Text = App.UserInfo.UserName;
        }
    }

    
}
