from customtkinter import *
import customtkinter
from Helpers.Save import Save
from Apps.Ui import Ui

class CounterApp:
    def __init__(self):
        self.root = CTk()
        set_default_color_theme("Styles/Cherry.json")
        customtkinter.set_appearance_mode("System")

        self.save = Save()
        self.current_count = 0;
        self.current_save = "None";
        self.increment_size = 1
        self.ui = Ui(self.root, self.save)

    def run(self):
        self.root.mainloop()

