from customtkinter import *
# from MessageBoxes.MessageBoxAsk import MessageBoxAsk
# from MessageBoxes.MessageBoxError import MessageBoxError
# from MessageBoxes.MessageBoxYesNo import MessageBoxYesNo
from Helpers.Save import Save
from Apps.Ui import Ui

class CounterApp:
    def __init__(self):
        self.root = CTk()
        set_default_color_theme("Styles/Sweetkind.json")

        self.save = Save()
        self.current_count = 0;
        self.current_save = "None";
        self.increment_size = 1
        self.ui = Ui(self.root, self.save)



    #
    # def _save_settings(self):
    #     try:
    #         self.increment_size = int(self.setting_increment_size_input.get())
    #         self._save_save()
    #     except Exception as e:
    #         print(f"Error Saving Settings: {e}")

    def run(self):
        self.root.mainloop()

