from models.auth import Authenticate
from Classes.youtube import MyTube

class Model:
    def __init__(self):
        self.auth = Authenticate()
        self.youtube = MyTube()
