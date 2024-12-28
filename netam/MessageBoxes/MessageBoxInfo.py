from MessageBoxes.MessageBoxBase import MessageBoxBase
from customtkinter import *

class MessageBoxInfo(MessageBoxBase):
    def __init__(self, parent: CTk, title: str, info: str):
        super().__init__(parent, title, info)
