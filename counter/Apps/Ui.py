from customtkinter import *
from Helpers.Save import Save
from Apps.UiController import UiController

class Ui:
    def __init__(self, root:CTk, save:Save):
        self.save = save
        self.root = root
        self.controller = UiController(self.root, self.save)

        self.__center_window()
        self.__tab_views()
        self.__main_tab()
        self.__settings_tab()
        self.controller._ask_to_load_data()

    def __tab_views(self):
        self.tab_view = CTkTabview(master=self.root, width=500, height=400)
        self.tab_view.add("Main")
        self.tab_view.add("Settings")

        self.tab_view.configure(command=self.controller._on_tab_command)

        self.tab_view.pack()

    def __main_tab(self):
        # Labels
        self.current_save_label = CTkLabel(master=self.tab_view.tab("Main"), text=f"{self.save.name}",
                                           font=("Arial", 46))
        self.current_count_label = CTkLabel(master=self.tab_view.tab("Main"), text=f"{self.save.count}",
                                            font=("Arial", 34))
        # Buttons
        self.increment_button = CTkButton(master=self.tab_view.tab("Main"), corner_radius=32,
                                          text="+", command=self.controller.increment_button_click)
        self.save_button = CTkButton(master=self.tab_view.tab("Main"), corner_radius=32,
                                     text="Save counter", command=self.controller.save_button_click)
        self.load_button = CTkButton(master=self.tab_view.tab("Main"), corner_radius=32,
                                     text="Load counter", command=self.controller.load_button_click)

        # Placing
        self.current_save_label.place(relx=0.5, rely=0.2, anchor="center")
        self.current_count_label.place(relx=0.5, rely=0.5, anchor="center")
        self.increment_button.place(relx=0.7, rely=0.5, anchor="center")
        self.save_button.place(relx=0.15, rely=0.8, anchor="w")
        self.load_button.place(relx=0.85, rely=0.8, anchor="e")

        # Adding to labels
        labels = [{"name": "current_save_label", "label": self.current_save_label},
                       {"name": "current_count_label", "label": self.current_count_label},
                       {"name": "increment_button", "label": self.increment_button},
                       {"name": "save_button", "label": self.save_button},
                       {"name": "load_button", "label": self.load_button}]
        self.controller.add_labels(labels)

    def __settings_tab(self):
        self.setting_increment_size_label = CTkLabel(master=self.tab_view.tab("Settings"), text="Increment Size: ", font=("Arial", 32))
        self.setting_increment_size_input = CTkEntry(master=self.tab_view.tab("Settings"), placeholder_text=f"{self.save.count_increment}", font=("Arial", 32))
        self.save_settings_button = CTkButton(master=self.tab_view.tab("Settings"), text="Apply", command=self.controller._ask_to_save_settings)

        self.setting_increment_size_label.place(relx=0.2, rely=0.2)
        self.setting_increment_size_input.place(relx=0.5, rely=0.2)
        self.save_settings_button.place(relx=0.84, rely=0.8, anchor="e")

        labels = [{"name": "settings_increment_size_label", "label": self.setting_increment_size_label},
                       {"name": "setting_increment_size_input", "label": self.setting_increment_size_input},
                       {"name": "save_settings_button", "label": self.save_settings_button}]
        self.controller.add_labels(labels)

    def __center_window(self):
        window_width = 500
        window_height = 400
        screen_width = self.root.winfo_screenwidth()
        screen_height = self.root.winfo_screenheight()

        x_position = (screen_width // 2) - (window_width // 2)
        y_position = (screen_height // 2) - (window_height // 2)

        self.root.geometry(f"{window_width}x{window_height}+{x_position}+{y_position}")

