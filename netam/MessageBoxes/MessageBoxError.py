from MessageBoxes.MessageBoxBase import MessageBoxBase
from customtkinter import *

class MessageBoxError(MessageBoxBase):
    def __init__(self, parent: CTk, title: str, error: str):
        super().__init__(parent, title, error)
