from models.observable_object import ObservableObject

class HomeModel(ObservableObject):
    def __init__(self):
        super().__init__()
        self.user = ""

    def login(self, user):
        self.user = user
        self.trigger_event("home_changed")

    def logout(self):
        self.trigger_event("home_changed")
        
