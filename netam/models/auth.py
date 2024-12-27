import sqlite3
from models.observable_object import ObservableObject
from Classes.User import User
from Classes.DataBaseManager import DataBaseManager

class Authenticate(ObservableObject):
    def __init__(self):
        super().__init__()
        self.is_logged_in = False
        self.current_user = None
        self.manager = DataBaseManager("test.db")

    def signup(self, user: User):
        try:
            return self.manager.create_new_user(user)
        except sqlite3.IntegrityError as e:
            raise sqlite3.IntegrityError(f"Error while creating new user: {e}")

    def login(self, user: User):
        users = self.manager.get_all_users()
        for db_user in users:
            if user.username == db_user.username and user.password == db_user.password:
                self.is_logged_in = True
                self.current_user = user
        self.trigger_event("auth_changed")

    def logout(self):
        self.is_logged_in = False
        self.current_user = None
        self.trigger_event("auth_changed")
