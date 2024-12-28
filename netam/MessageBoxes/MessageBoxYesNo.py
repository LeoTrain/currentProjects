from MessageBoxes.MessageBoxBase import MessageBoxBase
from customtkinter import *

class MessageBoxYesNo(MessageBoxBase):
    def __init__(self, parent: CTk, title: str, question: str, callback=None):
        super().__init__(parent, title, question, callback)
        self.ok_button.configure(text="Yes", command=self._close_yes)
        self.cancel_button.configure(text="No", command=self._close_no)

    def _close_yes(self):
        if self.callback:
            self.callback(True)
        self.window.destroy()

    def _close_no(self):
        if self.callback:
            self.callback(False)
        self.window.destroy()
