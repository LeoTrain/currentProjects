from MessageBoxes.MessageBoxBase import MessageBoxBase
from customtkinter import *

class MessageBoxItems(MessageBoxBase):
    def __init__(self, parent: CTk, title: str, question: str, callback, options: list[str]):
        super().__init__(parent, title, question, callback, is_input_label=False)

        self.options = options
        self.selected_option = StringVar(self.window)
        self.selected_option.set(self.options[0])

        self.option_menu = CTkOptionMenu(self.window, values=self.options, variable=self.selected_option)
        self.option_menu.place(relx=0.45, rely=0.5, anchor="center")
        self.question_label.place(relx=0.45, rely=0.3, anchor="center")

        self.ok_button.configure(command = self._close_with_options)

    def _close_with_options(self):
        if self.callback:
            self.callback(self.selected_option.get())
        self.window.destroy()
