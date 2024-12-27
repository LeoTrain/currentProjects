import sqlite3
from MessageBoxes.MessageBoxInfo import MessageBoxInfo
from Classes.User import User

class SignUpController:
    def __init__(self, model, view):
        self.model = model
        self.view = view
        self.frame = self.view.frames["signup"]
        self._bind()

    def _bind(self):
        self.frame.signup_btn.configure(command=self.signup)
        self.frame.signin_btn.configure(command=self.signin)

    def signin(self):
        self.view.switch("signin")

    def signup(self):
        new_user = User(fullname=self.frame.fullname_input.get(),
                        username=self.frame.username_input.get(),
                        password=self.frame.password_input.get()
                        )
        try:
            self.model.auth.signup(new_user)
            MessageBoxInfo(self.view.root, "Success", f"New user {new_user.username} created.")
        except sqlite3.IntegrityError:
            MessageBoxInfo(self.view.root, "No Success", f"The username {new_user.username} is already taken.")

