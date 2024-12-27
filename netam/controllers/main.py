from controllers.signin import SignInController
from controllers.signup import SignUpController
from controllers.home import HomeController
from controllers.download import DownloadController
from MessageBoxes.MessageBoxError import MessageBoxError

class Controller:
    def __init__(self, model, view):
        self.view = view
        self.model = model
        self.signin_controller = SignInController(model, view)
        self.signup_controller = SignUpController(model, view)
        self.home_controller = HomeController(model, view)
        self.download_controller = DownloadController(model, view)

        self.model.auth.add_event_listener("auth_changed", self.auth_state_listener)

    def auth_state_listener(self, data):
        if data.is_logged_in:
            self.home_controller.update_view()
            self.view.switch("home")
        else:
            MessageBoxError(self.view.root, "Login Error", "There was an error with your credentials.")
            self.view.switch("signin")

    def start(self):
        if self.model.auth.is_logged_in:
            self.view.switch("home")
        else:
            self.view.switch("signin")

        self.view.start_mainloop()
