from models.auth import Authenticate
from Classes.YoutubeToMp3 import YoutubeToMp3

class Model:
    def __init__(self):
        self.auth = Authenticate()
        self.youtube = YoutubeToMp3()
