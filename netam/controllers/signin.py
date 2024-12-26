class SignInController:
    def __init__(self, model, view):
        self.model = model
        self.view = view
        self.frame = self.view.frames["signin"]
        self._bind()

    def _bind(self):
        self.frame.signin_btn.configure(command=self.signin)

    def signin(self):
        username = self.frame.username_input.get()
        password = self.frame.password_input.get()

        data = {"username": username, "password": password}
        print(data)
        self.frame.password_input.delete(0, last=len(password))
        self.model.auth.login(data)
