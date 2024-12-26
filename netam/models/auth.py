from models.observable_object import ObservableObject
from Classes.User import User
from MessageBoxes.MessageBoxError import MessageBoxError

class Authenticate(ObservableObject):
    def __init__(self):
        super().__init__()
        self.is_logged_in = False
        self.current_user = None

    def login(self, user: User):
        if user.username == "abc" and user.password == "abc":
            self.is_logged_in = True
            self.current_user = user
        self.trigger_event("auth_changed")

    def logout(self):
        self.is_logged_in = False
        self.current_user = None
        self.trigger_event("auth_changed")
