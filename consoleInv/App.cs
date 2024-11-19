namespace consoleInv
{
   public class App
   {
      private bool _isAuthenticated = false; 
      private LoginPage _loginPage = new LoginPage();
      private MainWindow _mainWindow = new MainWindow();

      public void Run()
      {
        while (true)
        {
            if (!_isAuthenticated)
            {
                _isAuthenticated = _loginPage.Show();
            }
            else
            {
               _mainWindow.Show(); 
            }
        }
      }
   } 
}
