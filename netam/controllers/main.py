from controllers.signin import SignInController

class Controller:
    def __init__(self, model, view):
        self.view = view
        self.model = model
        self.signin_controller = SignInController(model, view)

        self.model.login.add_event_listener("loggin_changed", self.login_state_listener)

    def login_state_listener(self, data):
        self.view.switch("signin")

    def start(self):
        self.view.switch("signin")
        self.view.start_mainloop()
