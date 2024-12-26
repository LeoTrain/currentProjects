from MessageBoxes.MessageBoxBase import MessageBoxBase
from customtkinter import *

class MessageBoxAsk(MessageBoxBase):
    def __init__(self, parent: CTk, title: str, question: str, callback):
        super().__init__(parent, title, question, callback, True)
