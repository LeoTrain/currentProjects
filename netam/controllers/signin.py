from Classes.User import User

class SignInController:
    def __init__(self, model, view):
        self.model = model
        self.view = view
        self.frame = self.view.frames["signin"]
        self._bind()

    def _bind(self):
        self.frame.signin_btn.configure(command=self.signin)
        self.frame.signup_btn.configure(command=self.signup)

    def signup(self):
        self.view.switch("signup")

    def signin(self):
        username = self.frame.username_input.get()
        password = self.frame.password_input.get()
        user = User(username=username, password=password)

        self.frame.password_input.delete(0, 'end')
        self.model.auth.login(user)
