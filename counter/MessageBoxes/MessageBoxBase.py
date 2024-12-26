from customtkinter import *

class MessageBoxBase:
    def __init__(self, parent: CTk, title: str="", question: str="", callback=None, is_input_label: bool=False):
        self.parent = parent
        self.title = title
        self.question = question
        self.callback = callback
        self.is_input_label = is_input_label

        self.window = CTkToplevel(self.parent)
        self.window.title(self.title)
        self._center_window()

        if question:
            self.question_label = CTkLabel(self.window, text=question, font=("Arial", 14))
            self.question_label.place(relx=0.5, rely=0.35, anchor="center")

            if self.is_input_label:
                self.question_label.place(relx=0.05, rely=0.35, anchor="w")
                self.input_label = CTkEntry(self.window, width=200)
                self.input_label.place(relx=0.45, rely=0.3)

        self.ok_button = CTkButton(self.window, text="OK", 
                                        command=self._close)
        self.cancel_button = CTkButton(self.window, text="Cancel", 
                                        command=self._close)
        self.ok_button.place(relx=0.8, rely=0.8, anchor="center")
        self.cancel_button.place(relx=0.2, rely=0.8, anchor="center")


        self.window.transient(parent)
        self.window.grab_set()

    def _center_window(self):
        window_width = 400
        window_height = 150
        screen_width = self.window.winfo_screenwidth()
        screen_height = self.window.winfo_screenheight()
        x_position = (screen_width // 2) - (window_width // 2)
        y_position = (screen_height // 2) - (window_height // 2)
        self.window.geometry(f"{window_width}x{window_height}+{x_position}+{y_position}")

    def _close(self):
        if self.question and self.is_input_label:
            response = self.input_label.get()
            if self.callback:
                self.callback(response)
        self.window.destroy()
